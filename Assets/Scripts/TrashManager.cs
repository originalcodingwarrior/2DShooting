using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{

    //이 클래스가 하는 일~
    //모든 Trash 관리 - Player 소유인지 Neighbor 소유인지 Trash의 owner 관리
    //랜덤하게 Trash 하나 반환 - Neighbor이 장착할 Trash 고를 때 사용할 것.

    public static TrashManager Instance;

    private List<Trash> neighborTrash = new List<Trash>(); //neighbor쪽에 있는 Trash
    private List<Trash> playerTrash = new List<Trash>(); //player쪽에 있는 Trash

    private void Awake()
    {
        // 싱글톤
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void RegisterTrash(Trash trash) //생성된 Trash를 등록
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

    public void RemoveTrash(Trash trash)
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

    public bool HasPlayerTrash()
    {
        return playerTrash.Count > 0;
    }

    public bool HasNeighborTrash()
    {
        return neighborTrash.Count > 0;
    }

    public void ChangeOwner(Trash trash, Collider2D other) //Trash의 Owner변경 + 리스트 갱신
    {
        Owner newOwner = DetermineNewOwner(other); //해당 Zone의 주인이 누군지 확인하고 owner결정

        if(newOwner == Owner.None) //이런 일은 아마 없을 것이지만 그냥 혹시 모르니까
        {
            Debug.Log("엣~??");
            return; //걍 암것도 하지말고 return
        }

        if(newOwner != trash.owner) //주인 바뀔거면
        {
            RemoveTrash(trash); //기존 리스트에 있던 거 지우고

            trash.owner = newOwner; //주인 바꿔준 뒤

            RegisterTrash(trash); //해당하는 리스트에 다시 등록
        }

    }
    private Owner DetermineNewOwner(Collider2D other) //Owner이 누군지 확인
    {
        if (other.CompareTag("Neighbor's")) //NeighborZone에 들어왔다면

            return Owner.Neighbor; //Neighbor이 주인

        else if (other.CompareTag("Player's")) //PlayerZone에 들어왔다면

            return Owner.Player; //Player가 주인

        return Owner.None; 
        //어차피 Neighbor아니면 Player거일텐데 예외경우가 있을까싶긴함
        //그래도 return을 해주긴 해줘야하니까 None만들어서 리턴시켰음

    }

    public Trash GetTrashForNeighbor() //Neighbor이 쓸 Trash 골라주기
    {
        if (HasNeighborTrash()) { //neighbor의 trash가 있으면

            int randomIndex = Random.Range(0, neighborTrash.Count);

            return neighborTrash[randomIndex]; //랜덤한 trash 반환
        }
        else
        {
            Debug.Log("Neighbor쪽에 있는 Trash 없음");

            return null; // 없으면 그냥 null 반환
        }

    }
    


}
