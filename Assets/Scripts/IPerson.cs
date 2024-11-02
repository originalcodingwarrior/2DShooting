using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPerson
{

    void IncreaseAnger(int value); //분노수치 증가

    void OnCollisionEnter2D(Collision2D collision); //충돌 시 실행

    // 딱히 interface 안해도 되지않나...싶은데 걍 나중에 기믹 추가할 때 쓰게 될 수도 있고

    //인싸 만들 때 전원이 Shoot하는 게 아닐 거니까 Shoot하는 놈한텐 IShooter, IPerson주고
    //Shoot 안하는데 데미지 판정만 있는 놈한텐 IPerson만 주고 이런 식으로 하려고 나눠봤습니다

    //그냥 데미지 판정용 interface라고 보심 될 듯


}
