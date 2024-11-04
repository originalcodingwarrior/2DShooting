using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TrashBag과 TrashItem의 부모클래스
public class Trash : MonoBehaviour
{
    public int angerImpact;
    public Owner owner;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        TrashManager.RegisterTrash(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() //클릭되었을 때
    {
        //Debug.Log("쓰레기 클릭");
        if (owner == Owner.Player && GameManager.Instance.IsPlayerTurn()) //플레이어 소유의 쓰레기가 맞는지, 플레이어의 턴이 맞는지 확인
        {
            GameManager.Instance.player.EquipTrash(this); //플레이어에게 Trash 장착
        }
    }

    void OnTriggerEnter2D(Collider2D other) //Zone에 닿았을 때
    {
        TrashManager.ChangeOwner(this, other);

        
        
    }

    

}
