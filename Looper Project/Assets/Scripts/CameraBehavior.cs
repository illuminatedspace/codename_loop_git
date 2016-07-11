using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	public PlayerSc playerSprite;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - playerSprite.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = playerSprite.transform.position + offset;
	}
}
