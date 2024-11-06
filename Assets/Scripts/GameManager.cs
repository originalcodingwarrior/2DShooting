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
    //�� ���� - �����ư��鼭 �� ��Ű��.
    //���� ���� ����

    //Neighbor�� ������ ���� �� �ٲٰ� �ٷ� �����ؼ� �Ѱ��ַ��� �ߴµ� �̰� GameManager�� �� ������ �´��� �𸣰���
    //���� Ŭ������ �����ұ��� �ӵ��� ��Ź

    public static GameManager Instance; //�ܺ� Ŭ�������� ���� �ʿ��� �� �� Instance

    [SerializeField] private UIManager uiManager; //UIManager ����. �� ���� Text �ٲٰ� �ϰ� �;

    public Player player;
    public Neighbor neighbor;

    public Person currentTurnPerson; //���� ���� ���

    private void Awake()
    {
        // �̱���
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        currentTurnPerson = player;

        player.OnAngerIncreased += CheckPlayerLose; //player���� OnAngerIncreased�� �߻��ϸ� CheckWinner�� �����ϰڴٴ� ��
        neighbor.OnAngerIncreased += CheckNeighborLose;
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
            uiManager.UpdateTurnOwner("Neighbor"); //UI �ؽ�Ʈ �ٲٱ�

            currentTurnPerson = neighbor; //������ ������ ����
            neighbor.PrepareShoot(); //neighbor�� ���� �� �ְ� �غ��Ű��
        }
        else //�ƴϾ�����
        {
            uiManager.UpdateTurnOwner("Player"); //UI �ؽ�Ʈ �ٲٱ�

            currentTurnPerson = player; //�÷��̾� ������ ����

            if (!TrashManager.HasPlayerTrash()) //�÷��̾ ���� �� �ִ� Trash�� ������
            {
                Debug.Log("�÷��̾ ���� �� �ִ� Trash�� ����");
                SwitchTurn(); //�� �� �ٲٱ�
            }
        }

    }

    private void CheckPlayerLose(int playerAnger) //Player�� ������ Ȯ��
    {
        if (playerAnger >= 10)
        {
            Debug.Log("Player �̻� ����");
        }
    }

    private void CheckNeighborLose(int neighborAnger) //Neighbor�� ������ Ȯ��
    {
        if (neighborAnger >= 10)
        {
            Debug.Log("Neighbor �̻� ����");
        }
    }

}
