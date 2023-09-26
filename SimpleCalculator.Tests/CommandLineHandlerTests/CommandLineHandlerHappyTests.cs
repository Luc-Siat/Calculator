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
        var input = new []{"a", "add", "b"};
        var operationCommand = CommandLineHandler.CreateOperationCommand(_calculator, input);
        // Assert 
        operationCommand.Register.Name.Should().Be("a");
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

    // [Fact]
    // public void CommandDispatcher_Should_call_print()
    // {
    //     // Arrange

    //     // Act
    //     var input = "print a";
    //     var stringWriter = new StringWriter();
    //     Console.SetOut(stringWriter);
    //     CommandLineHandler.CommandDispatcher(_calculator, input);        
    //     // Assert 
    //     stringWriter.ToString().Trim().Should().Be("a ada 2 4 Command not in a valid format, please try again");
    // }
    




}
