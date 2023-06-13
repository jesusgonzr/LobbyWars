using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LobbyWars.Domain.Helpers
{
    /// <summary>
    /// ValidateInpuntContract class.
    /// </summary>
    public static class ValidateInpuntContract
    {
        /// <summary>
        /// Check that the string has the characters allowed for signatures.
        /// </summary>
        /// <param name="input">String value.</param>
        /// <exception cref="ArgumentException">Invalid input.</exception>
        public static void ValidateContractInput(string input)
        {
            string pattern = @"^[KNV#]+$";
            if (!Regex.IsMatch(input, pattern))
            {
                throw new ArgumentException("Invalid input. Only 'K', 'N', 'V', and '#' characters are allowed.");
            }
        }
    }
}
