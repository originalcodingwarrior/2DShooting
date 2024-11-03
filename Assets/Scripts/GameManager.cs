using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Owner
{
    Player,
    Neighbor
}

public class GameManager : MonoBehaviour
{
    //턴 관리 - 번갈아가면서 슛 시키기.
    //게임 승패 결정

    //Neighbor이 던지는 힘도 턴 바꾸고 바로 결정해서 넘겨주려고 했는데 이걸 GameManager가 할 역할이 맞는지 모르겠음
    //따로 클래스를 구분할까여말까여 앙딱정 부탁

    public static GameManager Instance; //외부 클래스에서 접근 필요할 때 쓸 Instance

    public Player player;
    public Neighbor neighbor;

    public Person currentTurnPerson; //현재 턴인 사람

    private void Awake()
    {
        // 싱글톤
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        currentTurnPerson = player;

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
            Debug.Log("neighbor의 차례입니다");
            currentTurnPerson = neighbor; //상대방의 턴으로 변경
            neighbor.PrepareShoot();
        }
        else //아니었으면
        {
            Debug.Log("player의 차례입니다");
            currentTurnPerson = player; //플레이어 턴으로 변경
        }

        
    }


}
