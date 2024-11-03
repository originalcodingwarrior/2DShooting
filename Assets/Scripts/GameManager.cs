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
    //�� ���� - �����ư��鼭 �� ��Ű��.
    //���� ���� ����

    //Neighbor�� ������ ���� �� �ٲٰ� �ٷ� �����ؼ� �Ѱ��ַ��� �ߴµ� �̰� GameManager�� �� ������ �´��� �𸣰���
    //���� Ŭ������ �����ұ��� �ӵ��� ��Ź

    public static GameManager Instance; //�ܺ� Ŭ�������� ���� �ʿ��� �� �� Instance

    public Player player;
    public Neighbor neighbor;

    public Person currentTurnPerson; //���� ���� ���

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

        currentTurnPerson = player;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsPlayerTurn() //Player�� ������
    {
        return currentTurnPerson == player;
    }

    public void SwitchTurn() //�� �ٲٱ�
    {

        if (IsPlayerTurn()) //�÷��̾��� ���̾�����
        {
            Debug.Log("neighbor�� �����Դϴ�");
            currentTurnPerson = neighbor; //������ ������ ����
            neighbor.PrepareShoot();
        }
        else //�ƴϾ�����
        {
            Debug.Log("player�� �����Դϴ�");
            currentTurnPerson = player; //�÷��̾� ������ ����
        }

        
    }


}
