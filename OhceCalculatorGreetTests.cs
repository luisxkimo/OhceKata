using System;
using System.Linq;
using FluentAssertions;
using OhceApp;
using Xunit;

namespace OhceKata
{
    public class OhceCalculatorGreetTests
    {
        private string personName;
        private string firstInput;
        private OhceCalculator calculator;

        public OhceCalculatorGreetTests()
        {
            var temporalCalculator = new OhceCalculator();
            this.personName = "Luis";
            this.firstInput = temporalCalculator.RunCommand + " " + personName;
        }

        [Fact]
        public void IfRunCommandIsCorrect_AndIsMornignTime_ReturnsMorningGreets()
        {
            calculator = new OhceCalculator();
            var result = calculator.CalculateResult(firstInput, new DateTime(2016, 1, 1, 6, 15, 0));

            result.Any(p => p.Contains(calculator.MorningGreeting)).Should().Be(true);
            result.Any(p => p.Contains(this.personName)).Should().Be(true);
        }

        [Fact]
        public void IfRunCommandIsCorrect_AndIsAftternoonTime_ReturnsMorningGreets()
        {
            calculator = new OhceCalculator();
            var result = calculator.CalculateResult(firstInput, new DateTime(2016, 1, 1, 12, 15, 0));

            result.Any(p => p.Contains(calculator.AfternoonGreeting)).Should().Be(true);
            result.Any(p => p.Contains(this.personName)).Should().Be(true);
        }

        [Fact]
        public void IfRunCommandIsCorrect_AndIsNightTime_ReturnsMorningGreets()
        {
            calculator = new OhceCalculator();
            var result = calculator.CalculateResult(firstInput, new DateTime(2016, 1, 1, 20, 15, 0));

            result.Any(p => p.Contains(calculator.NightGreeting)).Should().Be(true);
            result.Any(p => p.Contains(this.personName)).Should().Be(true);
        }
    }
}