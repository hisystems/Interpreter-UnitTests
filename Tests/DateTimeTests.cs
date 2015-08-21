using System;
using NUnit.Framework;

namespace HiSystems.Interpreter.UnitTests
{
    [TestFixture]
    public class DateTimeTests
    {
        private Engine Engine = new Engine();

        [Test]
        public void EqualTo()
        {
            var today = new Interpreter.DateTime(System.DateTime.Today);

            var expression = Engine.Parse("A = B");
            expression.Variables["A"].Value = today;
            expression.Variables["B"].Value = today;

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotEqualTo()
        {
            var today = System.DateTime.Today;
            
            var expression = Engine.Parse("A <> B");
            expression.Variables["A"].Value = new Interpreter.DateTime(today);
            expression.Variables["B"].Value = new Interpreter.DateTime(today.AddDays(1));

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void AddDays()
        {
            var today = System.DateTime.Today;
            var tomorrow = today.AddDays(1);

            var expression = Engine.Parse("A + `1`");
            expression.Variables["A"].Value = new Interpreter.DateTime(today);

            Assert.That(expression.Execute(), Is.EqualTo((Interpreter.DateTime)tomorrow));
        }
        
        [Test]
        public void SubtractDays()
        {
            var today = System.DateTime.Today;
            var yesterday = today.AddDays(-1);

            var expression = Engine.Parse("A - `1`");
            expression.Variables["A"].Value = new Interpreter.DateTime(today);

            Assert.That(expression.Execute(), Is.EqualTo((Interpreter.DateTime)yesterday));
        }
        
        [Test]
        public void SubtractDate()
        {
            var today = System.DateTime.Today;
            var yesterday = today.AddDays(-1);

            var expression = Engine.Parse("TODAY - YESTERDAY");
            expression.Variables["TODAY"].Value = new Interpreter.DateTime(today);
            expression.Variables["YESTERDAY"].Value = new Interpreter.DateTime(yesterday);

            Assert.That(expression.Execute(), Is.EqualTo((Interpreter.TimeSpan)System.TimeSpan.FromDays(1)));
        }

        [Test]
        public void LessThan()
        {
            var today = System.DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            var expression = Engine.Parse("TODAY < TOMORROW");
            expression.Variables["TODAY"].Value = new Interpreter.DateTime(today);
            expression.Variables["TOMORROW"].Value = new Interpreter.DateTime(tomorrow);

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotLessThan()
        {
            var today = System.DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            var expression = Engine.Parse("TOMORROW < TODAY");
            expression.Variables["TODAY"].Value = new Interpreter.DateTime(today);
            expression.Variables["TOMORROW"].Value = new Interpreter.DateTime(tomorrow);

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void LessThanOrEqualTo()
        {
            var today = System.DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            var expression = Engine.Parse("TODAY <= TOMORROW");
            expression.Variables["TODAY"].Value = new Interpreter.DateTime(today);
            expression.Variables["TOMORROW"].Value = new Interpreter.DateTime(tomorrow);

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotLessThanOrEqualTo()
        {
            var today = System.DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            var expression = Engine.Parse("TOMORROW <= TODAY");
            expression.Variables["TODAY"].Value = new Interpreter.DateTime(today);
            expression.Variables["TOMORROW"].Value = new Interpreter.DateTime(tomorrow);

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void GreaterThan()
        {
            var today = System.DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            var expression = Engine.Parse("TOMORROW > TODAY");
            expression.Variables["TODAY"].Value = new Interpreter.DateTime(today);
            expression.Variables["TOMORROW"].Value = new Interpreter.DateTime(tomorrow);

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotGreaterThan()
        {
            var today = System.DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            var expression = Engine.Parse("TODAY > TOMORROW");
            expression.Variables["TODAY"].Value = new Interpreter.DateTime(today);
            expression.Variables["TOMORROW"].Value = new Interpreter.DateTime(tomorrow);

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void GreaterThanOrEqualTo()
        {
            var today = System.DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            var expression = Engine.Parse("TOMORROW >= TODAY");
            expression.Variables["TODAY"].Value = new Interpreter.DateTime(today);
            expression.Variables["TOMORROW"].Value = new Interpreter.DateTime(tomorrow);

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));;
        }

        [Test]
        public void NotGreaterThanOrEqualTo()
        {
            var today = System.DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            var expression = Engine.Parse("TODAY >= TOMORROW");
            expression.Variables["TODAY"].Value = new Interpreter.DateTime(today);
            expression.Variables["TOMORROW"].Value = new Interpreter.DateTime(tomorrow);

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)false));;
        }
        
        [Test]
        public void DateTimeConstant()
        {
            var dateString = "2000-12-31 13:45:56.7";

            var expression = Engine.Parse("#" + dateString + "#");

            Assert.That(expression.Execute<DateTime>(), Is.EqualTo((Interpreter.DateTime)System.DateTime.Parse(dateString)));;
        }
                            
        [Test]
        public void DateConstant()
        {
            var dateString = "2000-12-31";

            var expression = Engine.Parse("#" + dateString + "#");

            Assert.That(expression.Execute<DateTime>(), Is.EqualTo((Interpreter.DateTime)System.DateTime.Parse(dateString)));;
        }

        [Test]
        public void TimeConstant()
        {
            var dateString = "13:45:56.7";

            var expression = Engine.Parse("#" + dateString + "#");

            Assert.That(expression.Execute<DateTime>(), Is.EqualTo((Interpreter.DateTime)System.DateTime.Parse(dateString)));;
        }

        [Test]
        public void DateTimeDifference()
        {
            var expression = Engine.Parse("#2000-1-2# - #2000-1-1#");

            Assert.That(expression.Execute<TimeSpan>(), Is.EqualTo((TimeSpan)System.TimeSpan.FromDays(1)));;
        }
    }
}
