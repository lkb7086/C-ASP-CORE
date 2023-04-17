﻿namespace tubaNWeb.CommonClass
{
	public class Singleton<T> where T : class, new()
	{
		private static Lazy<T> instance = null;
		private static object singletonLock = new Object();

		public static T Instance
		{
			get
			{
				lock (singletonLock)
				{
					if (IsExists() == false)
					{
						T singleton = new T();
						instance = new Lazy<T>(() => singleton);
					}
				}

				return instance.Value;
			}
		}

		private static bool IsExists()
		{
			return instance != null && instance.IsValueCreated == true;
		}

		public static void Clear()
		{
			lock (singletonLock)
			{
				instance = null;
			}
		}
	}
}
