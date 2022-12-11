using day11;

var monkeys = Monkey.MonkeyFactory_MyInput();
var monkeyBusiness = new MonkeyBusiness(monkeys);

var testableValues = monkeys.Select(x => x.TestDivisibleBy);
long finalValue = 1;
foreach (var value in testableValues)
{
    finalValue = value * finalValue;
}
var superModulo = finalValue;

var rounds = 10000;

for(int i = 1; i <= rounds; i++)
{
    monkeyBusiness.ExecuteRound(superModulo);
    if(i == 1 || i == 20 || i % 1000 == 0)
    {
        Console.WriteLine($@"Printing stats after {i} rounds");
        monkeyBusiness.PrintItemsInspected();
    }
}

Console.WriteLine($@"Total monkey business: {monkeyBusiness.CurrentMonkeyBusiness()}");