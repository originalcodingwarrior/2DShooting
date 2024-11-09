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

    public Image[] lights; // 0: red, 1: yellow, 2: green

    public Image needle;

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
    
    public void UpdateLight(int neighborTurnCount)
    {
        foreach (var light in lights)
        {
            light.gameObject.SetActive(false); //불 다 꺼주고
        }

        neighborTurnCount %= 3; //3으로 나눈 나머지로 바꿈. (0, 1, 2)

        lights[neighborTurnCount].gameObject.SetActive(true); //해당 불만 켜주기

    }

    public void UpdateWindUI(float wind)
    {

        wind = (wind + GameManager.minWind) / 1f; //wind를 0부터 1까지의 수로 보정
        float angle = Mathf.Lerp(90f, -90f, wind); // wind값에 따라 바늘 각도를 -90도~ 90도 사이에 맞게 보간
        //90f + (-90f - 90f) * wind

        needle.transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

}
