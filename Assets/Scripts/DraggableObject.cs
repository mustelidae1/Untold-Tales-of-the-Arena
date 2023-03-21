using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private SnapArea overlap = null;
    private PuzzleObject po;

    public AudioClip interactSound; 

    void Start()
    {
        po = GetComponent<PuzzleObject>(); 
    }

    void OnMouseEnter() {
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
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (GameManager.S.currentPuzzle.isSolved) return; 
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        
        curPosition.x = Mathf.Clamp(curPosition.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth); 
        curPosition.y = Mathf.Clamp(curPosition.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        if (GameManager.S.currentPuzzle.isSolved) return;
        if (overlap)
        {
            SoundEffectManager.S.playSound(interactSound);
            Vector3 newPos = new Vector3(overlap.gameObject.transform.position.x + overlap.offset.x, overlap.gameObject.transform.position.y + overlap.offset.y, transform.position.z);
            transform.position = newPos;
            if (overlap.gameObject == po.match)
            {
                po.setCorrect(); 
            } else
            {
                po.setIncorrect(); 
            }
        } else
        {
            po.setIncorrect(); 
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SnapArea snap = collision.gameObject.GetComponent<SnapArea>();
        if (snap)
        {
            overlap = snap;
            //snap.highlight(); 
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (overlap) overlap.unhighlight(); 
        if (overlap == collision.GetComponent<SnapArea>())
        {
            overlap = null;
        }   
    }
}
