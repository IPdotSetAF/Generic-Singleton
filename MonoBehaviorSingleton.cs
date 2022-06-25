using UnityEngine;

public abstract class MonoBehaviourSingleton <T>:MonoBehaviour where T : Component
{
    public abstract bool DontDestroy { get; }

    public static T Instance { get; private set; }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            
            if (DontDestroy)
                DontDestroyOnLoad(Instance);
            
            SingletonAwake();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// SingletonAwake runs only once even if you had multiple instances of the singleton
    /// </summary>
    public abstract void SingletonAwake();
}