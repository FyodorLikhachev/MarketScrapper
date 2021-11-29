using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FyodorLikhachev.MarketScrapper.Markets;
using HtmlAgilityPack;

namespace FyodorLikhachev.MarketScrapper
{
	internal static class DependencyInjectionExtensions
	{
		public static void AddPlainMarketScrappers(this IServiceCollection services)
		{
			services.AddSingleton<HtmlWeb>();
			services.AddMarketScrappers();
		}

		private static void AddMarketScrappers(this IServiceCollection services)
			=> services.AddHostedServicesFor(typeof(MarketScrapperBase));

		private static void AddHostedServicesFor(this IServiceCollection services, Type baseClass)
		{
			var methodInfo = DependencyInjectionUtils.GetAddHostedServiceMethod();

			var hostedServices = typeof(Program).Assembly.GetTypes()
				.Where(type => type.IsSubclassOf(baseClass) 
								&& !type.IsAbstract
								&& typeof(IHostedService).IsAssignableFrom(type));

			foreach (var hostedService in hostedServices)
			{
				var genericMethodAddHostedService = methodInfo.MakeGenericMethod(hostedService);
				_ = genericMethodAddHostedService.Invoke(null, new object[] { services });
			}
		}
	}
}