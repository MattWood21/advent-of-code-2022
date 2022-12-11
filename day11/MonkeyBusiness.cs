using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day11
{
    public class MonkeyBusiness
    {
        private List<Monkey> _monkeys { get; set; } = new List<Monkey>();

        public MonkeyBusiness(IEnumerable<Monkey> monkeys)
        {
            _monkeys = monkeys.ToList();
        }

        public void ExecuteRound()
        {
            var counter = 0;
            foreach (var monkey in _monkeys)
            {
                Console.WriteLine($@"Monkey {counter} turn is starting");
                var result = monkey.Go();
                Console.WriteLine($@"Inspected {result.Count()} items. Sum of inspected items: {monkey.ItemsInspected}");
                foreach (var item in result)
                {
                    Console.WriteLine($@"Monkey is throwing item {item.worry} to Monkey {item.targetMonkey}");
                    _monkeys[item.targetMonkey].AddItem(item.worry);
                }
                counter++;
            }
        }

        public long CurrentMonkeyBusiness() 
        {
            var sortedMonkeys = _monkeys.OrderByDescending(x => x.ItemsInspected).ToList();
            return sortedMonkeys[0].ItemsInspected * sortedMonkeys[1].ItemsInspected;
        }
    }
}
