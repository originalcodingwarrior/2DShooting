using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooter
{

    void EquipTrash(Trash trash); //쓰레기 장착

    void SetTrashTransform(); //쓰레기 장착 위치 결정

    void Shoot(float power); //쓰레기 던지기
}
