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

    private Animator animator = null;

    private Coroutine activeCoroutine = null;
    private Vector3 goalPosition = default;

    private float moveSpeed = 2.0f;

    public bool IsLoadCompleted
    {
        get
        {
            // return animator != null && animator.runtimeAnimatorController != null;
            return true;
        }
    }

    public override void Init()
    {
        base.Init();

        var type = AttributeUtil.GetDigimonType(this.GetType());
        InitAnimator(type);

        activeCoroutine = StartCoroutine(Co_Active());
    }

    private void InitAnimator(ENUM_DIGIMON_TYPE type)
    {
        animator = gameObject.GetOrAddComponent<Animator>();

        // animator.runtimeAnimatorController = null;
        // animator.applyRootMotion = false;
        // animator.updateMode = AnimatorUpdateMode.Normal;
        // animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
    }

    private IEnumerator Co_Active()
	{
        while(true)
		{
            if (!IsLoadCompleted)
                yield return null;

            if (CurrentPosition == goalPosition)
            {
                if (CurrState != ObjectState.Idle)
                {
                    Idle();
                }
            }
            else
			{
                Move(new MoveParam(goalPosition));
            }

            yield return null;
        }
	}

    public virtual void Idle(StateParam param = null)
    {
        if (!IsLoadCompleted) return;
    }

    public virtual void Move(StateParam _param)
    {
        if (!IsLoadCompleted ||
            _param == null ||
            _param is not MoveParam) return;

        var param = _param as MoveParam;

        goalPosition = param.targetPos;

        Vector3 normal = (goalPosition - CurrentPosition).normalized;
        rigid.velocity = moveSpeed * normal;
    }

    public virtual void Attack(StateParam param = null)
    {
        if (!IsLoadCompleted ||
            param == null) return;
    }
}