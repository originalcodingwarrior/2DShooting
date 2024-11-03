using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBag : Trash
{
    public GameObject trashItemPrefab; //���� ������ �� ���� TrashItem�� Prefab

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        angerImpact = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Person")) //����� �浹 ��
        {
            //Debug.Log("���� ������");

            Destroy(gameObject); //TrashBag�� ���� ��������

            for(int i = 0; i < 5; i++)
            {
                GameObject trashItem = Instantiate(trashItemPrefab); //TrashItem 5�� ����
                trashItem.transform.position =
                    transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);

            }
        }
    }
}
