using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public virtual void Initialize()
	{

	}

    protected virtual void Awake()
	{
        SceneMgr.Instance.RegisterCurrentScene(this);
    }

    public virtual void Free()
	{
        singletonDictionary = null;
    }

    protected abstract IEnumerator Start();
}
