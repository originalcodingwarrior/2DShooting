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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Neighbor's")) //NeighborZone에 들어왔다면
        {
            owner = Owner.Neighbor; //Neighbor의 Trash가 됨
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1765f, 0.5647f, 1.0f, 1f); //그냥 디버깅용이에여

        }
        else if (other.CompareTag("Player's")) //PlayerZone에 들어왔다면
        {
            owner = Owner.Player; //Player의 Trash가 됨
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.9882f, 0.5804f, 1f); //그냥 디버깅용이에여
        }
    }
}
