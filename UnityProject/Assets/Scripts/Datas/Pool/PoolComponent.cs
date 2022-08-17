using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[ResourceAttribute("Assets/Bundles/Datas/Pool/PoolComponent.asset")]
[CreateAssetMenu(fileName = "PoolComponent", menuName = "Datas/PoolComponent")]
public class PoolComponent : ScriptableObject
{
    [SerializeField] public AssetReferenceGameObject bullet;
    [SerializeField] public AssetReferenceGameObject testItem;
    [SerializeField] public AssetReferenceGameObject shotgun;
    [SerializeField] public AssetReferenceGameObject rifle;

}