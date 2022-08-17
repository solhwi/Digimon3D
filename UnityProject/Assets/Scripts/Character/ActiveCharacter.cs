using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.AttributeUsage(AttributeTargets.Class)]
public class ActiveCharacterAttribute : ResourceAttribute
{
    ENUM_CHARACTER job;

    public ActiveCharacterAttribute(ENUM_CHARACTER job, string path) : base(path)
    {
        this.job = job;
    }

    public ENUM_CHARACTER GetJob()
    {
        return job;
    }
}

public class ActiveCharacter : Character
{
    private Animator animator;

    private Dictionary<ENUM_CHARACTER_ANIMATION_CLIP, AnimationClip> clipDictionary
        = new Dictionary<ENUM_CHARACTER_ANIMATION_CLIP, AnimationClip>();

    CharacterAnimationTable table;

    public bool IsLoadCompleted
    {
        get
        {
            return animator != null && clipDictionary.Count == (int)ENUM_CHARACTER_ANIMATION_CLIP.Max;
        }
    }

    public override void Init()
    {
        base.Init();

        var job = AttributeUtil.GetCharacterJob(this.GetType());

        InitAnimator(job);
        InitAnimationClips(job);
    }

    private void InitAnimator(ENUM_CHARACTER job)
    {
        animator = gameObject.GetOrAddComponent<Animator>();

        animator.runtimeAnimatorController = null;
        animator.applyRootMotion = false;
        animator.updateMode = AnimatorUpdateMode.Normal;
        animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;

        table = ScriptTable.Instance.GetTable<CharacterAnimationTable>();
        string animatorPath = table.GetAnimatorPath(job);

        ResourceMgr.Instance.LoadByPath<RuntimeAnimatorController>(animatorPath, null,
               (controller) =>
               {
                   animator.runtimeAnimatorController = controller;
               });
    }

    private void InitAnimationClips(ENUM_CHARACTER job)
    {
        var animClipPathDictionary = table.GetAnimationClipPathDictionary(job);

        foreach (var pathPair in animClipPathDictionary)
        {
            InitAnimationClip(pathPair.Key, pathPair.Value);
        }
    }

    private void InitAnimationClip(ENUM_CHARACTER_ANIMATION_CLIP clipEnum, string path)
    {
        ResourceMgr.Instance.LoadByPath<AnimationClip>(path, null,
               (clip) =>
               {
                   if(!clipDictionary.ContainsKey(clipEnum))
                   {
                       clipDictionary.Add(clipEnum, clip);
                   }
               });
    }
    public override void Idle(CharacterParam param = null)
    {
        base.Idle(param);

        animator.SetBool("isMoving", false);

        if (!IsLoadCompleted) return;
    }

    public override void Move(CharacterParam param)
    {
        base.Move(param);

        if (!IsLoadCompleted ||
            param == null) return;
        
        var moveParam = param as CharacterMoveParam;

        if (moveParam != null)
        {
            float run = 1.0f;

            if(moveParam.isRun)
                run = 2.0f;
            
            animator.SetBool("isRunning", moveParam.isRun);
            animator.SetFloat("InputDirX", moveParam.inputVec.x * run);
            animator.SetFloat("InputDirZ", moveParam.inputVec.z * run);
            animator.SetBool("isMoving", moveParam.inputVec != Vector3.zero);

        }
    }

    public override void Attack(CharacterParam param = null)
    {
        base.Attack(param);

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

    public override void Reload(CharacterParam param = null)
    {
        base.Reload(param);

        if (!IsLoadCompleted) return;
    }

    public override void Interact(CharacterParam param = null)
    {
        base.Interact(param);

        if (!IsLoadCompleted) return;
    }
}
