using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day10
{
    public class Processor
    {
        private Queue<Operation> _operations { get; set; }

        public Processor(int operationCount = 100)
        {
            _operations = new Queue<Operation>(operationCount);
        }

        public void AddOperation(Operation operation)
        {
            _operations.Enqueue(operation);
        }

        public void AddOperationsBulk(IEnumerable<Operation> operations)
        {
            foreach (var operation in operations)
            {
                _operations.Enqueue(operation);
            }
        }

        public (int value, bool end) Process()
        {
            if(!_operations.Any())
            {
                return (0, true);
            }

            if(_operations.First().ProcessingCyclesLeft == 0)
            {
                var dequeuedOperation = _operations.Dequeue();
                return (dequeuedOperation.Value, false);
            }
            else
            {
                _operations.First().ProcessingCyclesLeft--;
                return (0, false);
            }
        }
    }
}
