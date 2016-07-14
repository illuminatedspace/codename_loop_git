using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
    //publc variables
    public Text text;
    public string[] dialogueText;
    public static bool colorChange;
    public static bool textChange;

    //private variables
    private Color targetColor;
    private int loopCount;
    private int loopLimit;

    // Used before initialization
    void Awake () {
        colorChange = false;
        textChange = false;
    }

	// Use this for initialization
	void Start () {
        loopCount = 0;
        loopLimit = dialogueText.Length;
        Debug.Log("loopLimit is " + loopLimit);
        targetColor = text.color;
        targetColor.a = 0f;
        text.color = targetColor;
	}
	
	// Update is called once per frame
	void Update () {
	    if (colorChange){
            showText();
        } else {
            hideText();
        }

        if (textChange) {
            cycletText();
        }
    }

    void showText() {
        targetColor.a = 1f;
        text.color = targetColor;
        Debug.Log("Text Should appear!");
    }

    void hideText() {
        targetColor.a = 0f;
        text.color = targetColor;
        Debug.Log("Text should dissapear!");
    }

    void cycletText() {
        Debug.Log("cycle text has occured! loopCount is: " + loopCount);
        text.text = dialogueText[loopCount];
        if (loopCount >= loopLimit - 1) {
            Debug.Log("loop cycle reset!!!");
            loopCount = 0;
        } else {
            loopCount++;
        }
        textChange = false;
    }
}
