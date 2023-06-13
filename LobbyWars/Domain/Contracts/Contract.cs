using LobbyWars.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyWars.Domain.Contracts
{
    /// <summary>
    /// Contract class.
    /// </summary>
    public class Contract
    {
        private readonly string contract;
        private List<Signature> signatures;

        /// <summary>
        /// Initializes a new instance of the <see cref="Contract"/> class.
        /// </summary>
        /// <param name="contract">Contract value.</param>
        public Contract(string contract)
            : this()
        {
            // We validate that a blank or null string doesn't arrive.
            this.contract = string.IsNullOrWhiteSpace(contract) ? throw new ArgumentNullException(nameof(contract)) : contract;

            // We validate that the string has the characters allowed for signatures.
            ValidateInpuntContract.ValidateContractInput(contract);

            // We get the signatures on the contract.
            this.ConvertContractToSignatures();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contract"/> class.
        /// </summary>
        protected Contract()
        {
            this.signatures = new List<Signature>();
        }

        /// <summary>
        /// Gets contract value.
        /// </summary>
        public string GetContract => this.contract;

        /// <summary>
        /// Gets signatures item.
        /// </summary>
        public IReadOnlyCollection<Signature> GetSignatures => this.signatures;

        /// <summary>
        /// Method that gets all the signatures of the contract.
        /// </summary>
        private void ConvertContractToSignatures()
        {
            var chars = this.contract.ToCharArray();
            foreach (var ch in chars)
            {
                this.signatures.Add(new Signature(ch));
            }
        }
    }
}
