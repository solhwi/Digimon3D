using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingleton
{
    void Initialize()
    {
        
    }

    void OnClear()
    {
        
    }
}

public abstract class Singleton : ISingleton
{
	public virtual bool IsLoadDone
    {
        get
        {
            return false;
        }
    }

    protected abstract void OnInit();
    protected abstract void OnClear();
}

public class Singleton<T> : Singleton, IDisposable where T : Singleton<T>, new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
			{
                instance = new T();

                instance.Init();
            }

            return instance;
        }
    }

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
            }

            // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
            // TODO: 큰 필드를 null로 설정합니다.

            OnDispose();
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    private void Init()
    {
        SingletonManagement.RegisterSingleton(instance);
        OnInit();
    }

    private void OnDispose()
    {
        SingletonManagement.UnregisterSingleton<T>();
        OnClear();
    }

    protected override void OnInit()
	{
		
	}

    protected override void OnClear()
	{
		
	}
}


[System.Serializable]
public abstract class SingletonBehaviour : MonoBehaviour, ISingleton
{
    public virtual bool IsLoadDone
    {
        get
        {
            return false;
        }
    }

    protected abstract void OnDestroy();

    protected abstract void OnInit();
    protected abstract void OnClear();
}

public class SingletonBehaviour<T> : SingletonBehaviour where T : SingletonBehaviour<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            // 디폴트는 외형이 없는 오브젝트로 초기화
            return instance ?? Init();
        }
    }

    private static T Init()
    {
        GameObject g = new GameObject();
        instance = g.AddComponent<T>();

        instance.OnInit();

        SingletonManagement.RegisterSingletonBehaviour(instance);

#if UNITY_EDITOR
        g.name = typeof(T).ToString();
#endif
        return instance;
    }

	protected override void OnDestroy()
	{
        SingletonManagement.UnregisterSingletonBehaviour<T>();
        OnClear();
    }

    protected override void OnInit()
    {
        
    }

    protected override void OnClear()
    {
        
    }
}
