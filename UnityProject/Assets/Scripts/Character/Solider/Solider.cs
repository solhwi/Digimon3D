using SDDefine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[ActiveCharacterAttribute(ENUM_CHARACTER.Solider, "Assets/Bundles/Prefabs/Character/Solider.prefab")]
public class Solider : ActiveCharacter
{
    [SerializeField] public Transform weaponFireTr;
    [SerializeField] public MeshFilter weaponMesh;

    public override void ChangeWeapon(WeaponObject weaponObject)
    {
        if (weaponObject.weaponType == ENUM_EQUIPMENT_WEAPON.Null)
            return;

        base.ChangeWeapon(weaponObject);

        // 소지한 무기 떨구기
        GameObject g = ObjectPoolMgr.Instance.GetPoolComponent(Inventory.Instance.curWeapon, transform.position);
        // g.transform.position = transform.position;

        // 무기 교체
        GetComponent<Solider>().weaponMesh.sharedMesh = weaponObject.meshFilter.sharedMesh;
        Inventory.Instance.curWeapon = weaponObject.weaponType;
    }

    public override void GetItem(InteractableObject interectObject)
    {
        base.GetItem(interectObject);

        Debug.Log(interectObject.itemName + "을(를) 흭득!");
    }
}