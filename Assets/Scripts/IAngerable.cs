using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IAngerable //������ ������ Anger �ø��� �ֵ�
{
    void IncreaseAnger(int value); //�г��ġ ����

    void OnCollisionEnter2D(Collision2D collision); //�浹 �� ����

}
