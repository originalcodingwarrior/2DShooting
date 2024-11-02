using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrashManager
{
    //�� Ŭ������ �ϴ� ��~
    //��� Trash ����
    //Player���� Trash ����. selectedTrash�� Ŭ���� Trash�� �ٲ� �� �ְ�.
    //Neighbor���� Trash ����. ��ü Trash �߿��� Neibor's Tag�� ���� Trash �ϳ��� �����ϰ� ����.

    //�׳� Trash�� Player�� ���� �ְ�޾Ƶ� �Ǳ� �ϴµ�
    //�̰� �� ���ұ����� ����� �� ���Ƽ� �̷��� �߽��ϴ�


    private static List<Trash> allTrash = new List<Trash>(); //Trash ������ List

    public static void RegisterTrash(Trash trash) //������ Trash�� ���
    {
        allTrash.Add(trash);
    }

    public static void EquipTrashToPerson(Person person, Trash trash) //Trash�� ���������� ��
    {
        person.EquipTrash(trash);
    }

    public static void EquipTrashToPerson(Person person) //Trash �� �־��ָ� TrashManager�� �ӵ������� Trash �����
    {

        if(allTrash.Exists(t => t.CompareTag("Neighbor's"))) //Neighbor�� ���� �� �ִ� Trash�� �ִ������� Ȯ��
        {
            int randomIndex;

            do
            {
                randomIndex = Random.Range(0, allTrash.Count);

            } while (!allTrash[randomIndex].CompareTag("Neighbor's"));

            Trash trash = allTrash[randomIndex];

            person.EquipTrash(trash);
            
        }
        else
        {
            Debug.Log("Neighbor �ʿ� �ִ� Trash ����");
        }
        
        //���ʿ� Neighbor's �±� ���� Trash�� ���� ��Ƴ��� �ű⼭ ������ �� ���� ������ �ͱ� �ѵ�
        //������ Trash �� �� �ȵ� �ű⵵ �ϰ� ���� �������� �� ���Ƽ� �ϴ� �̷��� �߽��ϴ�

    }
    //�̷��� �� ������ �� EquipTrashToPlayer(Player�� ����) EquipTrashToNeighbor(Neighbor�� ����)�ص� �� �� ������
    //�� ��� �� ���� �;�� ��. ���߿� ��� ���� �� ���� �� ������ �𸣴ϱ� ������ �������??? ����~


}
