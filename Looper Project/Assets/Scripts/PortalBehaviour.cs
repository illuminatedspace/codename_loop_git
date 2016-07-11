using UnityEngine;
using System.Collections;

public class PortalBehaviour : MonoBehaviour {
	
	// Function for when an object walks into the trigger colider (Should destroy the object).
	
	public GameObject targetPosition;
    public AudioClip portalSound;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Teleporting");
        AudioSource.PlayClipAtPoint(portalSound, transform.position, 0.8f);
        other.transform.position = targetPosition.transform.position;
        
	}
	
}
