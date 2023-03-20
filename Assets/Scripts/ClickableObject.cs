using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Create a public UnityEvent to invoke so this script can be generic? 
    public GameObject gameObject;
    public AudioClip sound; 

    void OnMouseEnter() {
        CursorChanger.S.changeCursorTexture(CursorChanger.S.highlightedCursor); 
    }

    void OnMouseExit()
    {
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
    }

    void OnMouseDown()
    {
        gameObject.SetActive(true);
        SoundEffectManager.S.playSound(sound);
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
    }
}
