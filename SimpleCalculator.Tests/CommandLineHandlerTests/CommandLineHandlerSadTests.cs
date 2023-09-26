using FluentAssertions;
using SimpleCalculator.Calculators;
using SimpleCalculator.CommandLineHandler;
using SimpleCalculator.Models;

namespace simpleCalculator.Tests;

public class CommandLineHandlerSadTests
{
    private readonly Calculator _calculator = new Calculator(); 

    public CommandLineHandlerSadTests()
    {
        _calculator._registers.Clear();
    }

    [Fact]
    public void CreateOperationCommand_should_return_a_null_and_console_error_if_command_is_invalid()
    {
        // Arrange

        // Act
        var input = new []{"3", "add", "2"};
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var operationCommand = CommandLineHandler.CreateOperationCommand(_calculator, input);        
        // Assert 
        stringWriter.ToString().Trim().Should().Be("register name can only contain letters");
        operationCommand.Should().BeNull();
    }

    [Fact]
    public void CreateOperationCommand_should_return_a_null_and_console_error_if_command_does_not_contain_operator()
    {
        // Arrange

        // Act
        var input = new []{"a", "ada", "2"};
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var operationCommand = CommandLineHandler.CreateOperationCommand(_calculator, input);        
        // Assert 
        stringWriter.ToString().Trim().Should().Be("register name can only contain add, multiply and subtract");
        operationCommand.Should().BeNull();
    }
    [Fact]
    public void CreateOperationCommand_should_return_a_number_value_when_value_sent_is_number()
    {
        // Arrange

        // Act
        var input = new []{"a", "add", "b"};

        var operationCommand = CommandLineHandler.CreateOperationCommand(_calculator, input);        
        // Assert 
        operationCommand.RegisterToLink.Should().Be("b");
    }
    [Fact]
    public void CreateOperationCommand_should_return_a_registerToLink()
    {
        // Arrange

        // Act
        var input = new []{"a", "add", "2"};

        var operationCommand = CommandLineHandler.CreateOperationCommand(_calculator, input);        
        // Assert 
        operationCommand.Value.Should().Be(2);
        operationCommand.RegisterToLink.Should().BeNull();

    }
}
