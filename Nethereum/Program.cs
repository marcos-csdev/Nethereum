using Microsoft.Extensions.Configuration;
using NethereumSample;



var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();


var startup = new Startup(config);
await startup.ReturnAccountBalance();

Console.WriteLine($"Hello, {config["InfuraApiKey"]}");