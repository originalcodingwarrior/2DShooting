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

    public SpriteController spriteController;

    public AudioClip shootSound; //던질 때 나는 소리
    protected AudioSource audioSource;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void IncreaseAnger(int value) //분노 증가
    {
        //Debug.Log("분노 " + value + " 증가");
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

    public abstract Vector3 SetTrashTransform(); //쓰레기 위치 세팅 (손 위치로)

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

            spriteController.ChangeToHolding(); //스프라이트 변경
        }
        else //들고 있다면
        {
            return;
        }
    }

    public abstract Vector2 SetThrowDirection(); //쓰레기 던질 방향 세팅 (상대쪽 방향으로)

    public virtual IEnumerator Shoot(float power) //쓰레기 던지기
    {
        if (IsHolding()) {

            power += GameManager.Instance.currentWind; //바람 영향 고려

            float forceMultiPlier = power * 10f;
            Vector2 throwDirection = SetThrowDirection();

            trashRigidbody.isKinematic = false; // 물리 효과를 받도록 설정
            trashRigidbody.constraints = RigidbodyConstraints2D.None; // 움직임 제한을 해제

            trashRigidbody.AddTorque(power, ForceMode2D.Impulse);
            trashRigidbody.AddForce(throwDirection * forceMultiPlier, ForceMode2D.Impulse); //쓰레기에 힘 가함

            trashRigidbody = null;

            spriteController.ChangeToThrowing(); //스프라이트 변경

            audioSource.PlayOneShot(shootSound); //사운드 재생

            //던지고 나서 잠깐 기다린 다음 턴 넘겨줄 것임
            yield return new WaitForSeconds(3f);

            selectedTrash = null;

            GameManager.Instance.SwitchTurn(); //할 일 다했으니 턴 전환

            spriteController.ChangeToIdle();
        }
        else
        {
            Debug.Log("쓰레기 장착 안되어있음");

            GameManager.Instance.SwitchTurn(); //어쨌든 턴 전환
        }

        
    }

}
