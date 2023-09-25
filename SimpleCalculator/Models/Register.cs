
namespace SimpleCalculator.Models;

public class Register
{
  public string Name { get; init;  }
  public int Result{ get; set; }
  public Dictionary<string, string> linkedRegisters { get; set; }

  public Register(string name)
  {
    Name = name;
    Result = 0;
    linkedRegisters = new Dictionary<string, string>();
  }

}