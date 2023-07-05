using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolKeyChecker : MonoBehaviour
{
    public SymbolKey symKey;

    void Start()
    {
        GameManager.S.showSymKeyButton(false); 
        GameManager.S.updateRewards(symKey);
    }

    void OnDestroy()
    {
        GameManager.S.showSymKeyButton(true);
    }

}
