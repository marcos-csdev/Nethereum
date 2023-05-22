using Nethereum.Hex.HexConvertors.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Signer;
using Nethereum.Web3.Accounts;

namespace NethereumSample
{
    public class NethereumAccount
    {
        public static Account GenerateNewAccount()
        {
            var ecKey = EthECKey.GenerateKey();
            var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
            var account = new Account(privateKey);

            return account;
        }
    }
}
