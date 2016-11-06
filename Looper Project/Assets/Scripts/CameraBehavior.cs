using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	private Transform playerSprite;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
        playerSprite = GameObject.FindObjectOfType<PlayerScript>().transform;
		offset = transform.position - playerSprite.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = playerSprite.position + offset;
	}
}
