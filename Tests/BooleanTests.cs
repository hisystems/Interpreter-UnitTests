using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace HiSystems.Interpreter.UnitTests
{
	[TestFixture]
	public class BooleanTests
	{
        public static Engine Engine = new Engine();
        
		[Test]
		public void TrueConstant()
		{
            Assert.That(Engine.Parse("true").Execute<Boolean>(), Is.EqualTo((Boolean)true));
		}
		
        [Test]
        public void FalseConstant()
        {
            Assert.That(Engine.Parse("false").Execute<Boolean>(), Is.EqualTo((Boolean)false));
        }
                        
        [Test]
        public void ImplicitBooleanToExpressionConversion()
        {
            Expression expression = true;

            Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
        }
	}
}
