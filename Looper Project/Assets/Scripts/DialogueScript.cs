﻿using UnityEngine;
using System.Collections;

public class DialogueScript : MonoBehaviour
{
    //public variables
    public SpriteRenderer spriteImg;
    public float transRate;

    //private variables
    private Color targetColor;

    // Use this for initialization
    void Start()
    {
      //  spriteImg.enabled = false;
        targetColor = spriteImg.color;
        targetColor.a = 0;
        spriteImg.color = targetColor;
    }

    // Update is called once per frame
    void Update()
    {
        spriteImg.color = Color.Lerp(spriteImg.color, targetColor, transRate);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Entered collider");
        targetColor.a = 1f;
    }

    void OnTriggerExit2D(Collider2D collider) {
        Debug.Log("Exited collider");
        targetColor.a = 0;
    }

}