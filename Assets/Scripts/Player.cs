using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Person
{
    int calmDownChance = 3; //�г������ ���� ��ȸ�� �� �� �����ִ���

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

    public void UseCalmDownChance() //�г� ���� ��ȸ ���
    {
        if(calmDownChance > 0 && GameManager.Instance.IsPlayerTurn()) // ��ȸ�� �����ְ�, �÷��̾��� ���̸�
        {
            DecreaseAnger(reductionValue); //anger ���� �Լ� ȣ��
            calmDownChance -= 1; //��ȸ ����

            GameManager.Instance.SwitchTurn(); // 1�� �Ҹ�
        }
        
    }
}
