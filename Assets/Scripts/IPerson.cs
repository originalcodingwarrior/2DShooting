using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPerson //������ ������ ȭ���� �ֵ�
{
    int GetAnger(); //�г��ġ ��ȯ
    void IncreaseAnger(int value); //�г��ġ ����

    void OnCollisionEnter2D(Collision2D collision); //�浹 �� ����

    event Action OnAngerIncreased; //�г��ġ �ö󰡸� �߻���ų �̺�Ʈ. (GamaManager�� �����Ұ�)

}
