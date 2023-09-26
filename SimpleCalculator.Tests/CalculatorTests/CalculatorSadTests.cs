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

}
