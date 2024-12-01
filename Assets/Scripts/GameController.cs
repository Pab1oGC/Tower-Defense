using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    public Text lblPoints;
    public int points;
    // Start is called before the first frame update
    void Start()
    {
        points = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        lblPoints.text = $"Points: {points}";
        if (Input.GetKeyDown(KeyCode.Q))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
    public void BuyNormal()
    {
        points--;
    }
    public void BuyNormal2()
    {
        points++;
    }
}
