using System;
using NUnit.Framework;

namespace HiSystems.Interpreter.UnitTests
{
	[TestFixture]
	public class FunctionTests
	{
        private Engine Engine = new Engine();

        [SetUp]
        public void Setup()
        {
            this.Engine = new Engine();
            this.Engine.Register(new Today());
        }

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

        [Test]
        public void Today()
        {
            var tomorrow = System.DateTime.Today.AddDays(1);
            
            var expression = Engine.Parse("TODAY() + 1");

            Assert.That(expression.Execute(), Is.EqualTo((Interpreter.DateTime)tomorrow));;
        }
        
        [Test]
        public void FormatDateTimeDefault()
        {
            var expression = Engine.Parse("Format(#2000-2-1#)");

            Assert.That(expression.Execute(), Is.TypeOf<Text>());
        }

        [Test]
        public void FormatDateTime()
        {
            var expression = Engine.Parse("Format(#2000-2-1#, 'd/M/yyyy')");

            Assert.That(expression.Execute(), Is.EqualTo((Text)"1/2/2000"));
        }
        
        [Test]
        public void FormatNumberDefault()
        {
            var expression = Engine.Parse("Format(1)");

            Assert.That(expression.Execute(), Is.EqualTo((Text)"1"));
        }

        [Test]
        public void FormatNumber()
        {
            var expression = Engine.Parse("Format(1, '0.0')");

            Assert.That(expression.Execute(), Is.EqualTo((Text)"1.0"));
        }
	}
}
