using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�÷��̾� Shoot�� �� ���콺 �Է� �����ϴ� Ŭ����

    private float holdTime = 0f;
    private bool isHoldingMouse = false;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.IsHolding() && Input.GetMouseButtonDown(0))
        {
            isHoldingMouse = true;
            holdTime = 0f;
        }

        if(isHoldingMouse)
        {
            holdTime += Time.deltaTime;
            //Debug.Log("�Ŀ� ��� : " + holdTime);
        }

        if (player.IsHolding() && Input.GetMouseButtonUp(0))
        {
            isHoldingMouse = false;
            StartCoroutine(player.Shoot(holdTime));
            holdTime = 0f;
        }

    }
}
