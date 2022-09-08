using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ActiveObject : CollisionObject
{
    public ObjectState CurrState
    {
        get;
        private set;
    } = ObjectState.Idle;

    private Animator animator;

    public bool IsLoadCompleted
    {
        get
        {
            return animator != null;
        }
    }

    public override void Init()
    {
        base.Init();

        var job = AttributeUtil.GetDigimonType(this.GetType());
        InitAnimator(job);
    }

    private void InitAnimator(ENUM_DIGIMON_TYPE job)
    {
        animator = gameObject.GetOrAddComponent<Animator>();

        // animator.runtimeAnimatorController = null;
        // animator.applyRootMotion = false;
        // animator.updateMode = AnimatorUpdateMode.Normal;
        // animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
    }

    public virtual void Idle(StateParam param = null)
    {
        if (!IsLoadCompleted) return;
    }

    public virtual void Move(StateParam param)
    {
        if (!IsLoadCompleted ||
            param == null) return;
    }

    public virtual void Attack(StateParam param = null)
    {
        if (!IsLoadCompleted ||
            param == null) return;
    }
}