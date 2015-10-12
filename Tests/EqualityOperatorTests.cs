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
			Assert.That(Engine.Parse("#2014-01-01# < #2014-01-02#").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("`8:44` < `9:00`").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotLessThan()
        {
            Assert.That(Engine.Parse("2 < 1").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("#2014-02-01# < #2014-01-02#").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("`18:44` < `9:00`").Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void LessThanOrEqualTo()
        {
            Assert.That(Engine.Parse("1 <= 2").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("#2014-01-01# <= #2014-01-02#").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("`8:44` <= `9:00`").Execute(), Is.EqualTo((Boolean)true));

        }
        
        [Test]
        public void NotLessThanOrEqualTo()
        {
            Assert.That(Engine.Parse("2 <= 1").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("#2014-02-01# <= #2014-01-02#").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("`18:44` <= `9:00`").Execute(), Is.EqualTo((Boolean)false));

        }

        [Test]
        public void LessThanOrEqualToWhenEqual()
        {
            Assert.That(Engine.Parse("2 <= 2").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("#2014-02-01# <= #2014-02-01#").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("`18:44` <= `18:44`").Execute(), Is.EqualTo((Boolean)true));
        }

        [Test]
        public void GreaterThan()
        {
            Assert.That(Engine.Parse("2 > 1").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("#2014-03-01# > #2014-02-01#").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("`00:18:44.435` > `00:18:44`").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotGreaterThan()
        {
            Assert.That(Engine.Parse("1 > 2").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("#2014-03-02# > #2014-03-03#").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("`00:18:44.435` > `00:18:44.436`").Execute(), Is.EqualTo((Boolean)false));

        }

        [Test]
        public void GreaterThanOrEqualTo()
        {
            Assert.That(Engine.Parse("1 >= 1").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("#2014-03-01# >= #2014-02-01#").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("`00:18:44.435` >= `00:18:44`").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void GreaterThanOrEqualToWhenEqual()
        {
            Assert.That(Engine.Parse("1 >= 1").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("#2014-03-01# >= #2014-03-01#").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("`00:18:44.435` >= `00:18:44.435`").Execute(), Is.EqualTo((Boolean)true));
        }
 
        [Test]
        public void EqualTo()
        {
            Assert.That(Engine.Parse("1 = 1").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("#2014-03-01# = #2014-03-01#").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("`00:18:44.435` = `00:18:44.435`").Execute(), Is.EqualTo((Boolean)true));
        }
         
        [Test]
        public void NotEqualTo()
        {
            Assert.That(Engine.Parse("1 <> 0").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("#2014-03-01# <> #2014-03-02#").Execute(), Is.EqualTo((Boolean)true));
			Assert.That(Engine.Parse("`00:18:44.435` <> `00:18:44.425`").Execute(), Is.EqualTo((Boolean)true));
        }
        
        [Test]
        public void NotEqualToWhenEqual()
        {
            Assert.That(Engine.Parse("1 <> 1").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("#2014-03-01# <> #2014-03-01#").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("`00:18:44.425` <> `00:18:44.425`").Execute(), Is.EqualTo((Boolean)false));
        }

        [Test]
        public void EqualToWhenNotEqual()
        {
            Assert.That(Engine.Parse("1 = 2").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("#2014-03-01# = #2014-03-02#").Execute(), Is.EqualTo((Boolean)false));
			Assert.That(Engine.Parse("`00:18:44.435` = `00:18:44.425`").Execute(), Is.EqualTo((Boolean)false));

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
