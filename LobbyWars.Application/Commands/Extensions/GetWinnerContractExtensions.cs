using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LobbyWars.Domain.Contracts;

namespace LobbyWars.Application.Commands.Extensions
{
    /// <summary>
    /// GetWinnerContractExtensions class.
    /// </summary>
    public static class GetWinnerContractExtensions
    {
        /// <summary>
        /// Chech commmand value.
        /// </summary>
        /// <param name="request">GetWinnerContract object.</param>
        public static void CheckCommandRequest(this GetWinnerContract request)
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
        }

        /// <summary>
        /// Check if the contracts are the same.
        /// </summary>
        /// <param name="request">>GetWinnerContract object.</param>
        /// <returns>True or false.</returns>
        public static bool IsSameContracts(this GetWinnerContract request)
        {
            char[] arrayCadena1 = request.Contract1.ToUpper().ToCharArray();
            char[] arrayCadena2 = request.Contract2.ToUpper().ToCharArray();

            Array.Sort(arrayCadena1);
            Array.Sort(arrayCadena2);

            return Enumerable.SequenceEqual(arrayCadena1, arrayCadena2);
        }
    }
}
