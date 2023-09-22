
namespace SimpleCalculator.Models.Register;

public class Register
{
  public string Name { get; init;  }
  public int Result{ get; set; }
  // make it take a enum of operators?
  public Dictionary<string, string> linkedRegisters { get; set; }

  public Register(string name)
  {
    Name = name;
    Result = 0;
    linkedRegisters = new Dictionary<string, string>();
  }

}