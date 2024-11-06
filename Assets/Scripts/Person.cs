using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Person : MonoBehaviour, IPerson, IShooter
{
    public int anger = 0; //�г������ ��ġ
    public event Action<int> OnAngerIncreased; //�г� �ö��� �� �߻���ų �̺�Ʈ

    protected GameObject selectedTrash = null; //���� ������
    protected Rigidbody2D trashRigidbody = null; //��� �ִ� �������� Rigidbody2D. Trash ����, ���� �� �ʿ�

    public void IncreaseAnger(int value)
    {
        //Debug.Log(this.anger + "+" + value);
        this.anger += value;
        OnAngerIncreased?.Invoke(anger); //�г� �̺�Ʈ �߻�. ���� anger�� ����
    }

    public bool IsHolding()
    {
        return selectedTrash != null;
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

    public abstract Vector3 SetTrashTransform(); //������ ��ġ ���ϱ�

    public void EquipTrash(Trash trash) //������ ����
    {
        if(trash == null)
        {
            Debug.Log("�����Ⱑ null�Դϴ�");
            return;
        }

        if (!IsHolding())
        {
            selectedTrash = trash.gameObject;
            Debug.Log("������ ����");

            //Trash�� ������ ��� �տ� �پ��ְ� �ϴ� ����
            trashRigidbody = trash.gameObject.GetComponent<Rigidbody2D>();
            trashRigidbody.isKinematic = true; // ���� ȿ���� ���� �ʵ��� ����
            trashRigidbody.constraints = RigidbodyConstraints2D.FreezeAll; // ��� �������� ����

            selectedTrash.transform.localPosition = SetTrashTransform();

        }
        else
        {
            Debug.Log("�̹� �����⸦ ��� ����");
        }
    }

    public abstract Vector2 SetThrowDirection(); //������ ���� ���� ���ϱ�

    public IEnumerator Shoot(float power) //������ ������
    {
        if (IsHolding()) {
            float forceMultiPlier = power * 10f;
            Vector2 throwDirection = SetThrowDirection();

            trashRigidbody.isKinematic = false; // ���� ȿ���� �޵��� ����
            trashRigidbody.constraints = RigidbodyConstraints2D.None; // ������ ������ ����

            trashRigidbody.AddForce(throwDirection * forceMultiPlier, ForceMode2D.Impulse); //�����⿡ �� ����

            selectedTrash = null;
            trashRigidbody = null;

            //������ ���� ��� ��ٸ� ���� �� �Ѱ��� ����
            yield return new WaitForSeconds(3f);

            GameManager.Instance.SwitchTurn(); //�� �� �������� �� ��ȯ

        }
        else
        {
            Debug.Log("������ ���� �ȵǾ�����");

            GameManager.Instance.SwitchTurn(); //��·�� �� ��ȯ
        }

        
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
