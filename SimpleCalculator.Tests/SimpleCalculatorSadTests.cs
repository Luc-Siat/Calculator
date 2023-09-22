using FluentAssertions;
using SimpleCalculator.Calculator;

namespace simpleCalculator.Tests;

public class SimpleCalculatorSadTests
{
    private readonly Calculator _calculator = new Calculator(); 

    
    [Fact]
    public void AreInputsValid_return_false_if_register_is_using_nonletters()
    {
        // Arrange
        var testInputs= new []{"3", "add", "2"};

        // Act
        var response = _calculator.AreInputsValid(testInputs);

        // Assert 
        response.Should().BeFalse();
    }

    [Fact]
    public void AreInputsValid_return_false_if_operator_is_invalid()
    {
        // Arrange
        var testInputs= new []{"A", "invalid", "2"};
        // Act
        var response = _calculator.AreInputsValid(testInputs);
        // Assert 
        response.Should().BeFalse();
    }

    [Fact]
    public void AreInputsValid_return_false_if_value_is_not_a_number()
    {
        // Arrange
        var testInputs= new []{"A", "add", "re"};
        // Act
        var response = _calculator.AreInputsValid(testInputs);
        // Assert 
        response.Should().BeFalse();
    }
}
