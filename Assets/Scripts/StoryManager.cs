using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public int HighestLayer = 0;
    int LastImage = 0;

    public AudioClip clearSound;
    private AudioSource audioSource;

    public void deleteImage(){

        if(LastImage == 1){
            if(SceneManager.GetActiveScene().name == "Story1") SceneManager.LoadScene("Stage1");    
            else if(SceneManager.GetActiveScene().name == "Story2") SceneManager.LoadScene("Stage2");
            else if(SceneManager.GetActiveScene().name == "Story3") SceneManager.LoadScene("Stage3");
        }

        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null && spriteRenderer.sortingOrder == HighestLayer && HighestLayer > 0)
            {

                Destroy(obj); // 오브젝트 삭제
                HighestLayer -= 1;
                break;

            }
            else if(spriteRenderer != null && spriteRenderer.sortingOrder == -1 && HighestLayer == 0){
                spriteRenderer.sortingOrder = 5;    
                LastImage = 1;  
                break;
            }
            
        }
        
    }

    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(clearSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 왼쪽 마우스 버튼 클릭 감지
        {   
            deleteImage();
            Debug.Log("화면이 클릭되었습니다!");
            // 원하는 이벤트 실행
        }
    }
}
