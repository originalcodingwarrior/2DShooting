using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Person
{
    int calmDownChance = 3; //분노게이지 감소 기회가 몇 번 남아있는지

    int reductionValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override Vector3 SetTrashTransform()
    {
        return transform.position + new Vector3(-1f, 1f, 0);
    }

    public override Vector2 SetThrowDirection()
    {
        return new Vector2(1, 1).normalized;
    }

    public void UseCalmDownChance() //분노 감소 기회 사용
    {
        if(calmDownChance > 0 && GameManager.Instance.IsPlayerTurn()) // 기회가 남아있고, 플레이어의 턴이면
        {
            DecreaseAnger(reductionValue); //anger 감소 함수 호출
            calmDownChance -= 1; //기회 감소

            GameManager.Instance.SwitchTurn(); // 1턴 소모
        }
        
    }
}
