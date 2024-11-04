using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrashManager
{

    //�� Ŭ������ �ϴ� ��~
    //��� Trash ���� - ���� �ʿ���� �� ���⵵ �ѵ� �� neighbor�� �� �� �ִ� ������ Ȯ���Ϸ��� �ʿ��ϰ� �ؼ� �� �������
    //�����ϰ� Trash �ϳ� ��ȯ - Neighbor�� ������ Trash �� �� ����� ��.

    private static List<Trash> allTrash = new List<Trash>(); //Trash ������ List

    public static void RegisterTrash(Trash trash) //������ Trash�� ���
    {
        allTrash.Add(trash);
        //Debug.Log("����Ʈ�� Trash �߰�:" + allTrash.Count + "��°");
    }

    public static Trash GetTrashForNeighbor() //Neighbor�� �� Trash ����ֱ�
    {

        List<Trash> neighborTrash = allTrash.FindAll(t => t.owner == Owner.Neighbor);
        //neighbor�� trash�� �� ������

        if (neighborTrash.Count > 0) { //neighbor�� trash�� ������

            int randomIndex = Random.Range(0, neighborTrash.Count);

            return neighborTrash[randomIndex]; //������ trash ��ȯ
        }
        else
        {
            Debug.Log("Neighbor�ʿ� �ִ� Trash ����");

            return null; // ������ �׳� null ��ȯ
        }

        
    }
    public static void RemoveTrash(Trash trash)
    {
        allTrash.Remove(trash);
    }
}
