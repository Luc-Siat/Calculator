using SimpleCalculator;
using System.Linq.Expressions;
using System.Net.Http.Headers;

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
      choice = Console.ReadLine();
    };

    switch (choice)
    {
      case "file" : 
        FileHandler(calculator);
        break;
      case "cli" : 
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
    while (command is not "quit" && command is not null)
    {
      Console.Write("-");
      command = Console.ReadLine();
      if (command is not "quit")
      {
        calculator.CommandHandler(command);
      }
    }
    Console.WriteLine("Thank you for using the simple calculator! \nHave a nice Day");
  }

  public static void FileHandler(Calculator calculator)
  {
    Console.WriteLine("Put your file in the Files folder then write your filename here:");
    Console.Write("-");
    var filename = Console.ReadLine();
    StreamReader streamReader = new StreamReader($"./Files/{filename}.txt");
    var command = streamReader.ReadLine();
    while (command is not null)
    {
      calculator.CommandHandler(command);
    }
    streamReader.Close();
  }
}