using System;
using NUnit.Framework;

namespace HiSystems.Interpreter.UnitTests
{
    [TestFixture]
    public class EqualityOperatorTests
    {
        public static Engine Engine = new Engine();

        [Test]
        public void LessThan()
        {
            Assert.That(Engine.Parse("1 < 2").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotLessThan()
        {
            Assert.That(Engine.Parse("2 < 1").Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void LessThanOrEqualTo()
        {
            Assert.That(Engine.Parse("1 <= 2").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotLessThanOrEqualTo()
        {
            Assert.That(Engine.Parse("2 <= 1").Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void LessThanOrEqualToWhenEqual()
        {
            Assert.That(Engine.Parse("2 <= 2").Execute(), Is.EqualTo((Boolean)true));
        }

        [Test]
        public void GreaterThan()
        {
            Assert.That(Engine.Parse("2 > 1").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotGreaterThan()
        {
            Assert.That(Engine.Parse("1 > 2").Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void GreaterThanOrEqualTo()
        {
            Assert.That(Engine.Parse("1 >= 1").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void GreaterThanOrEqualToWhenEqual()
        {
            Assert.That(Engine.Parse("1 >= 1").Execute(), Is.EqualTo((Boolean)true));
        }
 
        [Test]
        public void EqualTo()
        {
            Assert.That(Engine.Parse("1 = 1").Execute(), Is.EqualTo((Boolean)true));
        }
         
        [Test]
        public void NotEqualTo()
        {
            Assert.That(Engine.Parse("1 <> 0").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotEqualToWhenEqual()
        {
            Assert.That(Engine.Parse("1 <> 1").Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void EqualToWhenNotEqual()
        {
            Assert.That(Engine.Parse("1 = 2").Execute(), Is.EqualTo((Boolean)false));
        }
        
        [Test]
        public void BooleanEqualTo()
        {
            Assert.That(Engine.Parse("true = true").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void BooleanNotEqualToWhenNotEqual()
        {
            Assert.That(Engine.Parse("true <> false").Execute(), Is.EqualTo((Boolean)true));
        }
    }
}
