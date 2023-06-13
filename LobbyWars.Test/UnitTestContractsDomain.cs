using LobbyWars.Domain.Contracts;
using Newtonsoft.Json;
using System.Diagnostics;
using Xunit.Abstractions;

namespace LobbyWars.Test
{
    /// <summary>
    /// UnitTestContractsDomain class.
    /// </summary>
    public class UnitTestContractsDomain
	{
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestContractsDomain"/> class.
        /// </summary>
        /// <param name="output">ITestOutputHelper object.</param>
        public UnitTestContractsDomain(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
		public void AddContract()
		{
            // Create new object.
            var result = new Contract("KN");

            // Check result.
            Assert.NotNull(result);
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void CheckSignaturesNumberContract()
        {
            string contract = "KN";

            // Create new object.
            var result = new Contract(contract);

            // Check result.
            Assert.True(result.GetSignatures.Count == contract.ToCharArray().Length);
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void CheckSignaturesValueContract()
        {
            string contract = "KN";

            // Create new object.
            var result = new Contract(contract);

            // Check result.
            foreach (var item in contract.ToCharArray())
            {
                var data = result.GetSignatures.Where(c => c.GetStringValue == item.ToString().ToUpper()).FirstOrDefault();
                Assert.NotNull(data);
            }
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void AddContract_Whith_String_NotValid()
        {
            var exception = Assert.Throws<ArgumentException>(
                   () => new Contract("NGK"));
            Assert.True(exception.Message == "Invalid input. Only 'K', 'N', 'V', and '#' characters are allowed.");
            this.output.WriteLine(exception.Message);
        }
    }
}