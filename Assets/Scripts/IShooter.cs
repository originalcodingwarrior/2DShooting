using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooter
{

    void EquipTrash(Trash trash); //������ ����

    void SetTrashTransform(); //������ ���� ��ġ ����

    void Shoot(float power); //������ ������
}
