using LobbyWars.Application.Interfaces;
using LobbyWars.Domain.Contracts;

namespace LobbyWars.Infrastructure.Queries
{
    /// <summary>
    /// ContractQuery class.
    /// </summary>
    public class SignatureQuery : ISignatureQuery
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
