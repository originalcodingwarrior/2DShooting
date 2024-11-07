using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Person : MonoBehaviour, IAngerable, IShooter
{
    public int anger = 0; //분노게이지 수치
    public event Action<int> OnAngerChanged; //분노 올라갔을 때 발생시킬 이벤트 (GameManager가 구독)

    protected GameObject selectedTrash = null; //던질 쓰레기
    protected Rigidbody2D trashRigidbody = null; //들고 있는 쓰레기의 Rigidbody2D. Trash 장착, 슛할 때 필요

    public void IncreaseAnger(int value) //분노 증가
    {
        this.anger += value;
        OnAngerChanged?.Invoke(anger); //분노 이벤트 발생. 현재 anger값 전달
    }

    public void DecreaseAnger(int value) //분노 감소
    {
        this.anger -= value;
        OnAngerChanged?.Invoke(anger); //분노 이벤트 발생. 현재 anger값 전달
    }

    public bool IsHolding()
    {
        return selectedTrash != null;
    }

    public void OnCollisionEnter2D(Collision2D collision) //충돌 시
    {
        Trash trash = collision.gameObject.GetComponent<Trash>(); //충돌한 Trash 참조

        if (trash != null)
        {
            IncreaseAnger(trash.angerImpact); //해당 Trash의 angerImapact만큼 anger 증가
        }
    }

    public abstract Vector3 SetTrashTransform(); //쓰레기 위치 정하기

    public void EquipTrash(Trash trash) //쓰레기 장착
    {
        if(trash == null)
        {
            Debug.Log("쓰레기가 null입니다");
            return;
        }

        if (!IsHolding()) //쓰레기를 들고 있지 않다면
        {
            selectedTrash = trash.gameObject;
            //Debug.Log("쓰레기 장착");

            //Trash가 던지는 사람 손에 붙어있게 하는 과정
            trashRigidbody = trash.gameObject.GetComponent<Rigidbody2D>();
            trashRigidbody.isKinematic = true; // 물리 효과를 받지 않도록 설정
            trashRigidbody.constraints = RigidbodyConstraints2D.FreezeAll; // 모든 움직임을 제한

            selectedTrash.transform.localPosition = SetTrashTransform();

        }
        else //들고 있다면
        {
            Debug.Log("이미 쓰레기를 들고 있음");
        }
    }

    public abstract Vector2 SetThrowDirection(); //쓰레기 던질 방향 정하기

    public IEnumerator Shoot(float power) //쓰레기 던지기
    {
        if (IsHolding()) {
            float forceMultiPlier = power * 10f;
            Vector2 throwDirection = SetThrowDirection();

            trashRigidbody.isKinematic = false; // 물리 효과를 받도록 설정
            trashRigidbody.constraints = RigidbodyConstraints2D.None; // 움직임 제한을 해제

            trashRigidbody.AddForce(throwDirection * forceMultiPlier, ForceMode2D.Impulse); //쓰레기에 힘 가함

            selectedTrash = null;
            trashRigidbody = null;

            //던지고 나서 잠깐 기다린 다음 턴 넘겨줄 것임
            yield return new WaitForSeconds(3f);

            GameManager.Instance.SwitchTurn(); //할 일 다했으니 턴 전환

        }
        else
        {
            Debug.Log("쓰레기 장착 안되어있음");

            GameManager.Instance.SwitchTurn(); //어쨌든 턴 전환
        }

        
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
