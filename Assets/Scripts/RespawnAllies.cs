using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAllies : MonoBehaviour
{
    public Lane lane;
    public Texture2D currentCursor;
    public Texture2D defaultCursor;
    public Texture2D putCursor;
    void Start()
    {
        SetCursor(defaultCursor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        switch (lane)
        {
            case Lane.Top:
                Debug.Log($"Se hizo clic en la zona: TOP");
                break;
            case Lane.Right:
                Debug.Log($"Se hizo clic en la zona: RIGHT");
                break;
            case Lane.Bottom:
                Debug.Log($"Se hizo clic en la zona: BOTTOM");
                break;
            case Lane.Left:
                Debug.Log($"Se hizo clic en la zona: LEFT");
                break;
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

    void SetCursor(Texture2D cursorTexture)
    {
        currentCursor = cursorTexture;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
public enum Lane
{
    Top,
    Right,
    Bottom,
    Left
}
