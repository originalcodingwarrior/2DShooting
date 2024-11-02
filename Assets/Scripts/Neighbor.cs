using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : Person
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void SetTrashTransform()
    {
        selectedTrash.transform.localPosition = transform.position + new Vector3(1f, 1f, 0);
    }


}
