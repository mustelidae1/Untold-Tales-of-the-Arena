using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NavigationObject : MonoBehaviour
{
    public directions direction;
    public String destinationScene;
    public bool changeRoom = true;
    public bool changePage = false;
    public bool exit = false; 
    public AudioClip sound;
    public List<GameObject> collidersToHide;
    public List<GameObject> collidersToShow;

    public bool OverrideInteractionDisabled = false;
    public List<GameObject> pages;
    public GameObject page;

    public bool stopMusic = false; 

    void OnMouseEnter()
    {
        if (GameManager.S && GameManager.S.interactionDisabled && !OverrideInteractionDisabled) return; 
        if (!CursorChanger.S) return; 
        if (direction == directions.left)
        {
            CursorChanger.S.changeCursorTexture(CursorChanger.S.leftArrowCursor);
        }
        else if (direction == directions.right)
        {
            CursorChanger.S.changeCursorTexture(CursorChanger.S.rightArrowCursor); 
        }
        else if (direction == directions.down)
        {
            CursorChanger.S.changeCursorTexture(CursorChanger.S.downArrowCursor); 
        }
        else if (direction == directions.up)
        {
            CursorChanger.S.changeCursorTexture(CursorChanger.S.upArrowCursor);
        }
        else if (direction == directions.none)
        {
            CursorChanger.S.changeCursorTexture(CursorChanger.S.highlightedCursor);
        }
    }

    void OnMouseExit()
    {
        if (GameManager.S && GameManager.S.interactionDisabled && !OverrideInteractionDisabled) return;
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
    }

    void OnMouseDown()
    {
        if (GameManager.S && GameManager.S.interactionDisabled && !OverrideInteractionDisabled) return;
        if (exit) Application.Quit();
        if (changeRoom)
        {
            Debug.Log("Navigate to " + destinationScene);
            SceneManager.LoadScene(destinationScene);
        } else if (changePage)
        {
            foreach (GameObject g in pages)
            {
                g.SetActive(false); 
            }
            if (page != null) page.SetActive(true); 
        } else 
        {
            gameObject.transform.parent.gameObject.SetActive(false); 
        }
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
        SoundEffectManager.S.playSound(sound);
        if (stopMusic) SoundEffectManager.S.stopMusic();
        foreach (GameObject g in collidersToHide)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in collidersToShow)
        {
            g.SetActive(true);
        }
    }
}

public enum directions
{
    left,
    right,
    down, 
    up, 
    none
}
