using FluentAssertions;
using SimpleCalculator.Calculator;
using SimpleCalculator.Models.Register;

namespace simpleCalculator.Tests;

public class SimpleCalculatorHappyTests
{
    private Calculator _calculator = new Calculator(); 

    public SimpleCalculatorHappyTests()
    {
        _calculator._registers.Clear();
    }

    [Fact]
    public void AreInputsValid_return_true_if_register_is_using_letters()
    {
        // Arrange
        var testInputs= new []{"A", "add", "2"};

        // Act
        var response = _calculator.AreInputsValid(testInputs);

        // Assert 
        response.Should().BeTrue();
    }

    [Fact]
    public void AreInputsValid_return_true_if_operator_is_valid()
    {
        // Arrange
        var testInputs= new []{"A", "add", "2"};
        // Act
        var response = _calculator.AreInputsValid(testInputs);
        // Assert 
        response.Should().BeTrue();
    }

    [Fact]
    public void AreInputsValid_return_true_if_value_is_a_number()
    {
        // Arrange
        var testInputs= new []{"A", "add", "2"};
        // Act
        var response = _calculator.AreInputsValid(testInputs);
        // Assert 
        response.Should().BeTrue();
    }

    [Fact]
    public void CreateRegister_creates_when_register_name_does_not_exist_in_registers()
    {
        // Arrange
        var testInputs= new []{"A", "add", "2"};
        // Act
        _calculator.CommandHandler("A add 2");
        // Assert 
        _calculator._registers.Count().Should().Be(1);
    }
    [Fact]
    public void CreateRegister_does_create_twice_register_with_same_name()
    {
        // Arrange
        // Act
        _calculator.CommandHandler("A add 2");
        _calculator.CommandHandler("A add 2");
        // Assert 
        _calculator._registers.Count().Should().Be(1);
    }

    [Fact]
    public void Add_add_the_value_to_register_result()
    {
        // Arrange

        // Act
        _calculator.CommandHandler("A add 2");
        // Assert
        _calculator._currentRegister.Result.Should().Be(2);
    }
    [Fact]
    public void Print_inputs_the_value_on_the_console()
    {
        // Arrange

        // Act
        _calculator.CommandHandler("A add 2");
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        _calculator.CommandHandler("print A");
        // Assert
        stringWriter.ToString().Trim().Should().Be("2");
    }


}
