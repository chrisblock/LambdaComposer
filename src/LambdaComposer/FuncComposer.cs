using System;

namespace LambdaComposer
{
	public class FuncComposer<T, TProperty>
	{
		private readonly Func<T, TProperty> _lambda;

		internal FuncComposer(Func<T, TProperty> lambda)
		{
			_lambda = lambda;
		}

		public Func<T, TResult> With<TResult>(Func<TProperty, TResult> lambda)
		{
			return x => lambda(_lambda(x));
		}
	}
}
