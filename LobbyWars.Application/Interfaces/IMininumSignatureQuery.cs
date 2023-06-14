using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LobbyWars.Domain.Contracts;

namespace LobbyWars.Application.Interfaces
{
    /// <summary>
    /// IMininumSignatureQuery interface.
    /// </summary>
    public interface IMininumSignatureQuery
    {
        /// <summary>
        /// Get contract points.
        /// </summary>
        /// <param name="contract">Contract object.</param>
        /// <returns>Points.</returns>
        int GetPoints(Contract contract);
    }
}
