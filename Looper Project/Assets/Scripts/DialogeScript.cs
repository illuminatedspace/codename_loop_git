using UnityEngine;
using System.Collections;

public class DialogeScript : MonoBehaviour
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

        HandleTextScript(Mathf.Clamp(spriteImg.color.a,0f,1f));
    }

    void HandleTextScript(float currentBoxColor) {
        Debug.Log("Current alpha color of DialogueBox img is: " + currentBoxColor);

        if (currentBoxColor >= 0.98f) {
            TextScript.colorChange = true;
        } else if (currentBoxColor <= 0.4f) {
            TextScript.colorChange = false;
        }
    }

    void ShowMyDialogueBox() {
        targetColor.a = 1f;
        TextScript.textChange = true;
    }

    void HideMyDialogueBox() {
        targetColor.a = 0;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Entered collider");
        ShowMyDialogueBox();
    }

    void OnTriggerExit2D(Collider2D collider) {
        Debug.Log("Exited collider");
        HideMyDialogueBox();
    }

}