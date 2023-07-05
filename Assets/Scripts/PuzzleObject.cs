using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    public bool isCorrect = false;

    public correctType correctType;
    public GameObject match;

    void OnMouseDown()
    {
        if (GameManager.S.currentPuzzle.isSolved || !(correctType == correctType.selected)) return;
        setCorrect(); 
        
    }

    public void setCorrect()
    {
        isCorrect = true;
        GameManager.S.currentPuzzle.checkSolution(); 
    }

    public void setIncorrect()
    {
        isCorrect = false; 
    }

    public void moveToCorrect()
    {
        if (correctType == correctType.matched)
        {
            SnapArea sa = match.GetComponent<SnapArea>();
            Vector3 newPos = new Vector3(sa.gameObject.transform.position.x + sa.offset.x, sa.gameObject.transform.position.y + sa.offset.y, transform.position.z);
            Quaternion newRot = sa.gameObject.transform.rotation;
            transform.position = newPos;
            transform.rotation = newRot;
            transform.SetParent(null); 
        }
    }
}

public enum correctType
{
    selected, 
    matched, 
    collide
}