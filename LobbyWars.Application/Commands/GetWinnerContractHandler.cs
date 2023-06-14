using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LobbyWars.Application.Commands.Extensions;
using LobbyWars.Application.Interfaces;
using LobbyWars.Domain.Contracts;
using MediatR;

namespace LobbyWars.Application.Commands
{
    /// <summary>
    /// GetWinnerContract command class.
    /// </summary>
    public class GetWinnerContractHandler : IRequestHandler<GetWinnerContract, string>
    {
        private readonly IWinnerContractQuery queryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWinnerContractHandler"/> class.
        /// </summary>
        /// <param name="query">IWinnerContractQuery object.</param>
        public GetWinnerContractHandler(IWinnerContractQuery query)
        {
            this.queryRepository = query ?? throw new ArgumentNullException(nameof(query));
        }

        /// <inheritdoc/>
        public Task<string> Handle(GetWinnerContract request, CancellationToken cancellationToken)
        {
            // Check request value.
            request.CheckCommandRequest();

            // Return results.
            return Task.Run(() =>
            {
                return this.GetResult(request);
            });
        }

        /// <summary>
        /// Compare contracts and return the result.
        /// </summary>
        /// <param name="request">GetWinnerContract object.</param>
        /// <returns>Contract winner.</returns>
        private string GetResult(GetWinnerContract request)
        {
            // Check if the contracts are the same.
            if (request.IsSameContracts())
            {
                return string.Empty;
            }

            // Get contract objects.
            var contract1 = new Contract(request.Contract1);
            var contract2 = new Contract(request.Contract2);

            // Get points of each contract.
            int contract1Point = this.queryRepository.GetPoints(contract1);
            int contract2Point = this.queryRepository.GetPoints(contract2);

            // Compare and return the result.
            if (contract1Point > contract2Point)
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
