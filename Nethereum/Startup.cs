using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nethereum;
using Nethereum.Web3;

namespace NethereumSample
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }
        
        public async Task ReturnAccountBalance()
        {
            var infuraApiKey = Configuration["InfuraApiKey"];
            var ethereumAccount = Configuration["EthereumFoundationAccount"];

            if (string.IsNullOrWhiteSpace(infuraApiKey) || string.IsNullOrWhiteSpace(ethereumAccount)) return;

            await Account.GetAccountBalance(infuraApiKey, ethereumAccount);
        }

    }
}
