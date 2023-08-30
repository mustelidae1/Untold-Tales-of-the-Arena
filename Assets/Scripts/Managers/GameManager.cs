using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public GameObject symbolKeyButton;
    public GameObject settingsButton;
    public GameObject settingsPage; 
    public SymbolKey symbolKey;
    public GameObject introEnvelope; 

    private List<symbol> rewards;
    private List<symbol> puzzlesSolved; 

    public Puzzle currentPuzzle;
    public bool interactionDisabled = false;

    public bool menu = false; 


    void Start()
    {
        S = this; 
        if (menu) return;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(symbolKeyButton);
        DontDestroyOnLoad(symbolKey);
        DontDestroyOnLoad(settingsButton);
        DontDestroyOnLoad(settingsPage); 
        introEnvelope.SetActive(true); 
        rewards = new List<symbol>();
        puzzlesSolved = new List<symbol>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

public void addReward(symbol sym)
    {
        if (hasReward(sym)) return; 
        rewards.Add(sym);
        symbolKey.activateSymbolKey(sym); 
    }

    public void addPuzzleSolved(symbol sym)
    {
        if (hasPuzzleSolved(sym)) return; 
        puzzlesSolved.Add(sym);
    }

    public void updateRewards(SymbolKey symKey)
    {
        symKey.clearSymbolKeys(); 
        foreach (symbol sym in rewards)
        {
            symKey.activateSymbolKey(sym, false); 
        }
    }

    public bool hasReward(symbol sym)
    {
        return rewards.Contains(sym); 
    }

    public bool hasPuzzleSolved(symbol sym)
    {
        return puzzlesSolved.Contains(sym);
    }

    public void showSymKeyButton(bool show)
    {
        symbolKeyButton.SetActive(show); 
    }
}

public enum symbol
{
    sword, // Mars 
    trident, // Poseidon 
    crown, // Juno 
    sun, // Sol Invictus 
    caduceus, // Mercury 
    lightning, // Jupiter
    none
}


