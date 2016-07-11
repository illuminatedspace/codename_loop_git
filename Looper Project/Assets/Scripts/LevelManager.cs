using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    static LevelManager instance = null;
    static public SceneManager sceneManager;
    

    // public variables
    public float autoLoadNextLevelAfter;
 

//    void Awake() {
//        if (instance != null && instance != this)
//        {
//            Destroy(gameObject);
//        } else {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//    }

    void Start(){
        if(autoLoadNextLevelAfter <= 0){
            Debug.Log("Auto level disabled");
        } else{
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
     }

	public void LoadLevel(string name)  {
	
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
	}

	public void QuitRequest()   {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLevel() {
        //get's current scene index for future use
        Debug.Log("Loading next scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //adds one to the current scene index
    }
}
