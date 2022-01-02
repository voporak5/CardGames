using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
	protected static T instance;

	protected virtual void Awake()
	{
		if(instance)
		{
			Destroy(gameObject);
			return;
		}

		instance = GetComponent<T>();
	}
}

public class PersistentSingleton<T> : MonoBehaviour where T : Component
{
	protected static T instance;

	protected virtual void Awake()
	{
		instance = GetComponent<T>();
		DontDestroyOnLoad(this);
	}
}