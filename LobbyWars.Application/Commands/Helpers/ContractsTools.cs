using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyWars.Application.Commands.Helpers
{
    /// <summary>
    /// ContractsTools class.
    /// </summary>
    public static class ContractsTools
    {
        /// <summary>
        /// Chech common commmand value.
        /// </summary>
        /// <param name="request">BaseCommand object.</param>
        public static void CheckCommandRequest(BaseCommand request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrEmpty(request.Contract1))
            {
                throw new ArgumentNullException(nameof(request.Contract1));
            }

            if (string.IsNullOrEmpty(request.Contract2))
            {
                throw new ArgumentNullException(nameof(request.Contract2));
            }
        }

        /// <summary>
        /// Check if the contracts are the same.
        /// </summary>
        /// <param name="request">>BaseCommand object.</param>
        /// <returns>True or false.</returns>
        public static bool IsSameContracts(BaseCommand request)
        {
            char[] arrayCadena1 = request.Contract1.ToUpper().ToCharArray();
            char[] arrayCadena2 = request.Contract2.ToUpper().ToCharArray();

            Array.Sort(arrayCadena1);
            Array.Sort(arrayCadena2);

            return Enumerable.SequenceEqual(arrayCadena1, arrayCadena2);
        }
    }
}
