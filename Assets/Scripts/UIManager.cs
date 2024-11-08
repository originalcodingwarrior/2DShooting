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
            light.gameObject.SetActive(false); //�� �� ���ְ�
        }

        neighborTurnCount %= 3; //3���� ���� �������� �ٲ�. (0, 1, 2)

        lights[neighborTurnCount].gameObject.SetActive(true); //�ش� �Ҹ� ���ֱ�

    }

    public void UpdateWindUI(float wind)
    {

        wind = (wind + GameManager.minWind) / 1f; //wind�� 0���� 1������ ���� ����
        float angle = Mathf.Lerp(90f, -90f, wind); // wind���� ���� �ٴ� ������ -90��~ 90�� ���̿� �°� ����
        //90f + (-90f - 90f) * wind

        needle.transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

}
