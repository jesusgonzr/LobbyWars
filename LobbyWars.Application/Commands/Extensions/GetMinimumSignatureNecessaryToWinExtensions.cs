using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LobbyWars.Application.Commands.Helpers;
using LobbyWars.Domain.Contracts;

namespace LobbyWars.Application.Commands.Extensions
{
    /// <summary>
    /// GetMinimumSignatureNecessaryToWinExtensions class.
    /// </summary>
    public static class GetMinimumSignatureNecessaryToWinExtensions
    {
        /// <summary>
        /// Chech commmand value.
        /// </summary>
        /// <param name="request">GetMinimumSignatureNecessaryToWin object.</param>
        public static void CheckCommandRequest(this GetMinimumSignatureNecessaryToWin request)
        {
            ContractsTools.CheckCommandRequest(request);

            if (request.Contract1.Length != request.Contract2.Length)
            {
                throw new Exception("Contracts must have the same length.");
            }

            if (request.Contract1.Contains('#') && request.Contract2.Contains('#'))
            {
                throw new Exception("Only one signature of a contract can be empty.");
            }

            if (!request.Contract1.Contains('#') && !request.Contract2.Contains('#'))
            {
                throw new Exception("Some of the contracts must have an empty signature.");
            }
        }

        /// <summary>
        /// Check if the contracts are the same.
        /// </summary>
        /// <param name="request">>GetMinimumSignatureNecessaryToWin object.</param>
        /// <returns>True or false.</returns>
        public static bool IsSameContracts(this GetMinimumSignatureNecessaryToWin request)
        {
            return ContractsTools.IsSameContracts(request);
        }

        /// <summary>
        /// Obtains the contract with the incomplete signature.
        /// </summary>
        /// <param name="request">GetMinimumSignatureNecessaryToWin object.</param>
        /// <returns>The contract with the incomplete signature.</returns>
        public static string ContractWithIncompletedSignature(this GetMinimumSignatureNecessaryToWin request)
        {
            if (request.Contract1.Contains('#'))
            {
                return request.Contract1;
            }
            else
            {
                return request.Contract2;
            }
        }

        /// <summary>
        /// Obtains the contract with the full signature.
        /// </summary>
        /// <param name="request">GetMinimumSignatureNecessaryToWin object.</param>
        /// <returns>The contract with the full signature.</returns>
        public static string ContractWithFullSignature(this GetMinimumSignatureNecessaryToWin request)
        {
            if (!request.Contract1.Contains('#'))
            {
                return request.Contract1;
            }
            else
            {
                return request.Contract2;
            }
        }
    }
}
