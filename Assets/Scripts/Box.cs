﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Box : UseableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Command]
    public override void CmdTriggerActive()
    {
        this.transform.Rotate(new Vector3(0, 1, 0));
    }
}
