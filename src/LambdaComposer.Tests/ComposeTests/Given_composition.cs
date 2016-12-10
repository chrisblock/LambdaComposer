using System;
using System.Linq.Expressions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace LambdaComposer.Tests.ComposeTests
{
	[TestFixture]
	public class Given_composition
	{
		[Test]
		public void When_expressions_are_compiled_Then_correct_value_is_returned()
		{
			Expression<Func<TestClass, TestClass>> part1 = x => x.Child.Child;

			var composition = part1.Compose().With(x => x.Child.Property);

			var fn = composition.Compile();

			var obj = new TestClass
			{
				Property = "Object",
				Child = new TestClass
				{
					Property = "Child",
					Child = new TestClass
					{
						Property = "GrandChild",
						Child = new TestClass
						{
							Property = "GreatGrandChild"
						}
					}
				}
			};

			Assert.That(fn(obj), Is.EqualTo("GreatGrandChild"));
		}
	}

	public class TestClass
	{
		public string Property { get; set; }
		public TestClass Child { get; set; }
	}
}
