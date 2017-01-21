using System;
using System.Linq;
using FluentAssertions;
using OhceApp;
using Xunit;

namespace OhceKata
{
    public class OhceCalculatorReverseTests
    {
        private string personName;
        private string firstInput;
        private OhceCalculator calculator;

        public OhceCalculatorReverseTests()
        {
            calculator = new OhceCalculator();
            this.personName = "Luis";
            this.firstInput = calculator.RunCommand + " " + personName;
            calculator.CalculateResult(firstInput, new DateTime(2016, 1, 1, 6, 15, 0));
        }

        [Fact]
        public void IfNormalInput_CalculatorReturnsReverseWords()
        {
            var word = "hola";
            var reverseWord = "aloh";
            var result = calculator.CalculateResult(word, new DateTime(2016, 1, 1, 6, 15, 0));

            result.Any(p => p.Contains(reverseWord)).Should().Be(true);            
        }

        [Fact]
        public void IfInputIsPalindrome_ReturnsReverseWordAndAmazingMessage()
        {
            var word = "oto";
            var result = calculator.CalculateResult(word, new DateTime(2016, 1, 1, 6, 15, 0));

            result.Any(p => p.Contains(word)).Should().Be(true);
            result.Any(p => p.Contains(calculator.AmazingWord)).Should().Be(true);
        }

    }
}