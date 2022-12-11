using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day11
{
    public class Monkey
    {
        public Queue<int> Items { get; set; } = new Queue<int>();
        public OperationType OperationType { get; set; }
        public int OperationValue { get; set; }
        public int TestDivisibleBy { get; set; }
        public (int targetIfTrue, int targetIfFalse) Targets { get; set; }
        public int ItemsInspected { get; set; } = 0;

        public void AddItem(int itemWorry)
        {
            Items.Enqueue(itemWorry);
        }

        public IEnumerable<(int targetMonkey, int worry)> Go()
        {
            var results = new List<(int targetMonkey, int worry)>();
            while(Items.Any())
            {
                ItemsInspected++;
                var worry = Items.Dequeue();
                int worryAfterOperation;
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

                //var worryAfterSafeInspection = worryAfterOperation / 3;
                if(worryAfterOperation % TestDivisibleBy == 0)
                {
                    results.Add((Targets.targetIfTrue, worryAfterOperation));
                }
                else
                {
                    results.Add((Targets.targetIfFalse, worryAfterOperation));
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
                    Items = new Queue<int>(new int[] { 79, 98 }),
                    OperationType = OperationType.Multiply,
                    OperationValue = 19,
                    TestDivisibleBy = 23,
                    Targets = (2,3)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 54, 65, 75, 74 }),
                    OperationType = OperationType.Add,
                    OperationValue = 6,
                    TestDivisibleBy = 19,
                    Targets = (2,0)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 79, 60, 97 }),
                    OperationType = OperationType.Square,
                    OperationValue = 0,
                    TestDivisibleBy = 13,
                    Targets = (1,3)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 74 }),
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
                    Items = new Queue<int>(new int[] { 63, 57 }),
                    OperationType = OperationType.Multiply,
                    OperationValue = 11,
                    TestDivisibleBy = 7,
                    Targets = (6,2)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 82, 66, 87, 78, 77, 92, 83 }),
                    OperationType = OperationType.Add,
                    OperationValue = 1,
                    TestDivisibleBy = 11,
                    Targets = (5,0)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 97, 53, 53, 85, 58, 54 }),
                    OperationType = OperationType.Multiply,
                    OperationValue = 7,
                    TestDivisibleBy = 13,
                    Targets = (4,3)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 50 }),
                    OperationType = OperationType.Add,
                    OperationValue = 3,
                    TestDivisibleBy = 3,
                    Targets = (1,7)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 64, 69, 52, 65, 73 }),
                    OperationType = OperationType.Add,
                    OperationValue = 6,
                    TestDivisibleBy = 17,
                    Targets = (3,7)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 57, 91, 65 }),
                    OperationType = OperationType.Add,
                    OperationValue = 5,
                    TestDivisibleBy = 2,
                    Targets = (0,6)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 67, 91, 84, 78, 60, 69, 99, 83 }),
                    OperationType = OperationType.Square,
                    OperationValue = 0,
                    TestDivisibleBy = 5,
                    Targets = (2,4)
                },
                new Monkey()
                {
                    Items = new Queue<int>(new int[] { 58, 78, 69, 65 }),
                    OperationType = OperationType.Add,
                    OperationValue = 7,
                    TestDivisibleBy = 19,
                    Targets = (5,1)
                },
            };
        }
        
    }
}
