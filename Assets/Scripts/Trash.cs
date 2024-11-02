using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TrashBag�� TrashItem�� �θ�Ŭ����
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

    void OnMouseDown() //Ŭ���Ǿ��� ��
    {
        //Debug.Log("������ Ŭ��");
        if (CompareTag("Player's")) //PlayerZone�� �ִ� ���� �´ٸ�
        {
            isEquipped = true;
            TrashManager.EquipTrashToPerson(GameManager.Instance.player, this); //TrashManager�� ���� �÷��̾�� Trash ����
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Neighbor's")) //NeighborZone�� ���Դٸ�
        {
            gameObject.tag = "Neighbor's"; //Neighbor�� Trash�� ��
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1765f, 0.5647f, 1.0f, 1f); //�׳� �������̿���

        }
        else if (other.CompareTag("Player's")) //PlayerZone�� ���Դٸ�
        {
            gameObject.tag = "Player's"; //Player�� Trash�� ��
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.9882f, 0.5804f, 1f); //�׳� �������̿���
        }
    }
}
