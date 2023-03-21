using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    public bool isCorrect = false;

    public correctType correctType;
    public GameObject match; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            transform.position = newPos; 
        }
    }
}

public enum correctType
{
    selected, 
    matched
}