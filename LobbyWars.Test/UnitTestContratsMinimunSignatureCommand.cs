using LobbyWars.Application.Commands;
using LobbyWars.Application.Interfaces;
using LobbyWars.Domain.Contracts;
using LobbyWars.Infrastructure.Queries;
using MediatR;
using Moq;
using Newtonsoft.Json;
using System.Diagnostics;
using Xunit.Abstractions;

namespace LobbyWars.Test
{
    /// <summary>
    /// UnitTestContratsCommand class.
    /// </summary>
    public class UnitTestContratsMinimunSignatureCommand
    {
        private readonly ITestOutputHelper output;
        private readonly Mock<IMediator> mediatorMock;
        private readonly Mock<ISignatureQuery> queryRepository;
        private readonly GetMinimumSignatureNecessaryToWinHandler commandHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestContratsMinimunSignatureCommand"/> class.
        /// </summary>
        /// <param name="output">ITestOutputHelper object.</param>
        public UnitTestContratsMinimunSignatureCommand(ITestOutputHelper outputHelper)
        {
            this.output = outputHelper;

            // Mock
            this.mediatorMock = new Mock<IMediator>();
            this.queryRepository = new Mock<ISignatureQuery>();

            // Setup IContractQuery interface
            var query = new SignatureQuery();
            this.queryRepository.Setup(s => s.GetPoints(It.IsAny<Contract>()))
                                .Returns<Contract>(contract => query.GetPoints(contract));

            // Command handler
            this.commandHandler = new GetMinimumSignatureNecessaryToWinHandler(this.queryRepository.Object);

            // Setup mediator
            this.mediatorMock.Setup(m => m.Send(It.IsAny<GetMinimumSignatureNecessaryToWin>(), It.IsAny<CancellationToken>()))
                        .Returns<GetMinimumSignatureNecessaryToWin, CancellationToken>(async (command, token) => await commandHandler.Handle(command, token));
        }

        [Fact]
        public void GetMinimumSignatureNecessaryContract()
        {
            string contract1 = "NN#V";
            string contract2 = "KNVV";
            var command = new GetMinimumSignatureNecessaryToWin()
                            { 
                                Contract1 = contract1,
                                Contract2 = contract2,
                            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            var result = this.mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
            Assert.True(result == "K");
            this.output.WriteLine(result);
        }

        [Fact]
        public void GetMinimumSignatureNecessaryNotFound()
        {
            string contract1 = "K#N";
            string contract2 = "KKK";
            var command = new GetMinimumSignatureNecessaryToWin()
            {
                Contract1 = contract1,
                Contract2 = contract2,
            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            var result = this.mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
            Assert.True(result == "Minimal signature not found.");
            this.output.WriteLine(result);
        }

        [Fact]
        public void ContractShouldHaveSameLength()
        {
            string contract1 = "N#V";
            string contract2 = "NVVV";
            var command = new GetMinimumSignatureNecessaryToWin()
            {
                Contract1 = contract1,
                Contract2 = contract2,
            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            //Assert
            var exception = Assert.Throws<Exception>(
                   () => this.mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult());
            Assert.True(exception.Message == "Contracts must have the same length.");
        }

        [Fact]
        public void ContractShouldRequireJustOneHashtag()
        {
            string contract1 = "N#V";
            string contract2 = "N#V";
            var command = new GetMinimumSignatureNecessaryToWin()
            {
                Contract1 = contract1,
                Contract2 = contract2,
            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            //Assert
            var exception = Assert.Throws<Exception>(
                   () => this.mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult());
            Assert.True(exception.Message == "Only one signature of a contract can be empty.");
        }

        [Fact]
        public void ContractShouldRequireHashtag()
        {
            string contract1 = "NNV";
            string contract2 = "NVV";
            var command = new GetMinimumSignatureNecessaryToWin()
            {
                Contract1 = contract1,
                Contract2 = contract2,
            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            //Assert
            var exception = Assert.Throws<Exception>(
                   () => this.mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult());
            Assert.True(exception.Message == "Some of the contracts must have an empty signature.");
        }
    }
}
