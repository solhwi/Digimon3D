using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 맵 제작 시 루트에 반드시 이 스크립트를 붙여주세요.
/// 맵이 로드될 때 제자리를 찾아가기 위해 필요합니다.
/// </summary>
/// 
public class MapRoot : MonoBehaviour
{
    private void Awake()
    {
        var root = FindObjectOfType<MapRootObject>();

        if (root != null)
            transform.SetParent(root.transform, true);
    }
}
