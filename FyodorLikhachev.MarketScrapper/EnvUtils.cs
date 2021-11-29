using System;

namespace FyodorLikhachev.MarketScrapper
{
	public static class EnvUtils
	{
		public static string GetStringEnv(string envName)
			=> Environment.GetEnvironmentVariable(envName) 
			   ?? throw new ArgumentException($"Env '{envName}' isn't specified");

		public static long GetLongEnv(string envName)
		{
			var env = GetStringEnv(envName);

			if (!long.TryParse(env, out var longEnv))
				throw new ArgumentException($"Env '{envName}' isn't a valid long value");

			return longEnv;
		}
	}
}