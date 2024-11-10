using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Neighbor : Person
{
    const float MinHoldTime = 0.3f;
    const float MaxHoldTime = 1.5f;

    float randomHoldTime; //얼마나 힘줄지
    float holdTime = 0f; //힘 준 시간
    bool isShooting = false; //힘 주고 있는지

    public int reductionValue = 1;
    public int reductionBonus = 1; // 스테이지 3의 락스타 기믹을 위한 변수

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

    public int CalmDown() //실행 조건은 GameManager에서 확인할 것. (Neighbor의 turn이 3의배수째인지)
    {
        Debug.Log("Neighbor의 CalmDown실행");

        if(Random.Range(0, 2) == 0) //50%확률
        {
            Debug.Log("Neighbor CalmDown 성공!");
            DecreaseAnger(reductionValue); //분노 감소

            return reductionBonus;
        }
        
        return 0;

    }

}
