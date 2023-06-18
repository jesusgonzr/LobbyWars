using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LobbyWars.Application.Commands.Helpers;
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
            ContractsTools.CheckCommandRequest(request);
        }

        /// <summary>
        /// Check if the contracts are the same.
        /// </summary>
        /// <param name="request">>GetWinnerContract object.</param>
        /// <returns>True or false.</returns>
        public static bool IsSameContracts(this GetWinnerContract request)
        {
            return ContractsTools.IsSameContracts(request);
        }
    }
}
