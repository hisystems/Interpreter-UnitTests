using System;
using NUnit.Framework;

namespace HiSystems.Interpreter.UnitTests
{
	[TestFixture]
	public class EngineTests
	{
        public static Engine Engine = new Engine();
        
		[Test]
		public void ExpressionSimple()
		{
            Assert.That(Engine.Parse("1 + 2").Execute(), Is.EqualTo((Number)3));
		}

		[Test]
		public void ExpressionWithMuteParenthesisPrecedence()
		{
            Assert.That(Engine.Parse("1 + (2 * 3) + 4").Execute(), Is.EqualTo((Number)11));
		}

		[Test]
		public void ExpressionWithOperatorPrecedence()
		{
            Assert.That(Engine.Parse("1 + 2 * 3 - 4 / 5").Execute(), Is.EqualTo((Number)6.2));
		}

		[Test]
		public void ExpressionWithOverriddingParenthesisPrecedence()
		{
            Assert.That(Engine.Parse("(1 + 2) * 3").Execute(), Is.EqualTo((Number)9));
		}

		[Test]
		public void ExpressionAsFunctionArgument()
		{
            Assert.That(Engine.Parse("IF(1 + 2 > 0, 10, 20)").Execute(), Is.EqualTo((Number)10));
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ExpressionWithInvalidArgumentVariable()
		{
            var expression = Engine.Parse("SUM(A)");
			expression.Variables["A"].Value = (Number)1;

            Assert.That(expression.Execute(), Is.EqualTo((Number)1));
		}
			
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void FunctionMissingArgumentInStart()
		{
			Engine.Parse("AVG(,2,3)");
		}
		
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void FunctionMissingArgumentInMiddle()
		{
			Engine.Parse("AVG(1,,3)");
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void FunctionMissingArgumentAtEnd()
		{
			Engine.Parse("AVG(1,2,)");
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void FunctionArgumentMissingCommaSeparator()
		{
			Engine.Parse("AVG(1,2 3)");
		}
		
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void OperatorMissingValue()
		{
			Engine.Parse("1 ++ 1");
		}
		
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void FunctionWithTooManyArguments()
		{
			Engine.Parse("AVG(1,2)").Execute();
		}
		
        [Test]
        public void VariableSpecifiedTwice()
        {
            var expression = Engine.Parse("A = A");
            expression.Variables["A"].Value = (Number)1;

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }

        [Test]
        public void FunctionAsVariable()
        {
            var subFunction = Engine.Parse("SUM(A)");
            subFunction.Variables["A"].Value = new Array(new decimal[] { 1, 2 });

            var mainFunction = Engine.Parse("IF(A > 0, 1, 2)");
            mainFunction.Variables["A"].Value = subFunction;

            Assert.That(mainFunction.Execute(), Is.EqualTo((Number)1));
        }
        
        [Test]
        public void ExecuteWithCast()
        {
            Assert.That(Engine.Parse("1 = 1").Execute<Boolean>(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ExecuteWithCastFailure()
        {
            // returns type Boolean not Number
            Engine.Parse("1 = 1").Execute<Number>();
        }

        [Test]
        public void IdentifierWithNumericCharacter()
        {
            var expression = Engine.Parse("A1 = A1B");
            expression.Variables["A1"].Value = (Number)1;
            expression.Variables["A1B"].Value = (Number)1;

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IdentifierWithNumericCharacterAtStart()
        {
            Engine.Parse("A1 = 1B");
        }
        
        [Test]
        public void FunctionWithEmptyArguments()
        {
            Engine.Parse("SUM(SUM())");
        }
        
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FunctionUndefined()
        {
            Engine.Parse("UndefinedFunction()");
        }
	}
}
