using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IShooter //������ ������ �ֵ�
{

    void EquipTrash(Trash trash); //������ ����

    Vector3 SetTrashTransform(); //������ ���� ��ġ ����

    IEnumerator Shoot(float power); //������ ������

    Vector2 SetThrowDirection(); //������ ���� ���� ���ϱ�
}
