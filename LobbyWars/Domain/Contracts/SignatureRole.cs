using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyWars.Domain.Contracts
{
    /// <summary>
    /// Tipos de rol de las firmas.
    /// </summary>
    public enum SignatureRole
    {
        /// <summary>
        /// Empty (#)
        /// </summary>
        Empty = 0,

        /// <summary>
        /// Validator
        /// </summary>
        Validator = 1,

        /// <summary>
        /// Notary
        /// </summary>
        Notary = 2,

        /// <summary>
        /// King
        /// </summary>
        King = 5,
    }
}
