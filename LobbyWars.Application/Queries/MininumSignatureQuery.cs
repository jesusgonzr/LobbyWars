using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LobbyWars.Application.Interfaces;
using LobbyWars.Domain.Contracts;

namespace LobbyWars.Application.Queries
{
    /// <summary>
    /// MininumSignatureQuery class.
    /// </summary>
    public class MininumSignatureQuery : IMininumSignatureQuery
    {
        /// <inheritdoc/>
        public int GetPoints(Contract contract)
        {
            if (contract.ContainsRoleKing())
            {
                return contract.GetSignatures.Where(c => c.GetSignatureRoleValue != SignatureRole.Validator).Select(s => s.GetRoleValue).Sum();
            }
            else
            {
                return contract.GetSignatures.Select(s => s.GetRoleValue).Sum();
            }
        }
    }
}
