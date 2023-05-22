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
        protected readonly Serilog.ILogger _logger;
        public IConfigurationRoot Configuration { get; }
        public Startup(IConfigurationRoot configuration, Serilog.ILogger logger)
        {
            Configuration = configuration;
            _logger = logger;
        }
        
        public async Task ReturnAccountBalance()
        {
            try
            {
                var infuraApiKey = Configuration["InfuraApiKey"];
                var ethereumAccount = Configuration["EthereumFoundationAccount"];

                if (string.IsNullOrWhiteSpace(infuraApiKey) || string.IsNullOrWhiteSpace(ethereumAccount)) return;

                await WalletAccount.GetAccountBalance(infuraApiKey, ethereumAccount);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<TransactionReceipt> CreateSimpleTransaction()
        {
            try
            {
                var privateKey = Configuration["privateKey"];
                var address = Configuration["recipientAddress"];

                if (string.IsNullOrWhiteSpace(privateKey) || string.IsNullOrWhiteSpace(address)) return null!;

                var transactionReceipt = await EthTransaction.CreateSimpleTransaction(privateKey, address);

                return transactionReceipt;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return null!;
        }
        public async Task<TransactionReceipt> CreateHdWalletTransaction()
        {
            try
            {
                var address = Configuration["recipientAddress"];
                var passphrase = Configuration["passphrase"];
                var password = Configuration["password"];

                if (string.IsNullOrWhiteSpace(passphrase) || string.IsNullOrWhiteSpace(password) ||
                    string.IsNullOrWhiteSpace(address)) return null!;

                var transactionReceipt = await EthTransaction.CreateHdWalletTransaction(address, passphrase, password);

                return transactionReceipt;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return null!;
        }

    }
}
