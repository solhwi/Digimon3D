using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ActiveObject : CollisionObject
{
    public CharacterState CurrState
    {
        get;
        private set;
    } = CharacterState.Idle;

    private Animator animator;

    public bool IsLoadCompleted
    {
        get
        {
            return animator != null;
        }
    }

    public override void Init(bool isMoving)
    {
        base.Init(isMoving);

        var job = AttributeUtil.GetCharacterJob(this.GetType());

        InitAnimator(job);
    }

    private void InitAnimator(ENUM_CHARACTER job)
    {
        animator = gameObject.GetOrAddComponent<Animator>();

        // animator.runtimeAnimatorController = null;
        animator.applyRootMotion = false;
        animator.updateMode = AnimatorUpdateMode.Normal;
        animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
    }

    public virtual void Idle(CharacterParam param = null)
    {
        animator.SetBool("isMoving", false);

        if (!IsLoadCompleted) return;
    }

    public virtual void Move(CharacterParam param)
    {
        if (!IsLoadCompleted ||
            param == null) return;

        var moveParam = param as CharacterMoveParam;

        if (moveParam != null)
        {
            float run = 1.0f;

            if (moveParam.isRun)
                run = 2.0f;

            animator.SetBool("isRunning", moveParam.isRun);
            animator.SetFloat("InputDirX", moveParam.inputVec.x * run);
            animator.SetFloat("InputDirZ", moveParam.inputVec.z * run);
            animator.SetBool("isMoving", moveParam.inputVec != Vector3.zero);
        }
    }

    public virtual void Attack(CharacterParam param = null)
    {
        if (!IsLoadCompleted) return;

        var attackParam = param as CharacterAttackParam;

        if (attackParam != null)
        {
            animator.SetFloat("AttackPosX", attackParam.targetPos.x);
            animator.SetFloat("AttackPosY", attackParam.targetPos.y);
            animator.SetFloat("AttackPosZ", attackParam.targetPos.z);

            animator.SetTrigger("AttackTrigger");
        }
    }
}