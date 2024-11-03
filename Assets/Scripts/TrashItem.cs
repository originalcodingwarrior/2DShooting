using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : Trash
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        angerImpact = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
