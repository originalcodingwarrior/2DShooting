using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //턴 관리 - 번갈아가면서 슛 시키기.
    //게임 승패 결정

    //Neighbor이 던지는 힘도 턴 바꾸고 바로 결정해서 넘겨주려고 했는데 이걸 GameManager가 할 역할이 맞는지 모르겠음
    //따로 클래스를 구분할까여말까여 앙딱정 부탁

    public static GameManager Instance;
    public Player player;
    public Neighbor neighbor;

    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
