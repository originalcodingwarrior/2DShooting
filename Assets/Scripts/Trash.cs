using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TrashBag�� TrashItem�� �θ�Ŭ����
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

    void OnMouseDown() //Ŭ���Ǿ��� ��
    {
        //Debug.Log("������ Ŭ��");
        if (owner == Owner.Player && GameManager.Instance.IsPlayerTurn()) //�÷��̾� ������ �����Ⱑ �´���, �÷��̾��� ���� �´��� Ȯ��
        {
            GameManager.Instance.player.EquipTrash(this); //�÷��̾�� Trash ����
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Neighbor's")) //NeighborZone�� ���Դٸ�
        {
            owner = Owner.Neighbor; //Neighbor�� Trash�� ��
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1765f, 0.5647f, 1.0f, 1f); //�׳� �������̿���

        }
        else if (other.CompareTag("Player's")) //PlayerZone�� ���Դٸ�
        {
            owner = Owner.Player; //Player�� Trash�� ��
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.9882f, 0.5804f, 1f); //�׳� �������̿���
        }
    }
}
