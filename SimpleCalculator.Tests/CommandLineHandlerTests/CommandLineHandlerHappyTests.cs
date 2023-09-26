using FluentAssertions;
using SimpleCalculator.Calculators;
using SimpleCalculator.CommandLineHandler;
using SimpleCalculator.Models;

namespace simpleCalculator.Tests;

public class CommandLineHandlerHappyTests
{
    private readonly Calculator _calculator = new Calculator(); 

    public CommandLineHandlerHappyTests()
    {
        _calculator._registers.Clear();
    }

    [Fact]
    public void CreateOperationCommand_should_return_a_printcommand()
    {
        // Arrange

        // Act
        var input = new []{"a", "add", "2"};
        var operationCommand = CommandLineHandler.CreateOperationCommand(_calculator, input);
        // Assert 
        operationCommand.Register.Name.Should().Be("a");
    }



}
