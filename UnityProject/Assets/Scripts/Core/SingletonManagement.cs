using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class SingletonManagement
{
    [SerializeField] private static GameObject Management = null;

    [SerializeField] private static Dictionary<Type, SingletonBehaviour> aliveSingletonBehaviourDictionary = new Dictionary<Type, SingletonBehaviour>();
    [SerializeField] private static Dictionary<Type, Singleton> aliveSingletonDictionary = new Dictionary<Type, Singleton>();
    
    private static void InitManagement()
    {
        Management = new GameObject("@Management");
        MonoBehaviour.DontDestroyOnLoad(Management);
    }

    public static void RegisterSingletonBehaviour(SingletonBehaviour obj)
    {
        if(Management == null) InitManagement();
        
        if(obj != null)
        {
            obj.transform.SetParent(Management.transform);
            aliveSingletonBehaviourDictionary.Add(obj.GetType(), obj);
        }
    }

    public static void UnregisterSingletonBehaviour<T>() where T : SingletonBehaviour
    {
        var type = typeof(T);

        aliveSingletonBehaviourDictionary[type] = null;
        aliveSingletonBehaviourDictionary.Remove(type);
    }

    public static void RegisterSingleton(Singleton obj)
    {
        if (obj != null)
        {
            aliveSingletonDictionary.Add(obj.GetType(), obj);
        }
    }

    public static void UnregisterSingleton<T>() where T : Singleton
    {
        var type = typeof(T);

        aliveSingletonDictionary[type] = null;
        aliveSingletonDictionary.Remove(type);
    }


#if UNITY_EDITOR
    [MenuItem("Debug/표시되지 않는 싱글톤 확인하기")]
    public static void FindAliveSingletonsType()
    {
        StringBuilder sb = new StringBuilder();

        foreach(var pair in aliveSingletonDictionary)
        {
            sb.Append(pair.Key.ToString() + "\n");
        }

        Debug.Log(sb.ToString());
    }
#endif

}
