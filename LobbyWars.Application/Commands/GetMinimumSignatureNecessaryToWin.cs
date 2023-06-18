using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LobbyWars.Application.Commands
{
    /// <summary>
    /// GetMinimumSignatureNecessaryToWin model class.
    /// </summary>
    public class GetMinimumSignatureNecessaryToWin : BaseCommand, IRequest<string>
    {
    }
}
