using System;
using NUnit.Framework;

namespace HiSystems.Interpreter.UnitTests
{
	[TestFixture]
	public class FunctionTests
	{
		[Test]
		public void SumFunction()
		{
            var expression = Engine.Parse("SUM(A)");
			expression.Variables["A"].Value = new Array(new decimal[] { 1, 2, 3, 4 });

            Assert.That(expression.Execute(), Is.EqualTo((Number)10));
		}
		
		[Test]
		public void IfFunction()
		{
            var expression = Engine.Parse("IF(A, 10, 20)");
			expression.Variables["A"].Value = (Boolean)true;

            Assert.That(expression.Execute(), Is.EqualTo((Number)10));
		}

		[Test]
		public void AvgFunction()
		{
            var expression = Engine.Parse("AVG(A)");
			expression.Variables["A"].Value = new Array(new decimal[] { 1, 2, 3, 4, 5, 6, 7 });

            Assert.That(expression.Execute(), Is.EqualTo((Number)4));
		}
	}
}
