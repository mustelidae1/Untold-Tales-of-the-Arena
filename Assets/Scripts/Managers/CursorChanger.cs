using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public static CursorChanger S;

    public Texture2D normalCursor;
    public Texture2D highlightedCursor;
    public Texture2D handCursor;
    public Texture2D leftArrowCursor;
    public Texture2D rightArrowCursor;
    public Texture2D downArrowCursor;
    public Texture2D upArrowCursor; 

    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        if (S != null && S != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }
    }

    void Start()
    {
        changeCursorTexture(normalCursor); 
    }

    public void changeCursorTexture(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void Update()
    {
        
    }
}
