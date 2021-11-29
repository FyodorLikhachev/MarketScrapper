using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FyodorLikhachev.MarketScrapper
{
	public static class DependencyInjectionUtils
	{
		public static MethodInfo GetAddHostedServiceMethod()
		{
			var methodName = nameof(ServiceCollectionHostedServiceExtensions.AddHostedService);

			return typeof(ServiceCollectionHostedServiceExtensions)
				.GetMethods()
				.FirstOrDefault(p => p.Name == methodName)
				?? throw new Exception($"Unable to find the extension method '{methodName}' of '{nameof(IServiceCollection)}'.");
		}
	}
}