using LobbyWars.Application.Commands;
using MediatR;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace LobbyWars.Test
{
    /// <summary>
    /// UnitTestContratsCommand class.
    /// </summary>
    public class UnitTestContratsWinningCommand
    {
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestContratsWinningCommand"/> class.
        /// </summary>
        /// <param name="output">ITestOutputHelper object.</param>
        public UnitTestContratsWinningCommand(ITestOutputHelper outputHelper)
        {
            this.output = outputHelper;
        }

        [Fact]
        public void Contract1WiningToContract2()
        {
            var mediatorMock = new Mock<IMediator>();
            var commandHandler = new GetWinnerContractHandler();

            mediatorMock.Setup(m => m.Send(It.IsAny<GetWinnerContract>(), It.IsAny<CancellationToken>()))
                        .Returns<GetWinnerContract, CancellationToken>(async (command, token) => await commandHandler.Handle(command, token));

            string contract1 = "KN";
            string contract2 = "NNV";
            var command = new GetWinnerContract()
                            { 
                                Contract1 = contract1,
                                Contract2 = contract2,
                            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            var result = mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
            Assert.True(result == contract1);
            this.output.WriteLine(result);
        }

        [Fact]
        public void Contract2WiningToContract1()
        {
            var mediatorMock = new Mock<IMediator>();
            var commandHandler = new GetWinnerContractHandler();

            mediatorMock.Setup(m => m.Send(It.IsAny<GetWinnerContract>(), It.IsAny<CancellationToken>()))
                        .Returns<GetWinnerContract, CancellationToken>(async (command, token) => await commandHandler.Handle(command, token));

            string contract1 = "NVV";
            string contract2 = "NNV";
            var command = new GetWinnerContract()
            {
                Contract1 = contract1,
                Contract2 = contract2,
            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            var result = mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
            Assert.True(result == contract2);
            this.output.WriteLine(result);
        }

        [Fact]
        public void ContractsIsSame()
        {
            var mediatorMock = new Mock<IMediator>();
            var commandHandler = new GetWinnerContractHandler();

            mediatorMock.Setup(m => m.Send(It.IsAny<GetWinnerContract>(), It.IsAny<CancellationToken>()))
                        .Returns<GetWinnerContract, CancellationToken>(async (command, token) => await commandHandler.Handle(command, token));

            string contract1 = "NNV";
            string contract2 = "NNV";
            var command = new GetWinnerContract()
            {
                Contract1 = contract1,
                Contract2 = contract2,
            };
            this.output.WriteLine(JsonConvert.SerializeObject(command));

            var result = mediatorMock.Object.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
            Assert.True(result == string.Empty);
            this.output.WriteLine(result);
        }
    }
}
