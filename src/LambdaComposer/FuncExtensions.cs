using System;

namespace LambdaComposer
{
	public static class FuncExtensions
	{
		public static FuncComposer<T, TProperty> Compose<T, TProperty>(this Func<T, TProperty> lambda)
		{
			return new FuncComposer<T, TProperty>(lambda);
		}
	}
}
