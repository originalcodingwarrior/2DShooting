using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer Img_Renderer;
    public Sprite offImage;
    public Sprite onImage;
    
    // Start is called before the first frame update
    void OnMouseDown(){
        if(SceneManager.GetActiveScene().name == "Main") SceneManager.LoadScene("Story1");
        else if(SceneManager.GetActiveScene().name == "Story1") SceneManager.LoadScene("Stage1");    
        else if(SceneManager.GetActiveScene().name == "Story2") SceneManager.LoadScene("Stage2");
        else if(SceneManager.GetActiveScene().name == "Story3") SceneManager.LoadScene("Stage3");  
        else if(SceneManager.GetActiveScene().name == "GameOver") SceneManager.LoadScene("Main");        
    }

     void OnMouseEnter(){
        Img_Renderer.sprite = onImage;
     }

     void OnMouseExit(){
        Img_Renderer.sprite = offImage;
     }
}
