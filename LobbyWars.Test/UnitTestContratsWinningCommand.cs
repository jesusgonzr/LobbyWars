using LobbyWars.Application.Commands;
using LobbyWars.Application.Interfaces;
using LobbyWars.Application.Queries;
using LobbyWars.Domain.Contracts;
using MediatR;
using Moq;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace LobbyWars.Test
{
    /// <summary>
    /// UnitTestContratsCommand class.
    /// </summary>
    public class UnitTestContratsWinningCommand
    {
        private readonly ITestOutputHelper output;
        private readonly Mock<IMediator> mediatorMock;
        private readonly Mock<IWinnerContractQuery> winnerContractQueryMock;
        private readonly GetWinnerContractHandler commandHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestContratsWinningCommand"/> class.
        /// </summary>
        /// <param name="output">ITestOutputHelper object.</param>
        public UnitTestContratsWinningCommand(ITestOutputHelper outputHelper)
        {
            this.output = outputHelper;

            // Mock
            this.mediatorMock = new Mock<IMediator>();
            this.winnerContractQueryMock = new Mock<IWinnerContractQuery>();

            // Setup IWinnerContractQuery interface
            var query = new WinnerContractQuery();
            this.winnerContractQueryMock.Setup(s => s.GetPoints(It.IsAny<Contract>()))
                .Returns<Contract>(contract => query.GetPoints(contract));

            // Command handler
            this.commandHandler = new GetWinnerContractHandler(this.winnerContractQueryMock.Object);

            // Setup mediator
            this.mediatorMock.Setup(m => m.Send(It.IsAny<GetWinnerContract>(), It.IsAny<CancellationToken>()))
                        .Returns<GetWinnerContract, CancellationToken>(async (command, token) => await commandHandler.Handle(command, token));
        }

        [Fact]
        public void Contract1WiningToContract2()
        {
            string contract1 = "KN";
            string contract2 = "NNV";
            var command = new GetWinnerContract()
                            { 
                                Contract1 = contract1,
                                Contract2 = contract2,
                            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            var result = this.mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
            Assert.True(result == contract1);
            this.output.WriteLine(result);
        }

        [Fact]
        public void Contract2WiningToContract1()
        {
            string contract1 = "NVV";
            string contract2 = "NNV";
            var command = new GetWinnerContract()
            {
                Contract1 = contract1,
                Contract2 = contract2,
            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            var result = this.mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
            Assert.True(result == contract2);
            this.output.WriteLine(result);
        }

        [Fact]
        public void ContractsIsSame()
        {
            string contract1 = "NNV";
            string contract2 = "NNV";
            var command = new GetWinnerContract()
            {
                Contract1 = contract1,
                Contract2 = contract2,
            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            var result = this.mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
            Assert.True(result == string.Empty);
            this.output.WriteLine(result);
        }
    }
}
