using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{

    // win condition 
    public List<PuzzleObject> puzzleObjects;
    public List<GameObject> rewardObjects;
    public List<GameObject> hideObjects; 
    public Animator objectToAnimate; 

    public AudioClip successSound; 

    // reward 
    public symbol reward;

    public bool isSolved = false; 

    void Start()
    {
        GameManager.S.currentPuzzle = this; 
        if (GameManager.S.hasPuzzleSolved(reward)) // we already solved the puzzle (we use this instead of isSolved because that doesn't persist) 
        {
            foreach (PuzzleObject po in puzzleObjects)
            {
                //po.setCorrect(); 
                po.moveToCorrect(); 
            }
            foreach (GameObject g in rewardObjects)
            {
                g.SetActive(true);
            }
            foreach (GameObject g in hideObjects)
            {
                g.SetActive(false);
            }
        }
    }

    public void checkSolution()
    {
        if (GameManager.S.hasPuzzleSolved(reward)) return; // we use this instead of isSolved because that doesn't persist 
        foreach (PuzzleObject o in puzzleObjects)
        {
            if (!o.isCorrect)
            {
                isSolved = false;
                return; 
            } 
        }
        isSolved = true;
        if (successSound != null) SoundEffectManager.S.playSound(successSound);
        Debug.Log("PUZZLE SOLVED");
        GameManager.S.addPuzzleSolved(reward); 
        //GameManager.S.addReward(reward); // no longer doing this in favor of having them click on the sticky note to get the reward
        foreach (GameObject g in rewardObjects)
        {
            g.SetActive(true); 
        }
        foreach (GameObject g in hideObjects)
        {
            g.SetActive(false);
        }
        if (objectToAnimate != null)
        {
            objectToAnimate.Play("Grow");
        }
    }
}
