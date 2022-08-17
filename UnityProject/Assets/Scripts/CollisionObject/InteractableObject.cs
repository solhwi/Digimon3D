using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

public class InteractableObject : CollisionObject
{
    [SerializeField] public string itemName = "Default";
    [SerializeField] public ENUM_ITEM_TYPE itemType;

    public bool Lock = false; // 상호작용 중인 상태 락변수

    protected override void Reset()
    {
        LayerType = ENUM_LAYER_TYPE.Environment;
        tagType = ENUM_TAG_TYPE.Interactable;
    }

    public virtual void Interact()
    {
        Lock = true;
        UIMgr.Instance.CloseUI<InteractionUI>();
    }

    public virtual void EndInteract()
    {
        Lock = false;
        gameObject.SetActive(false);
    }

    public void SetInteractable()
    {
        if (Lock)
            return;

        InteractionUIParam param = new InteractionUIParam()
        {
            itemType = this.itemType,
            message = this.itemName
        };

        UIMgr.Instance.OpenUI<InteractionUI>(param);
    }
    
    public void UnsetInteractable()
    {
        UIMgr.Instance.CloseUI<InteractionUI>();
    }
}
