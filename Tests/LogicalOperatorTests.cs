using System;
using NUnit.Framework;

namespace HiSystems.Interpreter.UnitTests
{
	[TestFixture]
	public class LogicalOperatorTests
	{
        public static Engine Engine = new Engine();
        
		[Test]
		public void LogicalTrueAndTrue()
		{
            Assert.That(Engine.Parse("true AND true").Execute(), Is.EqualTo((Boolean)true));
		}

		[Test]
		public void LogicalTrueAndFalse()
		{
            Assert.That(Engine.Parse("true AND false").Execute(), Is.EqualTo((Boolean)false));
		}

		[Test]
		public void LogicalTrueOrFalse()
		{
            Assert.That(Engine.Parse("true OR false").Execute(), Is.EqualTo((Boolean)true));
		}

		[Test]
		public void LogicalFalseOrFalse()
		{
            Assert.That(Engine.Parse("false OR false").Execute(), Is.EqualTo((Boolean)false));
		}
		
		[Test]
		public void LogicalAndMathematicalOperator()
		{
            Assert.That(Engine.Parse("2 > 1 AND 1 < 2").Execute(), Is.EqualTo((Boolean)true));
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void LogicalOrWithInvalidNumericArgument()
		{
			Engine.Parse("0 OR true").Execute();
		}
	}
}
