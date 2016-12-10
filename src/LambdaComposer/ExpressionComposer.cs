using System;
using System.Linq;
using System.Linq.Expressions;

namespace LambdaComposer
{
	public class ExpressionComposer<T, TProperty>
	{
		private readonly Expression<Func<T, TProperty>> _expression;

		internal ExpressionComposer(Expression<Func<T, TProperty>> expression)
		{
			_expression = expression;
		}

		public Expression<Func<T, TResult>> With<TResult>(Expression<Func<TProperty, TResult>> expression)
		{
			var body = BuildBody(expression);

			return Expression.Lambda<Func<T, TResult>>(body, false, _expression.Parameters);
		}

		private Expression BuildBody(LambdaExpression expression)
		{
			var injector = new ExpressionInjector(expression.Parameters.Single(), _expression.Body);

			return injector.Inject(expression.Body);
		}
	}
}
