using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyWars.Application.Commands
{
    /// <summary>
    /// Basecommand class.
    /// </summary>
    public abstract class BaseCommand
    {
        /// <summary>
        /// Gets or sets contract number one.
        /// </summary>
        public string Contract1 { get; set; }

        /// <summary>
        /// Gets or sets contract nuber two.
        /// </summary>
        public string Contract2 { get; set; }
    }
}
