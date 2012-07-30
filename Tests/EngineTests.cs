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
		public void FunctionMissingArguments()
		{
			Engine.Parse("AVG()");
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
		
	}
}
