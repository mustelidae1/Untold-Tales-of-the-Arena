using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{

    // win condition 
    public List<PuzzleObject> puzzleObjects; 

    // reward 
    public symbol reward;

    public bool isSolved = false; 

    void Start()
    {
        GameManager.S.currentPuzzle = this; 
        // TODO make this work
        if (GameManager.S.hasReward(reward)) // we already solved the puzzle 
        {
            foreach (PuzzleObject po in puzzleObjects)
            {
                po.setCorrect(); 
                po.moveToCorrect(); 
            }
        }
    }

    public void checkSolution()
    {
        if (isSolved) return; 
        foreach (PuzzleObject o in puzzleObjects)
        {
            if (!o.isCorrect)
            {
                isSolved = false;
                return; 
            } 
        }
        isSolved = true;
        Debug.Log("PUZZLE SOLVED");
        GameManager.S.addReward(reward); 
    }
}
