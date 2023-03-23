using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPuzzleObject : MonoBehaviour
{
    public GameObject obj; 

    void OnMouseEnter()
    {
        if (GameManager.S.currentPuzzle.isSolved) return;
        if (!CursorChanger.S) return;
        CursorChanger.S.changeCursorTexture(CursorChanger.S.handCursor);
    }

    void OnMouseExit()
    {
        if (!CursorChanger.S) return;
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
        if (GameManager.S.currentPuzzle.isSolved) return;
    }

    void OnMouseDown()
    {
        if (GameManager.S.currentPuzzle.isSolved) return;
        Instantiate(obj); 
    }

    void OnMouseDrag()
    {

    }

    /*public void OnBeginDrag(PointerEventData eventData)
    {
        Instantiate(obj);
        go.transform.SetParent(parentCanvas.transform, false);
        eventData.pointerDrag = obj; // assign instantiated element
    }*/
}
