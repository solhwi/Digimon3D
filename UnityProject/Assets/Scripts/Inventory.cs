using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

public partial class Inventory : SingletonBehaviour<Inventory>
{
    // 장비
    public ENUM_EQUIPMENT_WEAPON curWeapon = ENUM_EQUIPMENT_WEAPON.Rifle; // 들고 시작 (임시)

    // 소지품


    public void GetEquipment(ENUM_EQUIPMENT_WEAPON weaponType)
    {
        curWeapon = weaponType;
    }
}
