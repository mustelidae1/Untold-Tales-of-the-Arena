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
    private Vector3 originalPos;
    private Quaternion originalRot; 

    public AudioClip interactSound;

    public bool isDestructable = false; 

    void Start()
    {
        po = GetComponent<PuzzleObject>();
        originalPos = this.gameObject.transform.position;
        originalRot = this.gameObject.transform.rotation; 
    }

    void OnMouseEnter() {
        if (GameManager.S.currentPuzzle.isSolved && po.correctType == correctType.matched) return;
        if (!CursorChanger.S) return; 
        CursorChanger.S.changeCursorTexture(CursorChanger.S.handCursor); 
    }

    void OnMouseExit()
    {
        if (!CursorChanger.S) return;
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
        if (GameManager.S.currentPuzzle.isSolved && po.correctType == correctType.matched) return;
    }

    void OnMouseDown()
    {
        if (GameManager.S.currentPuzzle.isSolved && po.correctType == correctType.matched) return;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (GameManager.S.currentPuzzle.isSolved && po.correctType == correctType.matched) return; 
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
        if (GameManager.S.currentPuzzle.isSolved && po.correctType == correctType.matched) return;
        if (overlap)
        {
            SoundEffectManager.S.playSound(interactSound);
            Vector3 newPos = new Vector3(overlap.gameObject.transform.position.x + overlap.offset.x, overlap.gameObject.transform.position.y + overlap.offset.y, transform.position.z);
            Quaternion newRot = overlap.gameObject.transform.rotation; 
            transform.position = newPos;
            transform.rotation = newRot; 
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
            if (isDestructable)
            {
                transform.position = originalPos;
                transform.rotation = originalRot; 
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SnapArea snap = collision.gameObject.GetComponent<SnapArea>();
        CollideArea col = collision.gameObject.GetComponent<CollideArea>(); 
        if (snap && po.correctType == correctType.matched)
        {
            overlap = snap;
            //snap.highlight(); 
        } 
        if (col && po.correctType == correctType.collide)
        {
            if (col.gameObject == po.match)
            {
                po.setCorrect(); 
            }
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
