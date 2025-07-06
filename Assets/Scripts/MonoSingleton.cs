using UnityEngine;

// Generic MonoBehaviour singleton base class
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // The static instance of the singleton
    private static T _instance;

    // Public accessor for the singleton instance
    public static T Instance
    {
        get // If instance is null, find the first one or create one
        {
            if (_instance == null)
            {
                // Try to find an existing instance in the scene
                _instance = FindFirstObjectByType<T>();

                if (_instance == null)
                {
                    // If not found, create a new GameObject and add the singleton component
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";
                    DontDestroyOnLoad(singletonObject); // Persist across scenes
                }
            }

            return _instance;
        }
    }

    // Ensures only one instance exists and persists across scenes
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject); // Persist this instance
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
}