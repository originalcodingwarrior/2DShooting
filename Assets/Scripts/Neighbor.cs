using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : Person
{
    const float MinHoldTime = 0.3f;
    const float MaxHoldTime = 1.5f;

    float randomHoldTime; //�󸶳� ������
    float holdTime = 0f; //�� �� �ð�
    bool isShooting = false; //�� �ְ� �ִ���

    public int reductionValue = 1;

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
            //Debug.Log("�Ŀ� ��� : " + holdTime);

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
        EquipTrash(TrashManager.GetTrashForNeighbor()); //TrashManager���� ������ Trash ��ȯ�ް�, �̰� ����
        randomHoldTime = Random.Range(0.3f, 1.5f); //�󸶳� ���ְ� ������ ����
        isShooting = true; //�غ� �ٵư� ���� ���� �尡�ڴ�

    }

    public override Vector3 SetTrashTransform()
    {
        return transform.position + new Vector3(1f, 1f, 0);
    }

    public override Vector2 SetThrowDirection()
    {
        return new Vector2(-1, 1).normalized;
    }

    public void CalmDown() //���� ������ GameManager���� Ȯ���� ��. (Neighbor�� turn�� 3�ǹ��°����)
    {
        Debug.Log("Neighbor�� CalmDown����");

        if(Random.Range(0, 2) == 0) //50%Ȯ��
        {
            Debug.Log("Neighbor CalmDown ����!");
            DecreaseAnger(reductionValue); //�г� ����
        }
        
    }

}
