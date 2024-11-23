using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBag : Trash
{
    //쓰봉 클래스

    public GameObject trashItemPrefab; //봉투 터졌을 때 나올 TrashItem의 Prefab
    public GameObject canTrashPrefab;

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

        if(collision.gameObject.CompareTag("HitTarget")) //대상이 되는 객체와 충돌 시
        {

            //Debug.Log("쓰봉 터진다");

            TrashManager.Instance.RemoveTrash(this); //TrashManager한테 알려줌. 리스트에서도 지워야하니까
            Destroy(gameObject); //TrashBag 터져 없어지고

            for(int i = 0; i < 2; i++)
            {
                GameObject trashItem = Instantiate(trashItemPrefab); //TrashItem 5개 생성
                trashItem.transform.position =
                    transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);

            }
            for (int i = 0; i < 3; i++)
            {
                GameObject canTrash = Instantiate(canTrashPrefab); //TrashItem 5개 생성
                canTrash.transform.position =
                    transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);

            }
        }
    }
}
