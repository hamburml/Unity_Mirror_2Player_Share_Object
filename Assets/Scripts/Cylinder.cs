using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Cylinder : UseableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Active()
    {
        this.transform.Rotate(new Vector3(0, 1, 0));
    }
}
