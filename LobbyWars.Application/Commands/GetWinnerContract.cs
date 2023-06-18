using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LobbyWars.Application.Commands
{
    /// <summary>
    /// GetWinnerContract model class.
    /// </summary>
    public class GetWinnerContract : BaseCommand, IRequest<string>
    {
    }
}
