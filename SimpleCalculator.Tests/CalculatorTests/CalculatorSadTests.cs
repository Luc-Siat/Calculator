using FluentAssertions;
using SimpleCalculator;
using SimpleCalculator.Calculators;
using SimpleCalculator.CommandLineHandler;

namespace simpleCalculator.Tests;

public class CalculatorSadTests
{
    private readonly Calculator _calculator = new Calculator(); 

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
    public void CommandDispatcher_Should_return_Print_command_not_valid_if_input_is_not_2_or_3()
    {
        // Arrange
        var input = "a ada 2 4";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        CommandLineHandler.CommandDispatcher(_calculator, input);        
        // Assert 
        stringWriter.ToString().Trim().Should().Be("a ada 2 4 Command not in a valid format, please try again");
    }

}
