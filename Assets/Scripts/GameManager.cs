using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�� ���� - �����ư��鼭 �� ��Ű��.
    //���� ���� ����

    //Neighbor�� ������ ���� �� �ٲٰ� �ٷ� �����ؼ� �Ѱ��ַ��� �ߴµ� �̰� GameManager�� �� ������ �´��� �𸣰���
    //���� Ŭ������ �����ұ��� �ӵ��� ��Ź

    public static GameManager Instance;
    public Player player;
    public Neighbor neighbor;

    // Start is called before the first frame update
    private void Awake()
    {
        // �̱���
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
