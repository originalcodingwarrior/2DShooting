using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrashManager
{

    //�� Ŭ������ �ϴ� ��~
    //��� Trash ���� - Player �������� Neighbor �������� Trash�� owner ����
    //�����ϰ� Trash �ϳ� ��ȯ - Neighbor�� ������ Trash �� �� ����� ��.

    private static List<Trash> neighborTrash = new List<Trash>(); //neighbor�ʿ� �ִ� Trash
    private static List<Trash> playerTrash = new List<Trash>(); //player�ʿ� �ִ� Trash

    public static void RegisterTrash(Trash trash) //������ Trash�� ���
    {
        if (trash.owner == Owner.Player)
        {
            playerTrash.Add(trash);
        }
        else if (trash.owner == Owner.Neighbor)
        {
            neighborTrash.Add(trash);
        }
    }

    public static void RemoveTrash(Trash trash)
    {
        if (trash.owner == Owner.Player)
        {
            playerTrash.Remove(trash);
        }
        else if (trash.owner == Owner.Neighbor)
        {
            neighborTrash.Remove(trash);
        }
    }

    public static bool HasPlayerTrash()
    {
        return playerTrash.Count > 0;
    }

    public static bool HasNeighborTrash()
    {
        return neighborTrash.Count > 0;
    }

    public static void ChangeOwner(Trash trash, Collider2D other) //Trash�� Owner���� + ����Ʈ ����
    {
        Owner newOwner = DetermineNewOwner(other); //�ش� Zone�� ������ ������ Ȯ���ϰ� owner����

        if(newOwner == Owner.None) //�̷� ���� �Ƹ� ���� �������� �׳� Ȥ�� �𸣴ϱ�
        {
            Debug.Log("��~??"); //��~~??
            return; //�� �ϰ͵� �������� return
        }

        if(newOwner != trash.owner) //���� �ٲ�Ÿ�
        {
            RemoveTrash(trash); //���� ����Ʈ�� �ִ� �� �����

            trash.owner = newOwner; //���� �ٲ��� ��

            RegisterTrash(trash); //�ش��ϴ� ����Ʈ�� �ٽ� ���
        }

    }
    private static Owner DetermineNewOwner(Collider2D other) //Owner�� ������ Ȯ��
    {
        if (other.CompareTag("Neighbor's")) //NeighborZone�� ���Դٸ�

            return Owner.Neighbor; //Neighbor�� ����

        else if (other.CompareTag("Player's")) //PlayerZone�� ���Դٸ�

            return Owner.Player; //Player�� ����

        return Owner.None; 
        //������ Neighbor�ƴϸ� Player�����ٵ� ���ܰ�찡 ������ͱ���
        //�׷��� return�� ���ֱ� ������ϴϱ� None���� ���Ͻ�����

    }

    public static Trash GetTrashForNeighbor() //Neighbor�� �� Trash ����ֱ�
    {
        if (HasNeighborTrash()) { //neighbor�� trash�� ������

            int randomIndex = Random.Range(0, neighborTrash.Count);

            return neighborTrash[randomIndex]; //������ trash ��ȯ
        }
        else
        {
            Debug.Log("Neighbor�ʿ� �ִ� Trash ����");

            return null; // ������ �׳� null ��ȯ
        }

    }
    


}
