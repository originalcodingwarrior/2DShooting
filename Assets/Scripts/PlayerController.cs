using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //플레이어 Shoot할 때 마우스 입력 관리하는 클래스

    private float holdTime = 0f;
    private bool isHoldingMouse = false;
    public Player player;

    public Slider powerBar;

    public AudioClip holdingSound; //게이지 찰 때 나는 소리
    protected AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.IsHolding() && Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(holdingSound);
            isHoldingMouse = true;
            holdTime = 0f;
        }

        if(isHoldingMouse)
        {
            if (holdTime < 3f)
            {
                holdTime += Time.deltaTime;
                powerBar.value = holdTime;
                //Debug.Log("파워 상승 : " + holdTime);
            }
        }

        if (player.IsHolding() && Input.GetMouseButtonUp(0))
        {
            isHoldingMouse = false;
            StartCoroutine(player.Shoot(holdTime));
            holdTime = 0f;
            powerBar.value = 0;
        }

    }
}
