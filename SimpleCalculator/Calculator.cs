using System.Runtime.CompilerServices;
using SimpleCalculator.Models.Register;

[assembly: InternalsVisibleTo("SimpleCalculator.Tests")]

namespace SimpleCalculator;

// make it static?
public class Calculator
{
    internal readonly List<Register> _registers = new List<Register>();
    internal Register? _currentRegister;
    private string _currentName = default!;
    private string _currentOperation = default!;
    private int _currentValue = default!;
    private string _registerToLink = default!;

    public void CommandHandler(string command)
    {
        DestructureCommand(command);
        // _currentRegister = SetRegister(_currentName);

        if (_registerToLink is "")
        {
            OperationHandler(_currentOperation);
        }
    }

    public void ProcessLinkedRegisters(Register register)
    {
        foreach (var registerPair in register.linkedRegisters)
        {
            var registerToOperate = FindRegisterByName(registerPair.Key);            
            ProcessLinkedRegisters(registerToOperate!);
            _currentValue = registerToOperate!.Result;
            _currentRegister = register;
            OperationHandler(registerPair.Value);
        };
    }

    public void OperationHandler(string operation)
    {
        switch (operation)
        {
            case "add":
                Add();
                break;
            case "subtract":
                Subtract();
                break;
            case "multiply":
                Multiply();
                break;
            case "print":
                Print();
                break;
        }
    }

    public void DestructureCommand(string command)
    {
        var inputs = command.ToLower().Split(" ");

        if (inputs[0] == "print")
        {
            if (inputs.Count() is not 2 || RegisterExist(inputs[1]) is false)
            {
                Console.WriteLine($"Print command is invalid");
            }
                _currentOperation = inputs[0];
                _currentName = inputs[1];
                _currentRegister = SetRegister(_currentName);
                _currentValue = 0;
                _registerToLink = "";
                return;
        }

        else if (inputs.Count() is not 3 || AreInputsValid(inputs) is false)
        {
            Console.WriteLine($"Command {command} is invalid, enter new command");
            return;
        }

        _currentName = inputs[0];
        _currentOperation = inputs[1];
        _currentRegister = SetRegister(_currentName);

        if (inputs[2].Any(Char.IsLetter))
        {
            SetRegister(inputs[2]);
            _currentValue = 0;
            _registerToLink = inputs[2];
            _currentRegister!.linkedRegisters.Add(_registerToLink, _currentOperation);
        }
        else
        {
            _currentValue = int.Parse(inputs[2]);
            _registerToLink = "";
        }
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

    public bool AreInputsValid(string[] inputs)
    {
        // improve to get a better error log, check for length and reverse the check if so?
        var validOperators = new string[] { "add", "multiply", "subtract" };
        return inputs[0].All(Char.IsLetter) && validOperators.Contains(inputs[1]);
    }

    public void Add()
    {
        _currentRegister!.Result += _currentValue;
    }

    public void Subtract()
    {
        _currentRegister!.Result -= _currentValue;
    }

    public void Multiply()
    {
        _currentRegister!.Result *= _currentValue;
    }

    public void Print()
    {
        if (_currentRegister!.linkedRegisters.Count != 0)
        {
            ProcessLinkedRegisters(_currentRegister!);
        }
        Console.WriteLine($"{_currentRegister.Name} is {_currentRegister!.Result}");
    }

    public bool RegisterExist(string name) => _registers.Any(register => register.Name == name);

    public Register FindRegisterByName(string name) => _registers.Find(register => register.Name == name);
}