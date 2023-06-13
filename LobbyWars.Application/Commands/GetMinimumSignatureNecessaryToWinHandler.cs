using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LobbyWars.Application.Commands
{
    /// <summary>
    /// GetMinimumSignatureNecessaryToWin command class.
    /// </summary>
    public class GetMinimumSignatureNecessaryToWinHandler : IRequestHandler<GetMinimumSignatureNecessaryToWin, string>
    {
        /// <inheritdoc/>
        public Task<string> Handle(GetMinimumSignatureNecessaryToWin request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
