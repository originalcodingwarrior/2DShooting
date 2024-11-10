using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //씬 불러오기
    //다음 씬이 뭔지 알고 있기
    //씬이 바뀌어도 남아있음

    private static string[] sceneName = { "Stage1", "Stage2", "Stage3", "Ending" };
    private static int sceneIndex = 0;

    private static SceneController instance; //private한 인스턴스

    public static SceneController Instance //외부에서 접근할 인스턴스
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<SceneController>();
                DontDestroyOnLoad(instance.gameObject);
                //씬이 바뀌어도 사라지지 않게
            }
            return instance;
        }
    }

    public void LoadNextStage()
    {
        sceneIndex++;
        SceneManager.LoadScene(sceneName[sceneIndex]);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadNewGame() //Retry 버튼이 이 함수로 연결되게 했어용
    {
        sceneIndex = 0;
        SceneManager.LoadScene("Stage1");
    }
}
