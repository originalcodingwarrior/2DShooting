using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPerson
{

    void IncreaseAnger(int value); //�г��ġ ����

    void OnCollisionEnter2D(Collision2D collision); //�浹 �� ����

    // ���� interface ���ص� �����ʳ�...������ �� ���߿� ��� �߰��� �� ���� �� ���� �ְ�

    //�ν� ���� �� ������ Shoot�ϴ� �� �ƴ� �Ŵϱ� Shoot�ϴ� ������ IShooter, IPerson�ְ�
    //Shoot ���ϴµ� ������ ������ �ִ� ������ IPerson�� �ְ� �̷� ������ �Ϸ��� �����ý��ϴ�

    //�׳� ������ ������ interface��� ���� �� ��


}
