using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
    //publc variables
    public string[] dialogueTextList;

    public static bool colorChange, textChange;

    //private variables
    private Text text;
    private Color targetColor;
    private int loopCount, loopLimit;

    // Used before initialization
    void Awake () {
        colorChange = false;
        textChange = false;
    }

	// Use this for initialization
	void Start () {
        InitializePrivateVariables();
        Debug.Log("loopLimit is " + loopLimit);
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
        text.text = dialogueTextList[loopCount];
        if (loopCount >= loopLimit - 1) {
            Debug.Log("loop cycle reset!!!");
            loopCount = 0;
        } else {
            loopCount++;
        }
        textChange = false;
    }

    // Initializes private variables
    void InitializePrivateVariables() {
        text = GetComponent<Text>();

        loopCount = 0;
        loopLimit = dialogueTextList.Length;

        targetColor = text.color;
        targetColor.a = 0f;
        text.color = targetColor;
    }
}
