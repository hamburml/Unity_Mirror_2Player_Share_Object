using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class UseableObject : NetworkBehaviour
{
    [Command]
    public abstract void CmdTriggerActive();
}
