using ServerLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SDSession : AdamSession
{
    public SDSession(bool isConnected = false) : base()
    {
        this.isConnected = isConnected;
    }

    public bool isConnected = false;
}
