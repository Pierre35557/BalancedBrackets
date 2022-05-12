using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Text.RegularExpressions;

namespace BalancedBrackets.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void When_EmptyInput_Expect_EmptyResult()
        {
            //----------------Assign----------------
            var input = string.Empty;

            //----------------Act-------------------
            var actual = Validate(input);

            //----------------Assert----------------
            var expected = string.Empty;
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        [TestCase("[]", "OK")]
        [TestCase("[][]", "OK")]
        [TestCase("[[]]", "OK")]
        [TestCase("[[[][]]]", "OK")]
        public void When_ValidInput_Expect_OK(string input, string expected)
        {
            //----------------Assign----------------
            //var input = string.Empty;

            //----------------Act-------------------
            var actual = Validate(input);

            //----------------Assert----------------
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        [TestCase("][", "FAIL")]
        [TestCase("][][", "FAIL")]
        [TestCase("[][]][", "FAIL")]
        public void When_InvaidInput_Expect_Fail(string input, string expected)
        {
            //----------------Assign----------------
            //var input = string.Empty;

            //----------------Act-------------------
            var actual = Validate(input);

            //----------------Assert----------------
            actual.Should().BeEquivalentTo(expected);
        }

        public static string Validate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string parantheses = new string(input.Where(c => c == '[' || c == ']').ToArray());

            while (parantheses.Contains("[]"))
                parantheses = parantheses.Replace("[]", "");

            return parantheses == string.Empty ? "OK" : "FAIL";
        }
    }
}