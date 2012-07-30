using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace HiSystems.Interpreter.UnitTests
{
	[TestFixture]
	public class CustomFunctionTests
	{
        public static Engine Engine = new Engine();
        
        class NegateNumber : Function
        {
	        public override string Name 
	        {
		        get 
		        {
			        return "NEGATE"; 
		        }
	        }

	        public override Literal Execute(IConstruct[] arguments)
	        {
		        base.EnsureArgumentCountIs(arguments, 1);

				decimal inputValue = base.GetTransformedArgument<Number>(arguments, argumentIndex: 0);

		        return new Number(-inputValue);
	        }
        }

		//[TestFixtureSetup]
		static CustomFunctionTests()
		{
			Engine.Register(new NegateNumber());
		}

		[Test]
		public void Negate()
		{
            Assert.That(Engine.Parse("NEGATE(1)").Execute(), Is.EqualTo((Number)(-1)));
		}
	}
}
