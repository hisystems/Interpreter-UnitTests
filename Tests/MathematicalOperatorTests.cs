using System;
using NUnit.Framework;

namespace HiSystems.Interpreter.UnitTests
{
    [TestFixture]
    public class MathematicalOperatorTests
    {
        public static Engine Engine = new Engine();
        
        [Test]
        public void Addition()
        {
            Assert.That(Engine.Parse("1 + 2").Execute(), Is.EqualTo((Number)3));
        }

        [Test]
        public void AdditionUsingNegative()
        {
            Assert.That(Engine.Parse("1 + -2").Execute(), Is.EqualTo((Number)(-1)));
        }

        [Test]
        public void Subtraction()
        {
            Assert.That(Engine.Parse("1 - 2").Execute(), Is.EqualTo((Number)(-1)));
        }

        [Test]
        public void Multiplication()
        {
            Assert.That(Engine.Parse("1 * 2").Execute(), Is.EqualTo((Number)2));
        }
        
        [Test]
        public void Division()
        {
            Assert.That(Engine.Parse("1 / 2").Execute(), Is.EqualTo((Number)0.5));
        }
        
        [Test]
        public void Modulus()
        {
            Assert.That(Engine.Parse("3 % 2").Execute(), Is.EqualTo((Number)1));
        }
    }
}
