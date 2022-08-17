using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnim : StateMachineBehaviour
{
    float inputDirX;
    float inputDirZ;
    float dirX;
    float dirZ;

    float increaseVelue = 5.0f;
    float sprintZ = 2.5f;

    Animator anim;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim = animator;
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Get_Direction();
        Set_Direction();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Init_Direction(animator);
    }

    private void Init_Direction(Animator animator)
    {
        dirX = 0.0f;
        dirZ = 0.0f;
        animator.SetFloat("DirX", dirX);
        animator.SetFloat("DirZ", dirZ);
    }

    private void Get_Direction()
    {
        inputDirX = anim.GetFloat("InputDirX");
        inputDirZ = anim.GetFloat("InputDirZ");

        dirX = anim.GetFloat("DirX");
        dirZ = anim.GetFloat("DirZ");
    }

    private void Set_Direction()
    {
        if (!anim.GetBool("isMoving"))
        {
            Lerp_SetFloatAnim("DirX", dirX, 0.0f);
            Lerp_SetFloatAnim("DirZ", dirZ, 0.0f);
            return;
        }

        if (dirZ > 1.99f && inputDirZ == 2.0f)
            Lerp_SetFloatAnim("DirZ", dirZ, sprintZ);
        else
            Lerp_SetFloatAnim("DirZ", dirZ, inputDirZ);

        Lerp_SetFloatAnim("DirX", dirX, inputDirX);
    }

    private void Lerp_SetFloatAnim(string animName, float startValue, float endValue)
    {
        anim.SetFloat(animName, Mathf.Lerp(startValue, endValue, Time.deltaTime * increaseVelue));
    }
}
