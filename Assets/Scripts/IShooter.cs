using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IShooter //쓰레기 던지는 애들
{
    void EquipTrash(Trash trash); //쓰레기 장착

    Vector3 SetTrashTransform(); //쓰레기 장착 위치 결정

    IEnumerator Shoot(float power); //쓰레기 던지기

    Vector2 SetThrowDirection(); //쓰레기 던질 방향 정하기
}
