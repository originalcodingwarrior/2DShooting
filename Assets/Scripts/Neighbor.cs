using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : Person
{
    private const float MinHoldTime = 0.3f;
    private const float MaxHoldTime = 1.5f;

    private float randomHoldTime; //¾ó¸¶³ª ÈûÁÙÁö
    private float holdTime = 0f; //Èû ÁØ ½Ã°£
    private bool isShooting = false; //Èû ÁÖ°í ÀÖ´ÂÁö

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isShooting)
        {
            holdTime += Time.deltaTime;
            //Debug.Log("ÆÄ¿ö »ó½Â : " + holdTime);

            if (holdTime >= randomHoldTime)
            {
                StartCoroutine(Shoot(holdTime));
                holdTime = 0f;
                isShooting = false;
            }
        }



    }
    public void PrepareShoot()
    {
        EquipTrash(TrashManager.GetTrashForNeighbor());
        randomHoldTime = Random.Range(0.3f, 1.5f);
        isShooting = true;

    }

    public override Vector3 SetTrashTransform()
    {
        return transform.position + new Vector3(1f, 1f, 0);
    }

    public override Vector2 SetThrowDirection()
    {
        return new Vector2(-1, 1).normalized;
    }



}
