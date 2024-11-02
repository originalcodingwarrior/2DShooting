using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrashManager
{
    //이 클래스가 하는 일~
    //모든 Trash 관리
    //Player에게 Trash 전달. selectedTrash를 클릭한 Trash로 바꿀 수 있게.
    //Neighbor에게 Trash 전달. 전체 Trash 중에서 Neibor's Tag를 가진 Trash 하나를 랜덤하게 결정.

    //그냥 Trash랑 Player랑 직접 주고받아도 되긴 하는데
    //이게 더 역할구분이 깔끔할 것 같아서 이렇게 했습니다


    private static List<Trash> allTrash = new List<Trash>(); //Trash 관리할 List

    public static void RegisterTrash(Trash trash) //생성된 Trash를 등록
    {
        allTrash.Add(trash);
    }

    public static void EquipTrashToPerson(Person person, Trash trash) //Trash가 정해져있을 때
    {
        person.EquipTrash(trash);
    }

    public static void EquipTrashToPerson(Person person) //Trash 안 넣어주면 TrashManager가 앙딱정으로 Trash 골라줌
    {

        if(allTrash.Exists(t => t.CompareTag("Neighbor's"))) //Neighbor이 던질 수 있는 Trash가 있는지부터 확인
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
            Debug.Log("Neighbor 쪽에 있는 Trash 없음");
        }
        
        //애초에 Neighbor's 태그 가진 Trash만 따로 모아놓고 거기서 돌리는 게 낫지 않을까 싶긴 한데
        //어차피 Trash 수 얼마 안될 거기도 하고 딱히 문제없을 것 같아서 일단 이렇게 했습니다

    }
    //이렇게 안 나누고 걍 EquipTrashToPlayer(Player만 받음) EquipTrashToNeighbor(Neighbor만 받음)해도 될 거 같은데
    //걍 배운 거 쓰고 싶었어여 네. 나중에 기믹 같은 거 넣을 때 쓸지도 모르니까 ㄱㅊ지 않을까요??? 하핫~


}
