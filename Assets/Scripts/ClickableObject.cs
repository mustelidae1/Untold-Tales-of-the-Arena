using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Create a public UnityEvent to invoke so this script can be generic? 
    public GameObject go;
    public AudioClip sound;

    public bool OverrideInteractionDisabled = false; 

    public bool isDestructable = false;  

    void OnMouseEnter() {
        if (GameManager.S.interactionDisabled && !OverrideInteractionDisabled) return;
        CursorChanger.S.changeCursorTexture(CursorChanger.S.highlightedCursor); 
    }

    void OnMouseExit()
    {
        if (GameManager.S.interactionDisabled && !OverrideInteractionDisabled) return;
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
    }

    void OnMouseDown()
    {
        if (GameManager.S.interactionDisabled && !OverrideInteractionDisabled) return;
        go.SetActive(true);
        SoundEffectManager.S.playSound(sound);
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
        if (isDestructable) this.gameObject.SetActive(false); 
    }
}
