using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IAngerable //쓰레기 맞으면 Anger 올리는 애들
{
    void IncreaseAnger(int value); //분노수치 증가

    void OnCollisionEnter2D(Collision2D collision); //충돌 시 실행

}
