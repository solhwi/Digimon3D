using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServerLib;
using System.Net;

public class SDConnector : AdamConnector
{
    protected override void OnConnect(IPEndPoint EndPoint)
    {
        Debug.Log($"[Connected] {EndPoint.ToString()}");
    }
}
