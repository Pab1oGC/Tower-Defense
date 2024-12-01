using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    public Text lblPoints;
    public Text lblAmountWolf;
    public Text lblAmountPj1;
    public Text lblAmountPj3;
    public int points;

    int priceWolf = 25;
    int pricePj1 = 10;
    int pricePj3 = 50;

    public int amountWolf = 0;
    public int amountPj1 = 0;
    public int amountPj3 = 0;

    public List<Transform> containers = new List<Transform>();
    public GameObject prefabLevel;

    int[] levelsBought = new int[9];

    public int basePriceLevel = 100;
    public List<Text> textsPrice = new List<Text>();

    public Texture2D defaultCursor;
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        points = 1000;
        amountWolf = 0;
        amountPj1 = 0;
        amountPj3 = 0;
        if (lblPoints!=null)
        lblPoints.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        lblAmountPj1.text = amountPj1.ToString();
        lblAmountWolf.text = amountWolf.ToString();
        lblAmountPj3.text = amountPj3.ToString();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            panel.SetActive(!panel.activeSelf);
            UnityEngine.Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void BuyCharacters(int numero)
    {
        switch (numero)
        {
            case 1:
                VerifyAndUpdate(pricePj1, ref amountPj1);
                break;
            case 2:
                VerifyAndUpdate(priceWolf, ref amountWolf);
                break;
            case 3:
                VerifyAndUpdate(pricePj3, ref amountPj3);
                break;
        }
      
    }

    public void BuyLevel(int index)
    {
        //Marcy o Lucho aca aumenta la logica para aumentar las stats de cada personaje, por eso esta el switch
        switch (index)
        {
            case 0:
                AddLevel(index);
                break;
            case 1:
                AddLevel(index);
                break;
            case 2:
                AddLevel(index);
                break;
            case 3:
                AddLevel(index);
                break;
            case 4:
                AddLevel(index);
                break;
            case 5:
                AddLevel(index);
                break;
            case 6:
                AddLevel(index);
                break;
            case 7:
                AddLevel(index);
                break;
            case 8:
                AddLevel(index);
                break;
        }
    }

    void VerifyAndUpdate(int price,ref int amount)
    {
        if (points >= price)
        {
            amount++;
            points -= price;
            lblPoints.text = points.ToString();
        }
    }

    void AddLevel(int index)
    {
        int purchases = levelsBought[index];
        int actualPrice = Mathf.RoundToInt(basePriceLevel * Mathf.Pow(1.2f, purchases));
        if (containers[index].childCount < 6 && points >= actualPrice)
        {
            Instantiate(prefabLevel, containers[index]);
            points -= actualPrice;
            levelsBought[index]++;
            lblPoints.text = points.ToString();
            textsPrice[index].text = $"Precio: {Mathf.RoundToInt(basePriceLevel * Mathf.Pow(1.2f, levelsBought[index]))}";
        }
            
    }

    public bool CheckInPanel()
    {
        return !panel.activeSelf;
    }
    
}
