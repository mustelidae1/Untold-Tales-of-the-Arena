using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolKey : MonoBehaviour
{
    public void activateSymbolKey(symbol sym)
    {
        foreach (Transform c in transform)
        {
            UnlockableItem u = c.GetComponent<UnlockableItem>(); 
            if (u && u.sym == sym)
            {
                u.gameObject.SetActive(true); 
            }
        }
    }
}
