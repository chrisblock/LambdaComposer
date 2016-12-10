using System;
using System.Linq.Expressions;

namespace LambdaComposer
{
	public static class ExpressionExtensions
	{
		public static ExpressionComposer<T, TProperty> Compose<T, TProperty>(this Expression<Func<T, TProperty>> expression)
		{
			return new ExpressionComposer<T, TProperty>(expression);
		}
	}
}
