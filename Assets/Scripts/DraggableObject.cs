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

    void OnMouseEnter() {
        CursorChanger.S.changeCursorTexture(CursorChanger.S.handCursor); 
    }

    void OnMouseExit()
    {
        CursorChanger.S.changeCursorTexture(CursorChanger.S.normalCursor);
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        
        curPosition.x = Mathf.Clamp(curPosition.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth); 
        curPosition.y = Mathf.Clamp(curPosition.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        
        transform.position = curPosition;
    }
}
