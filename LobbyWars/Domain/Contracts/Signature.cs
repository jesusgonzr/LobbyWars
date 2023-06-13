using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyWars.Domain.Contracts
{
    /// <summary>
    /// Signature class.
    /// </summary>
    public class Signature
    {
        private readonly char signature;

        /// <summary>
        /// Initializes a new instance of the <see cref="Signature"/> class.
        /// </summary>
        /// <param name="signature">Signature value.</param>
        public Signature(char signature)
            : this()
        {
            this.signature = signature;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Signature"/> class.
        /// </summary>
        protected Signature()
        {
        }

        /// <summary>
        /// Gets role value in string.
        /// </summary>
        public string GetStringValue => this.signature.ToString();

        /// <summary>
        /// Gets role value in integer.
        /// </summary>
        public int GetRoleValue => (int)ConvertToSignatureRole(this.signature);

        /// <summary>
        /// Gets role value.
        /// </summary>
        public SignatureRole GetSignatureRoleValue => ConvertToSignatureRole(this.signature);

        /// <summary>
        /// Convert char to signature Role.
        /// </summary>
        /// <param name="value">Value char.</param>
        /// <returns>SignatureRole object.</returns>
        private static SignatureRole ConvertToSignatureRole(char value)
        {
            return value.ToString().ToUpper() switch
            {
                "N" => SignatureRole.Notary,
                "V" => SignatureRole.Validator,
                "K" => SignatureRole.King,
                _ => throw new ArgumentOutOfRangeException($"{value} is not valid."),
            };
        }
    }
}
