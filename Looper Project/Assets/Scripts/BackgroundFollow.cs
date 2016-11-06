using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundFollow : MonoBehaviour
{

    private Transform playerSprite;

    private Vector3 playerToBackground;

    // Use this for initialization
    void Start()
    {
        playerSprite = GameObject.FindObjectOfType<PlayerScript>().transform;
        playerToBackground = this.transform.position - playerSprite.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerSprite.position + playerToBackground;
    }
}