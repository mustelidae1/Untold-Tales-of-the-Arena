using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolKey : MonoBehaviour
{
    public Animator keyThumb; 

    public void activateSymbolKey(symbol sym, bool anim=true)
    {
        if (anim)
        {
            keyThumb.Play("KeyGrow");
        }
        foreach (Transform c in transform)
        {    
            UnlockableItem u = c.GetComponent<UnlockableItem>(); 
            if (u && u.sym == sym)
            {
                u.gameObject.SetActive(true); 
            }
        }
    }

    public void clearSymbolKeys()
    {
        foreach (Transform c in transform)
        {
            c.gameObject.SetActive(false);
        }
    }
}
