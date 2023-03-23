using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lens : MonoBehaviour
{
    // from https://www.youtube.com/watch?v=UJ4w5V5aTP4

    public Transform smallSheet, bigSheet;
    
    void Update()
    {
        bigSheet.position = smallSheet.position * 2 - transform.position; 
    }
}
