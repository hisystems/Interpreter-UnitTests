using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace HiSystems.Interpreter.UnitTests
{
	[TestFixture]
	public class DataSetTests
	{
		private class DataSet : Literal
		{
			private class DataRow
			{
				public Literal[] RowData { get; set; }
			}

			private List<DataRow> Rows { get; set; }

			public DataSet(string tableName)
			{
				if (String.IsNullOrEmpty(tableName))
					throw new ArgumentNullException();

				this.Rows = new List<DataRow>();

				Rows.Add(new DataRow() { RowData = new Literal[] { (Number)1, (Number)2 } });
				Rows.Add(new DataRow() { RowData = new Literal[] { (Number)3, (Number)4 } });
				Rows.Add(new DataRow() { RowData = new Literal[] { (Number)5, (Number)5 } });
			}

			public Literal[] Select (int fieldIndex)
			{
				return Rows.Select(row => row.RowData[fieldIndex]).ToArray();
			}
		}

		/// <summary>
		/// Custom function that takes as an column from a DataTable and returns that as an array.
		/// Usage: SELECT(fieldIndex:Number, dataSet:DataSet) : Array:Number
		/// </summary>
		private class SelectFunction : Function
		{
			public SelectFunction()
			{
			}

			public override string Name 
			{
				get 
				{
					return "SELECT"; 
				}
			}

			public override Literal Execute(IConstruct[] arguments)
			{
				base.EnsureArgumentCountIs(arguments, 2);

				var fieldIndex = (decimal)base.GetTransformedArgument<Number>(arguments, 0);
				var dataSet = base.GetTransformedArgument<DataSet>(arguments, 1);

				return new Array(dataSet.Select((int)fieldIndex));
			}
		}

		/// <summary>
		/// Custom function that takes as an argument the name of the data table to retrieve and returns the result as a DataTable.
		/// Usage: DATASET(tableName:Variable) : DataSet
		/// </summary>
		private class DataSetFunction : Function
		{
			public DataSetFunction()
			{
			}

			public override string Name 
			{
				get 
				{
					return "DATASET"; 
				}
			}

			public override Literal Execute(IConstruct[] arguments)
			{
				base.EnsureArgumentCountIs(arguments, 1);
				
				var tableName = base.GetVariable(arguments, 0).Name;

				return new DataSet(tableName);
			}
		}

		//[TestFixtureSetup]
		static DataSetTests()
		{
			Engine.Register(new DataSetFunction());
			Engine.Register(new SelectFunction());
		}

		[Test]
		public void DataSetSumColumn0()
		{
            var expression = Engine.Parse("SUM(SELECT(0, DATASET(TableName)))");

            Assert.That(expression.Execute(), Is.EqualTo((Number)9));
		}
		
		[Test]
		public void DataSetSumColumn1()
		{
            var expression = Engine.Parse("SUM(SELECT(1, DATASET(TableName)))");

            Assert.That(expression.Execute(), Is.EqualTo((Number)11));
		}
	}
}
