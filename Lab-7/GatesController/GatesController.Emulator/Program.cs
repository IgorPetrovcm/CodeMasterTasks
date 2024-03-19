using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole(options =>
    {
    });
});

var logger = loggerFactory.CreateLogger("Emulator");
logger.LogInformation("Starting gates controlling emulator...");
logger.LogInformation(@"
================================
      PRESS ENTER TO STOP
================================
");

const int gatesCount = 5;

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
CancellationToken cancellationToken = cancellationTokenSource.Token;
HttpClient httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7280"),
};

Task[] emulatorThreads = Enumerable
    .Range(1, gatesCount)
    .Select(gateIndex => Task.Run(async () =>
    {
        logger.LogInformation("Gate {GateIndex}: starting emulator thread", gateIndex);

        Random random = new Random();

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(random.Next(1000, 5000), cancellationToken);

                logger.LogInformation("Gate {GateIndex}: sending open request", gateIndex);

                await httpClient.GetAsync($"api/request/open/{gateIndex}");

                logger.LogInformation("Gate {GateIndex}: open request completed", gateIndex);

                int visitorsCount = random.Next(10, 20);

                Task[] visitors = Enumerable
                    .Range(1, visitorsCount)
                    .Select(_ => Task.Run(async () =>
                    {
                        logger.LogInformation("Gate {GateIndex}: visitor enters", gateIndex);
                        await httpClient.GetAsync($"api/enter/{gateIndex}");

                        await Task.Delay(random.Next(1000, 3000), cancellationToken);
                        logger.LogInformation("Gate {GateIndex}: visitor leaves", gateIndex);
                        await httpClient.GetAsync($"api/leave/{gateIndex}");
                    }))
                    .ToArray();

                await Task.WhenAll(visitors);

                logger.LogInformation("Gate {GateIndex}: sending close request", gateIndex);

                await httpClient.GetAsync($"api/request/close/{gateIndex}");

                logger.LogInformation("Gate {GateIndex}: close request completed", gateIndex);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Gate {GateIndex}: an error while iteration execution", gateIndex);
            }
        }
    }))
    .ToArray();

Console.ReadLine();

cancellationTokenSource.Cancel();

await Task.WhenAll(emulatorThreads);