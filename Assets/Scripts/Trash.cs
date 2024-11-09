using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TrashBag과 TrashItem의 부모클래스
public class Trash : MonoBehaviour
{
    public int angerImpact; //사람이 맞았을 때 증가시킬 분노수치
    public Owner owner; //해당 Trash를 던질 수 있는 사람. Trash가 누구의 영역에 있는지

    // Start is called before the first frame update
    protected virtual void Start()
    {
        TrashManager.RegisterTrash(this); //TrashManager가 Trash를 관리할 수 있도록 List에 등록
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
        TrashManager.ChangeOwner(this, other); //owner 바꾸기

    }

    

}
