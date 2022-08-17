using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 플레이어 중 위치 코스트가 가장 가까운 플레이어를 지목하여 돌려줍니다.
/// </summary>

public class NavMeshPathFinder : SingletonBehaviour<NavMeshPathFinder>
{
    List<NavMeshAgent> agentList = new List<NavMeshAgent>();

    public void RegisterAgent(NavMeshAgent agent)
    {
        agentList.Add(agent);
    }

    public Character GetNearTargetCharacter(NavMeshAgent agent)
    {
        return null;
    }
}
