using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public enum ResourceType
{
    Material = 1,
    Prefab = 2,
    Scene = 3,
    Animation = 4,
    UnityAsset = 5
}

[System.AttributeUsage(AttributeTargets.Class)]
public class ResourceAttribute : Attribute
{
    private string resourcePath;

    public ResourceAttribute(string resourcePath)
    {
        this.resourcePath = resourcePath;
    }

    public string GetPath()
    {
        return resourcePath;
    }
}

public class ResourceMgr : SingletonBehaviour<ResourceMgr>
{
#if !UNITY_EDITOR
    private int loadedAssetCount = 0;
#endif
    public override bool IsLoadDone
    {
        get
        {
#if !UNITY_EDITOR
            return loadedAssetCount == Enum.GetValues(typeof(AssetType)).Length;
#else
            return true;
#endif
        }
    }

    protected override void OnInit()
    {
        base.OnInit();

#if !UNITY_EDITOR
        foreach(var label in Enum.GetValues(typeof(AssetType)))
        {
            DownLoadAsset(label.ToString());
        }
#endif
    }

#if !UNITY_EDITOR
    private void DownLoadAsset(string label)
    {
        Addressables.DownloadDependenciesAsync(label).Completed += (op) =>
            {
                if(op.IsDone && op.Status == AsyncOperationStatus.Succeeded)
                {
                    Addressables.Release(op);
                    loadedAssetCount++;
                }
            };
    }
#endif

    public AsyncOperationHandle<GameObject> Instantiate<T>(Vector3 pos, Quaternion quaternion, bool isAttachComponent = true, Action < T> PushObj = null) where T : MonoBehaviour
    {
        string path = AttributeUtil.GetResourcePath<T>();

        if (path == null)
            return new AsyncOperationHandle<GameObject>();

        return Instantiate(path, pos, quaternion, isAttachComponent, null, PushObj);
    }

    public AsyncOperationHandle<GameObject> Instantiate<T>(Action<T> PushObj = null, bool isAttachComponent = true) where T : MonoBehaviour
    {
        string path = AttributeUtil.GetResourcePath<T>();

        if (path == null)
            return new AsyncOperationHandle<GameObject>();

        return Instantiate(path, isAttachComponent, null, PushObj);
    }

    private AsyncOperationHandle<GameObject> Instantiate<T>(string path, bool isAttachComponent, Action OnCompleted, Action<T> ResultCallBack) where T : MonoBehaviour
    {
        var async = Addressables.InstantiateAsync(path);

        async.Completed += (op) =>
        {
            if (op.IsDone && op.Status == AsyncOperationStatus.Succeeded)
            {
                T monoObj = null;

                if (isAttachComponent)
                {
                    monoObj = op.Result.GetOrAddComponent<T>();
                }
                else
				{
                    monoObj = op.Result.GetComponent<T>();
                }

                ResultCallBack?.Invoke(monoObj);
                OnCompleted?.Invoke();
            }
        };

        return async;
    }

    private AsyncOperationHandle<GameObject> Instantiate<T>(string path, Vector3 pos, Quaternion quaternion, bool isAttachComponent, Action OnCompleted = null, Action<T> ResultCallBack = null) where T : MonoBehaviour
    {
        var async = Addressables.InstantiateAsync(path, pos, quaternion);

        async.Completed += (op) =>
        {
            if (op.IsDone && op.Status == AsyncOperationStatus.Succeeded)
            {
                T monoObj = null;

                if (isAttachComponent)
				{
                    monoObj = op.Result.GetOrAddComponent<T>();
                }
                else
                {
                    monoObj = op.Result.GetComponent<T>();
                }

                ResultCallBack?.Invoke(monoObj);
                OnCompleted?.Invoke();
            }
        };

        return async;
    }

    [Obsolete]
    public GameObject InstantiateSync(GameObject obj)
    {
        if (obj == null)
            return new GameObject();

        return Instantiate(obj);
    }

    public void LoadMap(ENUM_MAP_TYPE mapType, Action OnLoaded = null)
    {
        string mapPath = $"Assets/Bundles/Scenes/Stage/{mapType}.unity";
        StartCoroutine(Co_LoadMap(mapPath, OnLoaded));
    }
    
    private IEnumerator Co_LoadMap(string mapPath, Action OnLoaded)
    {
        if (mapPath == null ||
            mapPath == string.Empty)
            yield break;

        var async = Addressables.LoadSceneAsync(mapPath, LoadSceneMode.Additive);
        while (!async.IsDone)
            yield return null;

        OnLoaded?.Invoke();
        Addressables.UnloadSceneAsync(async);
    }

    public AsyncOperationHandle<T> LoadByType<T>(Type type, Action OnLoaded = null, Action<T> PushObj = null) where T : UnityEngine.Object
    {
        string path = AttributeUtil.GetResourcePath(type);

        if (path == null)
            return new AsyncOperationHandle<T>() { };

        return Load<T>(path, OnLoaded, PushObj);
    }

    public AsyncOperationHandle LoadByType(Type type, Action OnLoaded = null, Action<GameObject> PushObj = null)
    {
        string path = AttributeUtil.GetResourcePath(type);

        if (path == null)
            return new AsyncOperationHandle() { };

        return Load(path, OnLoaded, PushObj);
    }

    public AsyncOperationHandle LoadByPath(string path, Action OnLoaded = null, Action<GameObject> PushObj = null)
    {
        if (path == null ||
            path == string.Empty) 
            return new AsyncOperationHandle() { };

        return Load(path, OnLoaded, PushObj);
    }

    private AsyncOperationHandle<T> Load<T>(string path, Action OnCompleted = null, Action<T> ResultCallBack = null) where T : UnityEngine.Object
    {
        var async = Addressables.LoadAssetAsync<T>(path);

        async.Completed += (op) =>
        {
            if (op.IsDone && op.Status == AsyncOperationStatus.Succeeded)
            {
                OnCompleted?.Invoke();
                ResultCallBack?.Invoke(op.Result);
            }
        };

        return async;
    }

    private AsyncOperationHandle Load(string path, Action OnCompleted = null, Action<GameObject> ResultCallBack = null)
    {
        var async = Addressables.LoadAssetAsync<GameObject>(path);

        async.Completed += (op) =>
        {
            if (op.IsDone && op.Status == AsyncOperationStatus.Succeeded)
            {
                OnCompleted?.Invoke();
                ResultCallBack?.Invoke(op.Result);
            }
        };

        return async;
    }
}