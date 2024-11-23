using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePrefabSound : MonoBehaviour
{
    public AudioClip soundA; // 마우스를 누를 때 효과음
    public AudioClip soundB; // 마우스를 뗄 때 효과음
    public string prefabTag = "prefab"; // 프리팹에 설정된 태그

    private AudioSource audioSource;

    void Start()
    {
        // AudioSource 컴포넌트를 가져옵니다.
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 마우스 클릭 중 프리팹 위에 있을 때
        if (Input.GetMouseButton(0) && IsMouseOverPrefab())
        {
            if (!audioSource.isPlaying || audioSource.clip != soundA)
            {
                audioSource.clip = soundA;
                audioSource.Play();
            }
        }
        // 마우스에서 손을 뗐을 때 프리팹 위에 있을 때
        
    }

    // 마우스가 프리팹 위에 있는지 확인하는 함수
    private bool IsMouseOverPrefab()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycast를 사용하여 태그가 맞는 프리팹을 감지
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag(prefabTag)) // 태그로 비교
            {
                return true;
            }
        }

        return false;
    }
}