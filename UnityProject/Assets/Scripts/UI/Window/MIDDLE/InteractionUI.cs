using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SDDefine;

public class InteractionUIParam : UIParam
{
    public ENUM_ITEM_TYPE itemType;
    public string message;
}


[WindowAttribute("MIDDLE/InteractionUI.prefab")]
public class InteractionUI : UIWindow
{
    [SerializeField] private Text interactionText = null;
    ENUM_ITEM_TYPE itemType;

    public override void Open(UIParam param = null)
    {
        base.Open(param);

        var _param = param as InteractionUIParam;

        if(_param != null)
        {
            SetText(_param.itemType, _param.message);
        } 
    }

    public void SetText(ENUM_ITEM_TYPE type, string message = null)
    {
        itemType = type;

        string interectionStr = null;

        switch (itemType)
        {
            case ENUM_ITEM_TYPE.Weapon:
                interectionStr = "(으)로 교체";
                break;
            case ENUM_ITEM_TYPE.Consumables:
                interectionStr = " 줍기";
                break;
            default:
                interectionStr = "상호작용하기";
                message = string.Empty;
                break;
        }

        interactionText.text = $"[G] {message}{interectionStr}";
    }

}
