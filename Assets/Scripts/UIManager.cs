using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Neighbor neighbor;

    public AngerBar playerAngerBar;
    public AngerBar neighborAngerBar;

    public TextMeshProUGUI turnOwnerText;

    // Start is called before the first frame update
    void Start()
    {
        player.OnAngerChanged += UpdatePlayerAnger;
        neighbor.OnAngerChanged += UpdateNeighborAnger;
    }

    public void UpdatePlayerAnger(int newAnger)
    {
        playerAngerBar.SetValue(newAnger);
    }

    public void UpdateNeighborAnger(int newAnger)
    {
        neighborAngerBar.SetValue(newAnger);
    }

    public void UpdateTurnOwner(string turnOwner)
    {
        turnOwnerText.text = turnOwner + " Turn";
    }
}
