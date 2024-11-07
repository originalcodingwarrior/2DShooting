using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerTarget : MonoBehaviour, IAngerable //�ǰݸ� ���. ������ ������ Neighbor�� Anger�� �ø��� �ֵ�.
{
    public Neighbor neighbor; //Neighbor ����

    public int angerBonus; //����Ÿ�� ��Ÿ���� ���, �߰����� �������� ���ϱ� ���� ��������.

    public void IncreaseAnger(int value)
    {
        neighbor.IncreaseAnger(value + angerBonus); //Neighbor�� anger �ø��� (+angerBonus)
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

}
