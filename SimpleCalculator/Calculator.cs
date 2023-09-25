using System.Runtime.CompilerServices;
using SimpleCalculator.Models;

[assembly: InternalsVisibleTo("SimpleCalculator.Tests")]

namespace SimpleCalculator.Calculators;

public class Calculator
{
    internal readonly List<Register> _registers = new List<Register>();


    public static void OperationHandler(OperationCommand command)
    {
        switch (command.Operation)
        {
            case "add":
                Add(command.Register, command.Value);
                break;
            case "subtract":
                Subtract(command.Register, command.Value);
                break;
            case "multiply":
                Multiply(command.Register, command.Value);
                break;
        }
    }

    public static void Add(Register register, int currentValue)
    {
        register.Result += currentValue;
    }

    public static void Subtract(Register register, int currentValue)
    {
        register.Result -= currentValue;
    }

    public static void Multiply(Register register, int currentValue)
    {
        register.Result *= currentValue;
    }

    public void Print(Register register)
    {
        if (register.linkedRegisters.Count is not 0)
        {
            ProcessLinkedRegisters(register);
        }
        Console.WriteLine($"--- {register.Name} total is {register!.Result} ---".ToUpper());
    }

    public void ProcessLinkedRegisters(Register register)
    {
        foreach (var registerPair in register.linkedRegisters)
        {
            var registerToOperate = FindRegisterByName(registerPair.Key);            
            ProcessLinkedRegisters(registerToOperate!);
            var command = new OperationCommand
            {
                Register = register,
                Operation = registerPair.Value,
                Value = registerToOperate!.Result
            };
            OperationHandler(command);
        };
    }

    public Register SetRegister(string name)
    {
        var existingRegister = FindRegisterByName(name);

        switch (existingRegister)
        {
            case null:
                var register = new Register(name);
                _registers.Add(register);
                return register;
            default:
                return existingRegister;
        }
    }

    public bool RegisterExist(string name) => _registers.Any(register => register.Name == name);

    public Register? FindRegisterByName(string name) => _registers.Find(register => register.Name == name);


}