using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrashManager
{

    //이 클래스가 하는 일~
    //모든 Trash 관리 - 딱히 필요없을 것 같기도 한데 또 neighbor이 쓸 수 있는 쓰레기 확인하려면 필요하고 해서 걍 만들었삼
    //랜덤하게 Trash 하나 반환 - Neighbor이 장착할 Trash 고를 때 사용할 것.

    private static List<Trash> allTrash = new List<Trash>(); //Trash 관리할 List

    public static void RegisterTrash(Trash trash) //생성된 Trash를 등록
    {
        allTrash.Add(trash);
        //Debug.Log("리스트에 Trash 추가:" + allTrash.Count + "번째");
    }

    public static Trash GetTrashForNeighbor() //Neighbor이 쓸 Trash 골라주기
    {

        List<Trash> neighborTrash = allTrash.FindAll(t => t.owner == Owner.Neighbor);
        //neighbor의 trash만 싹 모으기

        if (neighborTrash.Count > 0) { //neighbor의 trash가 있으면

            int randomIndex = Random.Range(0, neighborTrash.Count);

            return neighborTrash[randomIndex]; //랜덤한 trash 반환
        }
        else
        {
            Debug.Log("Neighbor쪽에 있는 Trash 없음");

            return null; // 없으면 그냥 null 반환
        }

        
    }
    public static void RemoveTrash(Trash trash)
    {
        allTrash.Remove(trash);
    }
}
