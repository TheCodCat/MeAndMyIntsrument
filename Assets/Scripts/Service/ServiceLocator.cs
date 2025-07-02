using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
	public static ServiceLocator Instance { get; private set; }
	private Dictionary<string, IService> services = new Dictionary<string, IService>();

	private ServiceLocator()
	{

	}

	public static void Init() => Instance = new ServiceLocator();

	public void Register<T>(T service) where T : IService
	{
		string key = typeof(T).Name;
		if (services.ContainsKey(key))
		{
			Debug.Log($"сервис уже зарегистрирован {key}");
			return;
		}

		services.Add(key, service);
	}

	public void UnRegister<T>() where T : IService
	{
		string key = typeof(T).Name;
		if (!services.ContainsKey(key))
		{
			Debug.Log($"сервис не зарегистрирован {key}");
			return;
		}

		services.Remove(key);
	}

	public T Get<T>() where T : IService
	{
		string key = typeof(T).Name;
		if (!services.ContainsKey(key))
		{
			Debug.Log($"сервис не зарегистрирован {key}");
			throw new System.ArgumentException($"сервис не зарегистрирован {key}");
		}

		return (T)services[key];
	}
}
