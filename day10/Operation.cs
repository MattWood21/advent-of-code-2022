using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day10
{
    public class Operation
    {
        public OperationType OperationType { get; private set; }
        public int Value { get; private set; }

        public int ProcessingCyclesLeft { get; set; }

        public Operation(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                throw new InvalidOperationException($@"Invalid input");
            }

            var inputParts = input.Split(" ");
            if(inputParts.Length == 0 || inputParts.Length > 2)
            {
                throw new InvalidOperationException($@"Invalid input");
            }

            if (inputParts[0].ToLower() == "noop")
            {
                OperationType = OperationType.noop;
                ProcessingCyclesLeft = 0;
                return;
            }
            else if (inputParts[0] == "addx")
            {
                OperationType = OperationType.addX;
                ProcessingCyclesLeft = 1;
            }
            else
            {
                throw new InvalidOperationException($@"Unknown operation type");
            }

            if (!int.TryParse(inputParts[1], out var parsedValue))
            {
                throw new InvalidOperationException($@"Invalid int value for addX input");
            }

            Value = parsedValue;
        }

        public static IEnumerable<Operation> BuildBulk(IEnumerable<string> inputValues)
        {
            List<Operation> result = new List<Operation>();
            foreach(var input in inputValues)
            {
                result.Add(new Operation(input));
            }
            return result;
        }
    }
}
