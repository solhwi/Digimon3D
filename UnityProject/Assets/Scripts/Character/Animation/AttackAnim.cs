using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnim : StateMachineBehaviour
{
    Vector3 targetPos = Vector3.zero;

    Animator anim;
    public Transform soliderWeaponTr;

    float maxDistance = 30.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim = animator;
        soliderWeaponTr = anim.gameObject.GetComponent<Solider>().weaponFireTr;

        Set_TargetPos();
        Fire();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    
    private void Set_TargetPos()
    {
        float x = anim.GetFloat("AttackPosX");
        float y = anim.GetFloat("AttackPosY");
        float z = anim.GetFloat("AttackPosZ");

        targetPos = new Vector3(x, y, z);
    }

    private void Fire()
    {
        Debug.DrawRay(soliderWeaponTr.position, targetPos * maxDistance , Color.blue, 0.5f);

        RaycastHit hit;
        if (Physics.Raycast(soliderWeaponTr.position, targetPos, out hit, maxDistance))
        {
            Debug.Log("AttackAnim Ray와 충돌한 물체 이름 : " + hit.collider.gameObject.name);
        }
    }
}
