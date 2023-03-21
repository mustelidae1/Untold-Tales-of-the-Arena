using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    private List<symbol> rewards; 

    public Puzzle currentPuzzle; 
    // some variable to keep track of how many symbols we've collected 

    void Awake()
    {
        if (S != null && S != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }
        DontDestroyOnLoad(gameObject);
        rewards = new List<symbol>(); 
    }

    public void addReward(symbol sym)
    {
        rewards.Add(sym); 
    }

    public bool hasReward(symbol sym)
    {
        return rewards.Contains(sym); 
    }
}

public enum symbol
{
    sword, // Mars 
    trident, // Poseidon 
    crown, // Juno 
    sun, // Sol Invictus 
    caduceus, // Mercury 
    lightning // Jupiter 
}
