using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day11
{
    public class Monkey
    {
        public Queue<long> Items { get; set; } = new Queue<long>();
        public OperationType OperationType { get; set; }
        public int OperationValue { get; set; }
        public int TestDivisibleBy { get; set; }
        public (int targetIfTrue, int targetIfFalse) Targets { get; set; }
        public long ItemsInspected { get; set; } = 0;

        public void AddItem(long itemWorry)
        {
            Items.Enqueue(itemWorry);
        }

        public IEnumerable<(int targetMonkey, long worry)> Go(long supermodulo)
        {
            var results = new List<(int targetMonkey, long worry)>();
            while(Items.Any())
            {
                ItemsInspected++;
                var worry = Items.Dequeue();
                long worryAfterOperation;
                if (OperationType == OperationType.Add)
                {
                    worryAfterOperation = worry + OperationValue;
                }
                else if (OperationType == OperationType.Multiply)
                {
                    worryAfterOperation = worry * OperationValue;
                }
                else if (OperationType == OperationType.Square)
                {
                    worryAfterOperation = worry * worry;
                }
                else
                    throw new NotImplementedException();

                if(worryAfterOperation <= 0)
                {
                    throw new InvalidOperationException();
                }

                if(worryAfterOperation % TestDivisibleBy == 0)
                {
                    results.Add((Targets.targetIfTrue, worryAfterOperation));
                }
                else
                {
                    results.Add((Targets.targetIfFalse, worryAfterOperation % supermodulo));
                }
            }
            return results;
        }

        public static List<Monkey> MonkeyFactory_ExampleInput()
        {
            return new List<Monkey>()
            {
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 79, 98 }),
                    OperationType = OperationType.Multiply,
                    OperationValue = 19,
                    TestDivisibleBy = 23,
                    Targets = (2,3)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 54, 65, 75, 74 }),
                    OperationType = OperationType.Add,
                    OperationValue = 6,
                    TestDivisibleBy = 19,
                    Targets = (2,0)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 79, 60, 97 }),
                    OperationType = OperationType.Square,
                    OperationValue = 0,
                    TestDivisibleBy = 13,
                    Targets = (1,3)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 74 }),
                    OperationType = OperationType.Add,
                    OperationValue = 3,
                    TestDivisibleBy = 17,
                    Targets = (0,1)
                },
            };
        }

        public static List<Monkey> MonkeyFactory_MyInput()
        {
            return new List<Monkey>()
            {
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 63, 57 }),
                    OperationType = OperationType.Multiply,
                    OperationValue = 11,
                    TestDivisibleBy = 7,
                    Targets = (6,2)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 82, 66, 87, 78, 77, 92, 83 }),
                    OperationType = OperationType.Add,
                    OperationValue = 1,
                    TestDivisibleBy = 11,
                    Targets = (5,0)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 97, 53, 53, 85, 58, 54 }),
                    OperationType = OperationType.Multiply,
                    OperationValue = 7,
                    TestDivisibleBy = 13,
                    Targets = (4,3)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 50 }),
                    OperationType = OperationType.Add,
                    OperationValue = 3,
                    TestDivisibleBy = 3,
                    Targets = (1,7)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 64, 69, 52, 65, 73 }),
                    OperationType = OperationType.Add,
                    OperationValue = 6,
                    TestDivisibleBy = 17,
                    Targets = (3,7)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 57, 91, 65 }),
                    OperationType = OperationType.Add,
                    OperationValue = 5,
                    TestDivisibleBy = 2,
                    Targets = (0,6)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 67, 91, 84, 78, 60, 69, 99, 83 }),
                    OperationType = OperationType.Square,
                    OperationValue = 0,
                    TestDivisibleBy = 5,
                    Targets = (2,4)
                },
                new Monkey()
                {
                    Items = new Queue<long>(new long[] { 58, 78, 69, 65 }),
                    OperationType = OperationType.Add,
                    OperationValue = 7,
                    TestDivisibleBy = 19,
                    Targets = (5,1)
                },
            };
        }
        
    }
}
