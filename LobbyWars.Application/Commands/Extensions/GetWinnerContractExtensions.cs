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
            return request.Contract1 == request.Contract2;
        }
    }
}
