using UnityEngine;
using System.Collections;

public class BackgroundFollow : MonoBehaviour
{

    public PlayerSc playerSprite;

    private Vector3 playerToBackground;

    // Use this for initialization
    void Start()
    {
        playerToBackground = this.transform.position - playerSprite.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerSprite.transform.position + playerToBackground;
    }
}