using UnityEngine;

namespace LittleSword.Common
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType(typeof(T)) as T;
                    if (instance == null)
                    {
                        GameObject instanceGO = new GameObject(typeof(T).Name);
                        instance = instanceGO.AddComponent<T>();
                        
                        DontDestroyOnLoad(instanceGO);
                    }
                }

                return instance;
            }
        }

        protected void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}