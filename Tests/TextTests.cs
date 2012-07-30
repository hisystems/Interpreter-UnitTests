using System;
using NUnit.Framework;

namespace HiSystems.Interpreter.UnitTests
{
    [TestFixture]
    public class TextTests
    {
        private Engine Engine = new Engine();

        [Test]
        public void EqualTo()
        {
            var expression = Engine.Parse("\"A\" = \"A\"");

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }

        [Test]
        public void EqualToWhenNotEqual()
        {
            var expression = Engine.Parse("\"A\" = \"B\"");

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void NotEqualTo()
        {
            var expression = Engine.Parse("\"A\" <> \"A\"");

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)false));
        }
        
        [Test]
        public void NotEqualToWhenNotEqual()
        {
            var expression = Engine.Parse("\"A\" <> \"B\"");

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }

        [Test]
        public void Concatenate()
        {
            var expression = Engine.Parse("\"A\" + \"A\"");

            Assert.That(expression.Execute(), Is.EqualTo((Text)"AA"));
        }
    }
}
