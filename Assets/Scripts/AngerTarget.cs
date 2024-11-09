using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerTarget : MonoBehaviour, IAngerable //피격만 담당. 쓰레기 맞으면 Neighbor의 Anger값 올리는 애들.
{
    public Neighbor neighbor; //Neighbor 참조

    public int angerBonus; //락스타의 기타같은 경우, 추가적인 데미지가 들어가니까 변수 만들어놓음.

    public void IncreaseAnger(int value)
    {
        neighbor.IncreaseAnger(value + angerBonus); //Neighbor의 anger 올리기 (+angerBonus)
    }

    public void OnCollisionEnter2D(Collision2D collision) //충돌 시
    {
        //Debug.Log("맞았다!");
        Trash trash = collision.gameObject.GetComponent<Trash>();

        if (trash != null)
        {
            IncreaseAnger(trash.angerImpact);
            //Debug.Log("쓰레기의 angerImpact: " + trash.angerImpact);
        }
    }

}
