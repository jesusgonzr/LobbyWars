using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrEmpty(request.Contract1))
            {
                throw new ArgumentNullException(nameof(request.Contract1));
            }

            if (string.IsNullOrEmpty(request.Contract2))
            {
                throw new ArgumentNullException(nameof(request.Contract2));
            }

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
            char[] arrayCadena1 = request.Contract1.ToUpper().ToCharArray();
            char[] arrayCadena2 = request.Contract2.ToUpper().ToCharArray();

            Array.Sort(arrayCadena1);
            Array.Sort(arrayCadena2);

            return Enumerable.SequenceEqual(arrayCadena1, arrayCadena2);
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
