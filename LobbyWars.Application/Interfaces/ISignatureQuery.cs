using LobbyWars.Domain.Contracts;

namespace LobbyWars.Application.Interfaces
{
    /// <summary>
    /// IContractQuery class.
    /// </summary>
    public interface ISignatureQuery
    {
        /// <summary>
        /// Get contract points.
        /// </summary>
        /// <param name="contract">Contract object.</param>
        /// <returns>Points.</returns>
        int GetPoints(Contract contract);
    }
}
