using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Person : MonoBehaviour, IPerson, IShooter
{
    public int anger = 0; //�г������ ��ġ
    public GameObject selectedTrash = null; //���� ������
    protected Rigidbody2D trashRigidbody = null; //��� �ִ� �������� Rigidbody2D. Trash ����, ���� �� �ʿ�

    public void IncreaseAnger(int value)
    {
        //Debug.Log(this.anger + "+" + value);
        this.anger += value;
    }

    public void OnCollisionEnter2D(Collision2D collision) //�浹 ��
    {
        //Debug.Log("�¾Ҵ�!");
        Trash trash = collision.gameObject.GetComponent<Trash>();

        if (trash != null)
        {
            IncreaseAnger(trash.angerImpact);
            //Debug.Log("�������� angerImpact: " + trash.angerImpact);
        }
    }

    public abstract void SetTrashTransform(); //������ ��ġ ���ϱ�

    public void EquipTrash(Trash trash) //������ ����
    {
        if (!selectedTrash)
        {
            selectedTrash = trash.gameObject;
            Debug.Log("������ ����");

            //Trash�� Player�� �տ� �پ��ְ� �ϴ� ����
            trashRigidbody = trash.gameObject.GetComponent<Rigidbody2D>();
            trashRigidbody.isKinematic = true; // ���� ȿ���� ���� �ʵ��� ����
            trashRigidbody.constraints = RigidbodyConstraints2D.FreezeAll; // ��� �������� ����

            SetTrashTransform();

        }
        else
        {
            Debug.Log("�̹� �����⸦ ��� ����");
        }
    }



    public virtual void Shoot(float power) //������ ������
    {
        float forceMultiPlier = power * 10f;
        Vector2 throwDirection = new Vector2(1, 1).normalized;

        trashRigidbody.isKinematic = false; // ���� ȿ���� �޵��� ����
        trashRigidbody.constraints = RigidbodyConstraints2D.None; // ������ ������ ����

        trashRigidbody.AddForce(throwDirection * forceMultiPlier, ForceMode2D.Impulse); //�����⿡ �� ����

        selectedTrash = null;
        trashRigidbody = null;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
