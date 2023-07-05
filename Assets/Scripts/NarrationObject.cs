using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationObject : MonoBehaviour
{
    public AudioClip sound;
    public bool requiresClick; 

    void Start()
    {
        if (!requiresClick)
        {
            SoundEffectManager.S.playNarration(sound);
        }
    }

    void OnMouseDown()
    {
        if (!requiresClick) return; 
        SoundEffectManager.S.playNarration(sound);
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
    }

    void OnMouseEnter()
    {
        CursorChanger.S.changeCursorTexture(CursorChanger.S.highlightedCursor);
    }

    void OnMouseExit()
    {
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
    }
}
