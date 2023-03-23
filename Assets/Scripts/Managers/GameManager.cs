using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public GameObject symbolKeyButton;
    public SymbolKey symbolKey;
    public GameObject introEnvelope; 

    private List<symbol> rewards; 

    public Puzzle currentPuzzle;
    public bool interactionDisabled = false;


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
        DontDestroyOnLoad(symbolKeyButton);
        DontDestroyOnLoad(symbolKey);
        introEnvelope.SetActive(true); 
        rewards = new List<symbol>(); 
    }

    public void addReward(symbol sym)
    {
        rewards.Add(sym);
        symbolKey.activateSymbolKey(sym); 
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


