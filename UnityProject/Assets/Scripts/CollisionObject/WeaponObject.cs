using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;
using System;

public class WeaponObject : InteractableObject
{
    [SerializeField] public ENUM_EQUIPMENT_WEAPON weaponType;
    public MeshFilter meshFilter;
    protected void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    protected override void Reset()
    {
        base.Reset();

        itemType = ENUM_ITEM_TYPE.Weapon;
        if (Enum.IsDefined(typeof(ENUM_EQUIPMENT_WEAPON), this.name))
        {
            weaponType = (ENUM_EQUIPMENT_WEAPON)Enum.Parse(typeof(ENUM_EQUIPMENT_WEAPON), this.name);   
        }
        SetItemName();
    }

    public override void Interact()
    {
        if (Lock)
            return;

        base.Interact();
    }

    public override void EndInteract()
    {
        if (!Lock)
            return;

        base.EndInteract();
    }

    private void SetItemName()
    {
        switch(weaponType)
        {
            case ENUM_EQUIPMENT_WEAPON.Rifle:
                itemName = "라이플";
                break;
            case ENUM_EQUIPMENT_WEAPON.Shotgun:
                itemName = "샷건";
                break;
            default:
                itemName = "알 수 없는 물체";
                Debug.Log("오류! : " + this.name + "의 이름이 무기 열거형에 없음");
                break;
        }
    }
}
