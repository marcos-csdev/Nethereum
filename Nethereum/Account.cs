using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Web3;

namespace NethereumSample
{
    public class Account
    {
        public static async Task GetAccountBalance(string apiKey, string ethereumAccount)
        {
            var url = $"https://mainnet.infura.io/v3/{apiKey}";
            var web3 = new Web3(url);

            var balance = web3.Eth.GetBalance;

            var response = await balance.SendRequestAsync(ethereumAccount);
            Console.WriteLine($"Balance in Wei: {response.Value}");

            var etherAmount = Web3.Convert.FromWei(response.Value);
            Console.WriteLine($"Balance in Ether: {etherAmount}");
        }
    }
}
