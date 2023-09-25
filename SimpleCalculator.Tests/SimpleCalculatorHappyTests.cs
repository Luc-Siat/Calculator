using FluentAssertions;
using SimpleCalculator.Calculators;
using SimpleCalculator.CommandLineHandler;
using SimpleCalculator.Models;

namespace simpleCalculator.Tests;

public class SimpleCalculatorHappyTests
{
    private Calculator _calculator = new Calculator(); 

    public SimpleCalculatorHappyTests()
    {
        _calculator._registers.Clear();
    }

    [Fact]
    public void CreateRegister_creates_when_register_name_does_not_exist_in_registers()
    {
        // Arrange
        var testInputs= new []{"A", "add", "2"};
        // Act
        CommandLineHandler.CommandDispatcher(_calculator, "A add 2");
        // Assert 
        _calculator._registers.Count().Should().Be(1);
    }
    [Fact]
    public void CreateRegister_does_create_twice_register_with_same_name()
    {
        // Arrange
        // Act
        CommandLineHandler.CommandDispatcher(_calculator, "A add 2");
        CommandLineHandler.CommandDispatcher(_calculator, "A add 2");
        // Assert 
        _calculator._registers.Count().Should().Be(1);
    }

    [Fact]
    public void Add_add_the_value_to_register_result()
    {
        // Arrange

        // Act
        CommandLineHandler.CommandDispatcher(_calculator, "A add 2");
        // Assert
        // _calculator._currentRegister.Result.Should().Be(2);
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
        stringWriter.ToString().Trim().Should().Be("2");
    }


}
