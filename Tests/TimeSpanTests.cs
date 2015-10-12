using NUnit.Framework;

namespace HiSystems.Interpreter.UnitTests {
	[TestFixture]
	public class TimeSpanTests {
		public static Engine Engine = new Engine();

		[Test]
		public void EqualTo() {
			var ts = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(29));

			var expression = Engine.Parse("A = B");
			expression.Variables["A"].Value = ts;
			expression.Variables["B"].Value = ts;

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
		}

		[Test]
		public void NotEqualTo() {

			var expression = Engine.Parse("A <> B");
			expression.Variables["A"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(1));
			expression.Variables["B"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(2));

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
		}

		[Test]
		public void LessThan() {
			var expression = Engine.Parse("A < B");
			expression.Variables["A"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(1));
			expression.Variables["B"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(2));

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
		}

		[Test]
		public void NotLessThan() {
			var expression = Engine.Parse("B < A");
			expression.Variables["A"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(1));
			expression.Variables["B"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(2));

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)false));
		}

		[Test]
		public void LessThanOrEqualTo() {
			var expression = Engine.Parse("A <= B");
			expression.Variables["A"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(1));
			expression.Variables["B"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(2));

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
		}

		[Test]
		public void NotLessThanOrEqualTo() {
			var expression = Engine.Parse("B <= A");
			expression.Variables["A"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(1));
			expression.Variables["B"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(2));

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)false));
		}

		[Test]
		public void GreaterThan() {
			var expression = Engine.Parse("B > A");
			expression.Variables["A"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(4));
			expression.Variables["B"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(9));

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)true));
		}

		[Test]
		public void NotGreaterThan() {
			var expression = Engine.Parse("A > B");
			expression.Variables["A"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(4));
			expression.Variables["B"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(9));

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)false));
		}

		[Test]
		public void GreaterThanOrEqualTo() {
			var expression = Engine.Parse("B >= A");
			expression.Variables["A"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(4));
			expression.Variables["B"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(9));

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)true)); ;
		}

		[Test]
		public void NotGreaterThanOrEqualTo() {
			var expression = Engine.Parse("A >= B");
			expression.Variables["A"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(4));
			expression.Variables["B"].Value = new Interpreter.TimeSpan(System.TimeSpan.FromMinutes(9));

			Assert.That(expression.Execute(), Is.EqualTo((Boolean)false)); ;
		}

		[Test]
		public void TimeSpanConstant() {
			var spanString = "3.13:45:56.7";

			var expression = Engine.Parse("`" + spanString + "`");

			Assert.That(expression.Execute<TimeSpan>(), Is.EqualTo((Interpreter.TimeSpan)System.TimeSpan.Parse(spanString))); ;
		}

		[Test]
		public void SubtractTimeSpans() {
			Assert.That(Engine.Parse("`1.3:55:00.12345` - `1.1:55:00.12345`").Execute(), Is.EqualTo((TimeSpan)new System.TimeSpan(0,2,0,0)));
		}

		[Test]
		public void AddTimeSpans() {
			Assert.That(Engine.Parse("`1.3:00:00` + `1.2:00:00`").Execute(), Is.EqualTo((TimeSpan)new System.TimeSpan(2, 5, 0, 0)));
		}

	}
}