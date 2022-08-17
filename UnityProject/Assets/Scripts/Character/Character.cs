using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Character : CollisionObject
{
    private Rigidbody rigid;
    
    private CharacterState currState = CharacterState.Idle;
    public CharacterState CurrState
    {
        get 
        { 
            return currState; 
        }

        private set
        {
            currState = value;
        }
    }

    public override void Init()
    {
        base.Init();

        rigid = gameObject.GetOrAddComponent<Rigidbody>();
        
        rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rigid.isKinematic = false;
        rigid.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigid.useGravity = true;
    }

    protected override void Reset()
    {
        LayerType = ENUM_LAYER_TYPE.Player;
        tagType = ENUM_TAG_TYPE.Playable;
    }

    public virtual void Idle(CharacterParam param = null)
    {
        CurrState = CharacterState.Idle;
        rigid.velocity = Vector2.zero;
    }

    public virtual void Move(CharacterParam param)
    {
        if (param == null || 
            param is CharacterMoveParam == false) 
            return;

        var moveParam = param as CharacterMoveParam;

        CurrState = moveParam.isRun ? CharacterState.Run : CharacterState.Move;

        Vector3 direction = transform.forward * moveParam.inputVec.z + transform.right * moveParam.inputVec.x;
        rigid.velocity = direction;
    }

    public virtual void Look(CharacterParam param)
    {
        if (param == null ||
               param is CharacterRotateParam == false)
            return;

        var rotateParam = param as CharacterRotateParam;

        Tr.rotation = Quaternion.Euler(rotateParam.rotateVec);
    }

    public virtual void Rotate(CharacterParam param)
    {
        if (param == null ||
               param is CharacterRotateParam == false)
            return;

        var rotateParam = param as CharacterRotateParam;

        Tr.Rotate(rotateParam.rotateVec);
    }

    public virtual void Attack(CharacterParam param = null)
    {
        CurrState = CharacterState.Attack;
    }

    public virtual void Reload(CharacterParam param = null)
    {
        CurrState = CharacterState.Reload;
    }

    public virtual void Interact(CharacterParam param = null)
    {
        CurrState = CharacterState.Interact;

        var interactParam = param as CharacterInteractParam;

        if (interactParam != null)
        {
            interactParam.targetObject.Interact();

            switch (interactParam.targetObject.itemType)
            {
                case ENUM_ITEM_TYPE.Weapon:
                    ChangeWeapon(interactParam.targetObject as WeaponObject);
                    break;
                case ENUM_ITEM_TYPE.Consumables:
                    GetItem(interactParam.targetObject);
                    break;
            }

            interactParam.targetObject.EndInteract();
        }
    }

    public virtual void ChangeWeapon(WeaponObject weaponObject) { }
    public virtual void GetItem(InteractableObject interectObject) { }
}