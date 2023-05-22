using Microsoft.Extensions.Configuration;
using NethereumSample;



var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();


var startup = new Startup(config);
//await startup.ReturnAccountBalance();
var transaction = await startup.CreateSimpleTransaction();
var walletReceipt = await startup.CreateHdWalletTransaction();

Console.WriteLine($"Hello, {config["InfuraApiKey"]}");