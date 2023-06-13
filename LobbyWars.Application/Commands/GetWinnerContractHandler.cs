using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LobbyWars.Application.Commands
{
    /// <summary>
    /// GetWinnerContract command class.
    /// </summary>
    public class GetWinnerContractHandler : IRequestHandler<GetWinnerContract, string>
    {
        /// <inheritdoc/>
        public Task<string> Handle(GetWinnerContract request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
