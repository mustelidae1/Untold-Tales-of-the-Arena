using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    public symbol sym; 

    void Start()
    {
        if (GameManager.S.hasReward(sym))
        {
            this.gameObject.SetActive(false); 
        }
    }
}
