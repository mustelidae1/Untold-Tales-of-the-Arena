using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolKeyChecker : MonoBehaviour
{
    public SymbolKey symKey;
    public GameObject reward; 

    void Start()
    {
        GameManager.S.showSymKeyButton(false); 
        GameManager.S.updateRewards(symKey);
        foreach (Transform c in transform)
        {
            UnlockableItem u = c.GetComponent<UnlockableItem>();
            if (u && !u.gameObject.activeSelf) return; 
        }
        // all the symbols are activated 
        reward.SetActive(true); 
    }

    void OnDestroy()
    {
        GameManager.S.showSymKeyButton(true);
    }

}
