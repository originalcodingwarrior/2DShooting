using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : Person
{
    private const float MinHoldTime = 0.3f;
    private const float MaxHoldTime = 1.5f;

    private float randomHoldTime; //얼마나 힘줄지
    private float holdTime = 0f; //힘 준 시간
    private bool isShooting = false; //힘 주고 있는지

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
            //Debug.Log("파워 상승 : " + holdTime);

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
        EquipTrash(TrashManager.GetTrashForNeighbor()); //TrashManager한테 랜덤한 Trash 반환받고, 이걸 장착
        randomHoldTime = Random.Range(0.3f, 1.5f); //얼마나 힘주고 있을지 결정
        isShooting = true; //준비 다됐고 이제 슈팅 드가겠다

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
