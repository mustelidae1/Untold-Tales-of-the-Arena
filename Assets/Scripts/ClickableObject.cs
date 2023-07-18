using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Create a public UnityEvent to invoke so this script can be generic? 
    public GameObject go;
    public GameObject additionalGo; 
    public GameObject destroyGo; 
    public AudioClip sound;

    public bool OverrideInteractionDisabled = false; 

    public bool isDestructable = false;
    public bool destroyParent = true; 

    public bool animateSomethingOnce = false;
    public Animator objectToAnimate;

    public bool isReward;
    public symbol reward; 

    void OnMouseEnter() {
        if (GameManager.S && GameManager.S.interactionDisabled && !OverrideInteractionDisabled) return;
        CursorChanger.S.changeCursorTexture(CursorChanger.S.highlightedCursor); 
    }

    void OnMouseExit()
    {
        if (GameManager.S && GameManager.S.interactionDisabled && !OverrideInteractionDisabled) return;
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
    }

    void OnMouseDown()
    {
        if (GameManager.S && GameManager.S.interactionDisabled && !OverrideInteractionDisabled) return;
        if (go != null) go.SetActive(true);
        if (additionalGo != null) additionalGo.SetActive(true);
        SoundEffectManager.S.playSound(sound);
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
        if (isDestructable)
        {
            if (this.gameObject.transform.parent != null && destroyParent)
            {
                this.gameObject.transform.parent.gameObject.SetActive(false); 
            } else
            {
                this.gameObject.SetActive(false);
            }
        } 
        if (destroyGo != null) destroyGo.SetActive(false);
        if (animateSomethingOnce)
        {
            objectToAnimate.Play("Grow");
            animateSomethingOnce = false;
        }
        if (isReward)
        {
            GameManager.S.addReward(reward);
        }
    }
}
