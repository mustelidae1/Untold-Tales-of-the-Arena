using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NavigationObject : MonoBehaviour
{
    public directions direction;
    public String destinationScene;
    public bool changeRoom = true;
    public AudioClip sound; 

    void OnMouseEnter()
    {
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
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
    }

    void OnMouseDown()
    {
        if (changeRoom)
        {
            Debug.Log("Navigate to " + destinationScene);
            SceneManager.LoadScene(destinationScene);
        } else
        {
            gameObject.transform.parent.gameObject.SetActive(false); 
        }
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
        SoundEffectManager.S.playSound(sound); 
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
