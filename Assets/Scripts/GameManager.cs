using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Owner
{
    Player,
    Neighbor,
    None
}

public class GameManager : MonoBehaviour
{
    //턴 관리 - 번갈아가면서 슛 시키기.
    //게임 승패 결정

    public static GameManager Instance; //외부 클래스에서 접근 필요할 때 쓸 Instance


    public SceneController sceneController; //SceneController 참조. 씬 바꾸기용
    public UIManager uiManager; //UIManager 참조. 턴 주인 Text 바꾸게 하고 싶어서

    public Player player;
    public Neighbor neighbor;

    public Person currentTurnPerson;

    private int neighborTurnCount = 0; //이웃 턴 카운트 체크. 3턴마다 분노 감소시키려고

    //바람도 GameManager가 갱신
    public static float minWind = 0.5f;
    public static float maxWind = -0.5f;

    public float currentWind;


    private void Awake()
    {
        // 싱글톤
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        currentTurnPerson = player;

        player.OnAngerChanged += CheckPlayerLose; //player에서 OnAngerChanged 이벤트가 발생하면 CheckPlayerLose를 실행하겠다는 뜻
        neighbor.OnAngerChanged += CheckNeighborLose;
    }

    public bool IsPlayerTurn() //Player의 턴인지
    {
        return currentTurnPerson == player;
    }

    public void SwitchTurn() //턴 바꾸기
    {

        UpdateWind(); //바람 세기 업데이트
        uiManager.UpdateWindUI(currentWind); //바람 UI도 업데이트

        if (IsPlayerTurn()) //플레이어의 턴이었으면
        {
            NeighborTurn();
        }
        else //이웃의 턴이었으면
        {
            PlayerTurn();
        }

    }

    private void NeighborTurn()
    {
        uiManager.UpdateTurnOwner("Neighbor"); //UI 텍스트 바꾸기

        currentTurnPerson = neighbor; //상대방의 턴으로 변경

        if (++neighborTurnCount % 3 == 0) //3턴마다
            player.IncreaseAnger(neighbor.CalmDown());

        currentWind *= -1; //neighbor은 currentWind의 부호를 반대로 사용
        neighbor.PrepareShoot(); //neighbor이 슛할 수 있게 준비시키기

        uiManager.UpdateLight(neighborTurnCount); //신호등 UI 불 바꾸기
    }

    private void PlayerTurn()
    {
        uiManager.UpdateTurnOwner("Player"); //UI 텍스트 바꾸기

        currentTurnPerson = player; //플레이어 턴으로 변경

        if (!TrashManager.Instance.HasPlayerTrash()) //플레이어가 던질 수 있는 Trash가 없으면
        {
            Debug.Log("플레이어가 던질 수 있는 쓰레기가 없음");
            SwitchTurn(); //걍 턴 바꾸기
            return;
        }
    }

    private void CheckPlayerLose(int playerAnger) //Player가 졌는지 확인
    {
        if (playerAnger >= 10)
        {
            sceneController.LoadGameOver();
            Debug.Log("Player 이사 엔딩");
        }
    }

    private void CheckNeighborLose(int neighborAnger) //Neighbor이 졌는지 확인
    {
        if (neighborAnger >= 10)
        {
            Debug.Log("Neighbor 이사 엔딩");
            sceneController.LoadNextStage(); 
        }

    }

    private void UpdateWind()
    {
        currentWind = Random.Range(minWind, maxWind);
        //Debug.Log("현재 바람 : " +  currentWind);
    }

}
