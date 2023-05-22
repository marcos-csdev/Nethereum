using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nethereum;
using Nethereum.RPC.Eth.DTOs;
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

            await WalletAccount.GetAccountBalance(infuraApiKey, ethereumAccount);
        }

        public async Task<TransactionReceipt> CreateSimpleTransaction()
        {
            var privateKey = Configuration["privateKey"];
            var address = Configuration["recipientAddress"];

            if (string.IsNullOrWhiteSpace(privateKey) || string.IsNullOrWhiteSpace(address)) return null!;

            var transactionReceipt = await EthTransaction.CreateSimpleTransaction(privateKey, address);

            return transactionReceipt;
        }
        public async Task<TransactionReceipt> CreateHdWalletTransaction()
        {
            var address = Configuration["recipientAddress"];
            var passphrase = Configuration["passphrase"];
            var password = Configuration["password"];

            if (string.IsNullOrWhiteSpace(passphrase) ||string.IsNullOrWhiteSpace(password) || 
                string.IsNullOrWhiteSpace(address)) return null!;

            var transactionReceipt = await EthTransaction.CreateHdWalletTransaction(address, passphrase, password);

            return transactionReceipt;
        }

    }
}
