using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LobbyWars.Application.Commands.Extensions;
using LobbyWars.Application.Interfaces;
using LobbyWars.Domain.Contracts;
using MediatR;

namespace LobbyWars.Application.Commands
{
    /// <summary>
    /// GetMinimumSignatureNecessaryToWin command class.
    /// </summary>
    public class GetMinimumSignatureNecessaryToWinHandler : IRequestHandler<GetMinimumSignatureNecessaryToWin, string>
    {
        private readonly IMininumSignatureQuery queryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMinimumSignatureNecessaryToWinHandler"/> class.
        /// </summary>
        /// <param name="query">IWinnerContractQuery object.</param>
        public GetMinimumSignatureNecessaryToWinHandler(IMininumSignatureQuery query)
        {
            this.queryRepository = query ?? throw new ArgumentNullException(nameof(query));
        }

        /// <inheritdoc/>
        public Task<string> Handle(GetMinimumSignatureNecessaryToWin request, CancellationToken cancellationToken)
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
        /// <param name="request">GetMinimumSignatureNecessaryToWin object.</param>
        /// <returns>Contract winner.</returns>
        private string GetResult(GetMinimumSignatureNecessaryToWin request)
        {
            // Check if the contracts are the same.
            if (request.IsSameContracts())
            {
                return string.Empty;
            }

            // Get contract objects.
            var contractIncompleted = new Contract(request.ContractWithIncompletedSignature());
            var contractCompleted = new Contract(request.ContractWithFullSignature());

            // Get points of each contract.
            int contractUncompletedPoints = this.queryRepository.GetPoints(contractIncompleted);
            int contractCompletedPoints = this.queryRepository.GetPoints(contractCompleted);

            // Compare and return the result.
            if (contractUncompletedPoints < contractCompletedPoints)
            {
                // Get variance and increase by 1 so that the result is not the same
                var variance = contractCompletedPoints - contractUncompletedPoints + 1;

                // If the contract has a king role signature, we increase the difference by 1 to avoid the validator role.
                if (contractIncompleted.ContainsRoleKing() && variance <= 1)
                {
                    variance++;
                }

                string result;
                switch (variance)
                {
                    case (int)SignatureRole.King:
                        result = "K";
                        break;
                    case >= (int)SignatureRole.Notary:
                        result = "N";
                        break;
                    case >= (int)SignatureRole.Validator:
                        result = "V";
                        break;
                    default:
                        result = "It is not possible to overcome the contract with any signature.";
                        break;
                }

                return result;
            }
            else
            {
                return "The contract with incomplete signatures has a higher score, no additional signature is necessary.";
            }
        }
    }
}
