using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public class OperationCommand
    {
        public required Register Register { get; set; }
        public required string Operation { get; set; }
        public int Value { get; set; }
        public string? RegisterToLink { get; set; }
    }
}