using System;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth;
using Nethereum.HdWallet;
using System.Numerics;
using Nethereum.RPC.Eth.DTOs;

namespace NethereumSample
{
    public class EthTransaction
    {
        private const decimal _gasToTransact = 1.11m;//2GWei

        private const int _gasToSpend = 25000;

        public static async Task<TransactionReceipt> CreateSimpleTransaction(string privateKey, string address)
        {
            var account = new Account(privateKey);

            var web3 = new Web3(account);


            var ethService = web3.Eth.GetEtherTransferService();

            var transactionReceipt = await ethService.TransferEtherAndWaitForReceiptAsync(address, _gasToTransact, 2);

            return transactionReceipt;
        }

        public static async Task<TransactionReceipt> CreateHdWalletTransaction(string address, string passphrase, string password)
        {
            var wallet = new Wallet(passphrase, password);
            var account = wallet.GetAccount(0);
            var web3 = new Web3(account);


            var ethService = web3.Eth.GetEtherTransferService();
            var transaction = await ethService
                                .TransferEtherAndWaitForReceiptAsync(address,                   _gasToTransact, 2, _gasToSpend);

            return transaction;
        }
    }
}
