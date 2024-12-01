using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAllies : MonoBehaviour
{
    public Lane lane;
    public Texture2D currentCursor;
    public Texture2D defaultCursor;
    public Texture2D putCursor;
    public static RespawnAllies instance;

    public List<Transform> respawns = new List<Transform>();
    int currentCharacter;

    public GameObject pj1Prefab;
    public GameObject wolfPrefab;
    public GameObject pj3Prefab;
    void Start()
    {
        SetCursor(defaultCursor);
        currentCharacter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) currentCharacter = 1;
        if(Input.GetKeyDown(KeyCode.Alpha2)) currentCharacter = 2;
        if(Input.GetKeyDown(KeyCode.Alpha3)) currentCharacter = 3;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void OnMouseDown()
    {
        if (GameController.instance.CheckInPanel())
        {
            switch (lane)
            {
                case Lane.Top:
                    RespawnAllie(0);
                    Debug.Log($"Se hizo clic en la zona: TOP");
                    break;
                case Lane.Right:
                    RespawnAllie(1);
                    Debug.Log($"Se hizo clic en la zona: RIGHT");
                    break;
                case Lane.Bottom:
                    RespawnAllie(2);
                    Debug.Log($"Se hizo clic en la zona: BOTTOM");
                    break;
                case Lane.Left:
                    RespawnAllie(3);
                    Debug.Log($"Se hizo clic en la zona: LEFT");
                    break;
            }
        }
    }

    private void OnMouseEnter()
    {
        SetCursor(putCursor);
    }

    private void OnMouseExit()
    {
        SetCursor(defaultCursor);
    }

    public void SetCursor(Texture2D cursorTexture)
    {
        if (GameController.instance.CheckInPanel())
        {
            currentCursor = cursorTexture;
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }

    void RespawnAllie(int indexRespawn)
    {
        switch (currentCharacter)
        {
            case 1:
                if (GameController.instance.amountPj1 > 0)
                {
                    Instantiate(pj1Prefab, respawns[indexRespawn].position, respawns[indexRespawn].rotation);
                    GameController.instance.amountPj1--;
                }
                break;
            case 2:
                if (GameController.instance.amountWolf > 0)
                {
                    Instantiate(wolfPrefab, respawns[indexRespawn].position, respawns[indexRespawn].rotation);
                    GameController.instance.amountWolf--;
                }      
                break;
            case 3:
                if (GameController.instance.amountPj3 > 0)
                {
                    Instantiate(pj3Prefab, respawns[indexRespawn].position, respawns[indexRespawn].rotation);
                    GameController.instance.amountPj3--;
                }
                break;
        }
    }
}
public enum Lane
{
    Top,
    Right,
    Bottom,
    Left
}
