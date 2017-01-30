using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OhceApp;
using Xunit;

namespace OhceKata
{
    public class OhceCalculatorTests
    {
        private string personName;
        private string firstInput;
        private OhceCalculator calculator;

        public OhceCalculatorTests()
        {
            var temporalCalculator = new OhceCalculator();
            this.personName = "Luis";
            this.firstInput = temporalCalculator.RunCommand + " " +personName;
        }

        [Fact]
        public void IfFirstInputIsNullOrEmpty_ReturnsPleaseEnterName()
        {
            calculator = new OhceCalculator();
            var result = calculator.CalculateResult(string.Empty, new DateTime());

            result.Single().Should().Be(calculator.RunCommandErrorMessage);
        }

        [Fact]
        public void IfFirstInputNotContainsRunCommand_ReturnsRunErrorCommandMessage()
        {
            calculator = new OhceCalculator();
            var result = calculator.CalculateResult("lolaso", new DateTime());

            result.Single().Should().Be(calculator.RunCommandErrorMessage);
        }

        [Fact]
        public void IfInputIsStop_WithoutPreviousName_ReturnsPleaseEnterName()
        {
            calculator = new OhceCalculator();
            var input = "Stop!";
            var result = calculator.CalculateResult(input, new DateTime());

            result.Single().Should().Be(calculator.RunCommandErrorMessage);
        }

        [Fact]
        public void IfRunCommand_WithEmptyName_ReturnsRunCommandErrorMessage()
        {
            calculator = new OhceCalculator();
            var input = calculator.RunCommand + " " + String.Empty;
            var result = calculator.CalculateResult(input, new DateTime());

            result.Single().Should().Be(calculator.RunCommandErrorMessage);
        }

        [Fact]
        public void IfStopCommand_ReturnsByMessageWithName()
        {
            calculator = new OhceCalculator();
            calculator.CalculateResult(firstInput, new DateTime());
            var result = calculator.CalculateResult(OhceCalculator.StopCommand, new DateTime());

            result.Single().Contains(calculator.Bye).Should().Be(true);
            result.Single().Contains(this.personName).Should().Be(true);
        }

        [Fact]
        public void IfRunCommandIsCorrect_AndIsMornignTime_ReturnsMorningGreets()
        {
            calculator = new OhceCalculator();
            var result = calculator.CalculateResult(firstInput, new DateTime(2016,1,1,6,15,0));
            
            result.Single().Contains(calculator.MorningGreeting).Should().Be(true);
            result.Single().Contains(this.personName).Should().Be(true);
        }
    }
}
