using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapArea : MonoBehaviour
{
    public Vector2 offset;
    public Color highlightColor;
    public bool full; 

    private Color originalColor; 

    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color; 
    }

    public void highlight()
    {
        GetComponent<SpriteRenderer>().color = highlightColor;
    }

    public void unhighlight()
    {
        GetComponent<SpriteRenderer>().color = originalColor; 
    }
}
