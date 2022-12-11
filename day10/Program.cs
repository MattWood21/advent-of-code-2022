using day10;

var inputData = File.ReadAllLines("input.txt");
var operations = Operation.BuildBulk(inputData);
var processor = new Processor(operations.Count());
processor.AddOperationsBulk(operations);

List<int> interestingValues = new List<int>();
var x = 1;
var cycle = 1;
var crt = new CRT();
while(true)
{
    var returnedValue = processor.Process();
    if(returnedValue.end)
    {
        break;
    }

    crt.Process(cycle, x);

    if (cycle - 20 == 0 || (cycle - 20) % 40 == 0)
    {
        Console.WriteLine($@"Interesting Cycle: {cycle} X: {x}");
        var signalStrength = cycle * x;
        Console.WriteLine($@"SignalStrength: {signalStrength}");
        interestingValues.Add(signalStrength);
        Console.WriteLine($@"Sum of signal strength so far: {interestingValues.Sum()}");
    }
    else
    {
        Console.WriteLine($@"Boring Cycle: {cycle} X: {x}");
    }
    cycle++;
    x += returnedValue.value;
}

Console.Write(crt.Draw());

Console.Write($@"Sum of interesting signals was {interestingValues.Sum()}");