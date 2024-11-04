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

    void OnTriggerEnter2D(Collider2D other) //Zone�� ����� ��
    {
        TrashManager.ChangeOwner(this, other);

        
        
    }

    

}
