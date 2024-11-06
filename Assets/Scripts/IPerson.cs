using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPerson //쓰레기 맞으면 화내는 애들
{
    void IncreaseAnger(int value); //분노수치 증가

    void OnCollisionEnter2D(Collision2D collision); //충돌 시 실행

    event Action<int> OnAngerIncreased; //분노수치 올라가면 발생시킬 이벤트. (GamaManager가 구독할것)

}
