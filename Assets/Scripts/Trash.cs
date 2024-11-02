using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TrashBag과 TrashItem의 부모클래스
public class Trash : MonoBehaviour
{
    public int angerImpact;
    public bool isEquipped = false;

    // Start is called before the first frame update
    void Start()
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
        if (CompareTag("Player's")) //PlayerZone에 있는 것이 맞다면
        {
            isEquipped = true;
            TrashManager.EquipTrashToPerson(GameManager.Instance.player, this); //TrashManager를 통해 플레이어에게 Trash 장착
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Neighbor's")) //NeighborZone에 들어왔다면
        {
            gameObject.tag = "Neighbor's"; //Neighbor의 Trash가 됨
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1765f, 0.5647f, 1.0f, 1f); //그냥 디버깅용이에여

        }
        else if (other.CompareTag("Player's")) //PlayerZone에 들어왔다면
        {
            gameObject.tag = "Player's"; //Player의 Trash가 됨
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.9882f, 0.5804f, 1f); //그냥 디버깅용이에여
        }
    }
}
