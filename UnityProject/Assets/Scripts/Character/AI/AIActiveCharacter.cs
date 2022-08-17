using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIActiveCharacter : ActiveCharacter
{
    protected NavMeshAgent agent;
    protected Character target;

    public override void Init()
    {
        base.Init();

        agent = gameObject.GetOrAddComponent<NavMeshAgent>();

        NavMeshPathFinder.Instance.RegisterAgent(agent);
        this.StartUpdateCoroutine(FindTarget());
    }

    private IEnumerator FindTarget()
    {
        var wt = new WaitForSeconds(5);

        while(true)
        {
            yield return wt;
            SetTarget();
        }
    }
    

    protected void SetTarget()
    {
        target = NavMeshPathFinder.Instance.GetNearTargetCharacter(agent);
        agent.SetDestination(target.Tr.position);
    }
}
