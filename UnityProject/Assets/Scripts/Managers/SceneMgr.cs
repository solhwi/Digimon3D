using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : SingletonBehaviour<SceneMgr> 
{
    GameSceneBase gameScene;

    protected override void OnInit()
    {
        gameScene = FindObjectOfType<GameSceneBase>();
    }

    public void LoadScene(GameScene sceneEnum, Action<float> OnSceneLoading = null, Action OnSceneLoaded = null)
    {
        SceneManager.sceneLoaded += LoadSceneEnd;
        StartCoroutine(OnLoadSceneCoroutine(sceneEnum, OnSceneLoading, OnSceneLoaded));
    }

    private IEnumerator OnLoadSceneCoroutine(GameScene sceneEnum, Action<float> OnSceneLoading = null, Action OnSceneLoaded = null)
    {
        string sceneName = Enum.GetName(typeof(GameScene), sceneEnum);

        var asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        asyncOperation.allowSceneActivation = false;

        // UI 열기

        while(asyncOperation.progress < 0.9f)
        {
            yield return null;

            OnSceneLoading?.Invoke(asyncOperation.progress);
        }

        OnSceneLoaded?.Invoke();

        asyncOperation.allowSceneActivation = true;
    }

    private void LoadSceneEnd(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        // UI 닫기

        OnInit();
    }
}
