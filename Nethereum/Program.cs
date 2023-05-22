using Microsoft.Extensions.Configuration;
using NethereumSample;
using Serilog;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

using var log = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/nethereum.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();


var startup = new Startup(config, log);
//await startup.ReturnAccountBalance();
var transaction = await startup.CreateSimpleTransaction();
var walletReceipt = await startup.CreateHdWalletTransaction();

Console.WriteLine($"Hello, {config["InfuraApiKey"]}");