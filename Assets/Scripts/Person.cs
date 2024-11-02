using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Person : MonoBehaviour, IPerson, IShooter
{
    public int anger = 0; //분노게이지 수치
    public GameObject selectedTrash = null; //던질 쓰레기
    protected Rigidbody2D trashRigidbody = null; //들고 있는 쓰레기의 Rigidbody2D. Trash 장착, 슛할 때 필요

    public void IncreaseAnger(int value)
    {
        //Debug.Log(this.anger + "+" + value);
        this.anger += value;
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

    public abstract void SetTrashTransform(); //쓰레기 위치 정하기

    public void EquipTrash(Trash trash) //쓰레기 장착
    {
        if (!selectedTrash)
        {
            selectedTrash = trash.gameObject;
            Debug.Log("쓰레기 장착");

            //Trash가 Player의 손에 붙어있게 하는 과정
            trashRigidbody = trash.gameObject.GetComponent<Rigidbody2D>();
            trashRigidbody.isKinematic = true; // 물리 효과를 받지 않도록 설정
            trashRigidbody.constraints = RigidbodyConstraints2D.FreezeAll; // 모든 움직임을 제한

            SetTrashTransform();

        }
        else
        {
            Debug.Log("이미 쓰레기를 들고 있음");
        }
    }



    public virtual void Shoot(float power) //쓰레기 던지기
    {
        float forceMultiPlier = power * 10f;
        Vector2 throwDirection = new Vector2(1, 1).normalized;

        trashRigidbody.isKinematic = false; // 물리 효과를 받도록 설정
        trashRigidbody.constraints = RigidbodyConstraints2D.None; // 움직임 제한을 해제

        trashRigidbody.AddForce(throwDirection * forceMultiPlier, ForceMode2D.Impulse); //쓰레기에 힘 가함

        selectedTrash = null;
        trashRigidbody = null;
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
