using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 씬의 Awake는 입장할 때 반드시 최초로 호출되어야한다.
/// </summary>

public abstract class GameSceneBase : MonoBehaviour
{
    public GameScene currScene
    {
        get
        {
            Type t = this.GetType();
            return ReflectionUtil.ConvertToEnum<GameScene>(t);
        }
    }

    [System.Serializable]
    public enum SingletonID // 게임 진입 시 초기화되는 싱글톤, 클래스 이름과 동일하게 enum을 작성해야 합니다.
    {
        ResourceMgr = 0,
        ScriptTable = 1,
        InputMgr = 2,
        ObjectPoolMgr = 3,
        SDNetwork = 4,
        Max
    }

    [System.Serializable]
    public class SingletonDictionary : SerializableDictionary<SingletonID, ISingleton> { }
    [SerializeField] protected SingletonDictionary singletonDictionary = new SingletonDictionary();

    public virtual bool IsSceneLoaded
    {
        get
        {
            return false;
        }
    }

    public virtual bool IsSceneEnd
    {
        get
        {
            return false;
        }
    }

    protected virtual void OnEnable()
	{

	}

    protected virtual void OnDisable()
	{
        singletonDictionary = null;
    }

    protected abstract IEnumerator Start();
}
