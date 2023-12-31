using SimpleCalculator.Models;
using SimpleCalculator.Calculators;

namespace SimpleCalculator.CommandLineHandler;

public static class CommandLineHandler
{
  public static void Start()
  {
    var calculator = new Calculator();
    var choice = Console.ReadLine();

    while (choice != "file" && choice != "cli")
    {
      Console.WriteLine($"{choice} invalid command, please try again (file/cli)");
    };

    switch (choice)
    {
      case "file":
        FileHandler(calculator);
        break;
      case "cli":
        ManualCommandHandler(calculator);
        break;
      default:
        Start();
        break;
    };
  }

  public static void ManualCommandHandler(Calculator calculator)
  {
    var command = "";
    Console.WriteLine("Input your command:");
    while (command is not "quit")
    {
      Console.Write("-");
      command = Console.ReadLine();
      if (command is not "quit" && command is not null)
      {
        try
        {
          CommandDispatcher(calculator, command);
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
        }
      }
    }

    Console.WriteLine("Thank you for using the simple calculator! \nHave a nice Day");
  }

  public static void FileHandler(Calculator calculator)
  {
    Console.WriteLine("Put your file in the Files folder then write your filename here:");
    Console.Write("-");

    try
    {

      var filename = Console.ReadLine();
      var lines = File.ReadAllLines($"./Files/{filename}.txt");
      foreach (var line in lines)
      {
        Console.WriteLine(line);
        try
        {
          CommandDispatcher(calculator, line);
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
        }
      }

    }
    catch (Exception e)
    {
      Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
      Console.WriteLine("Exiting. \nThank you for using the simple calculator! \nHave a nice Day");
    }
  }

  public static void CommandDispatcher(Calculator calculator, string input)
  {
    var inputs = input.ToLower().Split(" ");

    if (inputs[0] == "print")
    {
      var currentCommand = CreatePrintCommand(calculator, inputs);

      var printMessage = calculator.Print(currentCommand.Register);

      Console.WriteLine(printMessage);
    }


    else if (inputs.Count() is 3)
    {
      var currentCommand = CreateOperationCommand(calculator, inputs);

      Calculator.OperationHandler(currentCommand);
    }
    else
    {
      Console.WriteLine($"{input} Command not in a valid format, please try again");
    }
  }

  public static PrintCommand CreatePrintCommand(Calculator calculator, string[] inputs)
  {
    if (inputs.Count() is not 2)
    {
      throw new Exception("Print command too long");
    }

    if (calculator.RegisterExist(inputs[1]) is false)
    {
      throw new Exception($"{inputs[1]} is not an existing register, please use this register before printing it");
    }

    var register = calculator.SetRegister(inputs[1]);

    return new PrintCommand()
    {
      Register = register,
    };
  }

  public static OperationCommand CreateOperationCommand(Calculator calculator, string[] inputs)
  {
    if (inputs[0].All(Char.IsLetter) is false)
    {
      throw new Exception("register name can only contain letters");

    };

    var validOperators = new string[] { "add", "multiply", "subtract" };
    if (validOperators.Contains(inputs[1]) is false)
    {
      throw new Exception("register name can only contain add, multiply and subtract");
    };



    var command = new OperationCommand
    {
      Register = calculator.SetRegister(inputs[0]),
      Operation = inputs[1]
    };

    if (inputs[2].Any(Char.IsLetter))
    {
      calculator.SetRegister(inputs[2]);
      command.RegisterToLink = inputs[2];
      command.Register.linkedRegisters.Add(command.RegisterToLink, command.Operation);
    }
    else
    {
      command.Value = int.Parse(inputs[2]);
    }
    return command;
  }
}