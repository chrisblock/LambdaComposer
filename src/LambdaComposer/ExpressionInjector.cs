using System.Linq.Expressions;

namespace LambdaComposer
{
	internal class ExpressionInjector : ExpressionVisitor
	{
		private readonly ParameterExpression _search;
		private readonly Expression _replacement;

		public ExpressionInjector(ParameterExpression search, Expression replacement)
		{
			_search = search;
			_replacement = replacement;
		}

		public Expression Inject(Expression expression)
		{
			var result = Visit(expression);

			return result;
		}

		protected override Expression VisitParameter(ParameterExpression node)
		{
			var result = (node == _search)
				? _replacement
				: base.VisitParameter(node);

			return result;
		}
	}
}
