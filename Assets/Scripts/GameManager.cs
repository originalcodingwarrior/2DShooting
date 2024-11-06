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

    //Neighbor이 던지는 힘도 턴 바꾸고 바로 결정해서 넘겨주려고 했는데 이걸 GameManager가 할 역할이 맞는지 모르겠음
    //따로 클래스를 구분할까여말까여 앙딱정 부탁

    public static GameManager Instance; //외부 클래스에서 접근 필요할 때 쓸 Instance

    [SerializeField] private UIManager uiManager; //UIManager 참조. 턴 주인 Text 바꾸게 하고 싶어서

    public Player player;
    public Neighbor neighbor;

    public Person currentTurnPerson; //현재 턴인 사람

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

        player.OnAngerIncreased += CheckPlayerLose; //player에서 OnAngerIncreased가 발생하면 CheckWinner를 실행하겠다는 뜻
        neighbor.OnAngerIncreased += CheckNeighborLose;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsPlayerTurn() //Player의 턴인지
    {
        return currentTurnPerson == player;
    }

    public void SwitchTurn() //턴 바꾸기
    {

        if (IsPlayerTurn()) //플레이어의 턴이었으면
        {
            uiManager.UpdateTurnOwner("Neighbor"); //UI 텍스트 바꾸기

            currentTurnPerson = neighbor; //상대방의 턴으로 변경
            neighbor.PrepareShoot(); //neighbor이 슛할 수 있게 준비시키기
        }
        else //아니었으면
        {
            uiManager.UpdateTurnOwner("Player"); //UI 텍스트 바꾸기

            currentTurnPerson = player; //플레이어 턴으로 변경

            if (!TrashManager.HasPlayerTrash()) //플레이어가 던질 수 있는 Trash가 없으면
            {
                Debug.Log("플레이어가 던질 수 있는 Trash가 없음");
                SwitchTurn(); //걍 턴 바꾸기
            }
        }

    }

    private void CheckPlayerLose(int playerAnger) //Player가 졌는지 확인
    {
        if (playerAnger >= 10)
        {
            Debug.Log("Player 이사 엔딩");
        }
    }

    private void CheckNeighborLose(int neighborAnger) //Neighbor이 졌는지 확인
    {
        if (neighborAnger >= 10)
        {
            Debug.Log("Neighbor 이사 엔딩");
        }
    }

}
