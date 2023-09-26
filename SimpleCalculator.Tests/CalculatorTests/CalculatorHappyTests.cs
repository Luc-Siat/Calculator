using FluentAssertions;
using SimpleCalculator.Calculators;
using SimpleCalculator.CommandLineHandler;
using SimpleCalculator.Models;

namespace simpleCalculator.Tests;

public class CalculatorHappyTests
{
    private readonly Calculator _calculator = new Calculator(); 

    public CalculatorHappyTests()
    {
        _calculator._registers.Clear();
    }

    [Fact]
    public void SetRegister_creates_when_register_name_does_not_exist_in_registers()
    {
        // Arrange
        var testInputs= new []{"A", "add", "2"};
        // Act
        CommandLineHandler.CommandDispatcher(_calculator, "A add 2");
        // Assert 
        _calculator._registers.Count().Should().Be(1);
    }
    [Fact]
    public void SetRegister_does_create_twice_register_with_same_name()
    {
        // Arrange
        // Act
        CommandLineHandler.CommandDispatcher(_calculator, "A add 2");
        CommandLineHandler.CommandDispatcher(_calculator, "A add 2");
        // Assert 
        _calculator._registers.Count().Should().Be(1);
    }

    [Fact]
    public void Print_inputs_the_value_on_the_console()
    {
        // Arrange

        // Act
        CommandLineHandler.CommandDispatcher(_calculator, "A add 2");
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        CommandLineHandler.CommandDispatcher(_calculator, "print A");
        // Assert
        stringWriter.ToString().Trim().Contains("2");
        stringWriter.ToString().Trim().Contains("A");
    }


}
