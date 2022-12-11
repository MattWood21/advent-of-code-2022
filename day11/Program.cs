using day11;

var monkeys = Monkey.MonkeyFactory_ExampleInput();
var monkeyBusiness = new MonkeyBusiness(monkeys);
var rounds = 10000;

for(int i = 0; i < rounds; i++)
{
    monkeyBusiness.ExecuteRound();
}

Console.WriteLine($@"Total monkey business: {monkeyBusiness.CurrentMonkeyBusiness()}");