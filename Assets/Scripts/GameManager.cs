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

    public Person currentTurnPerson;

    private int neighborTurnCount = 0; //�̿� �� ī��Ʈ üũ. 3�ϸ��� �г� ���ҽ�Ű����


    //�ٶ��� GameManager�� ����
    public static float minWind = 0.5f;
    public static float maxWind = -0.5f;

    public float currentWind;


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

        player.OnAngerChanged += CheckPlayerLose; //player���� OnAngerChanged �̺�Ʈ�� �߻��ϸ� CheckPlayerLose�� �����ϰڴٴ� ��
        neighbor.OnAngerChanged += CheckNeighborLose;
    }

    public bool IsPlayerTurn() //Player�� ������
    {
        return currentTurnPerson == player;
    }

    public void SwitchTurn() //�� �ٲٱ�
    {

        UpdateWind(); //�ٶ� ���� ������Ʈ
        uiManager.UpdateWindUI(currentWind); //�ٶ� UI�� ������Ʈ

        if (IsPlayerTurn()) //�÷��̾��� ���̾�����
        {
            NeighborTurn();
        }
        else //�̿��� ���̾�����
        {
            PlayerTurn();
        }

    }

    private void NeighborTurn()
    {
        uiManager.UpdateTurnOwner("Neighbor"); //UI �ؽ�Ʈ �ٲٱ�

        currentTurnPerson = neighbor; //������ ������ ����

        if (++neighborTurnCount % 3 == 0) //3�ϸ���
            neighbor.CalmDown(); //�г� ���� (50% Ȯ��)

        currentWind *= -1; //neighbor�� currentWind�� ��ȣ�� �ݴ�� ���
        neighbor.PrepareShoot(); //neighbor�� ���� �� �ְ� �غ��Ű��

        uiManager.UpdateLight(neighborTurnCount); //��ȣ�� UI �� �ٲٱ�
    }

    private void PlayerTurn()
    {
        uiManager.UpdateTurnOwner("Player"); //UI �ؽ�Ʈ �ٲٱ�

        currentTurnPerson = player; //�÷��̾� ������ ����

        if (!TrashManager.HasPlayerTrash()) //�÷��̾ ���� �� �ִ� Trash�� ������
        {
            Debug.Log("�÷��̾ ���� �� �ִ� �����Ⱑ ����");
            SwitchTurn(); //�� �� �ٲٱ�
            return;
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

    private void UpdateWind()
    {
        currentWind = Random.Range(minWind, maxWind);
        //Debug.Log("���� �ٶ� : " +  currentWind);
    }

}
