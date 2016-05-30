using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	     if (Input.GetButtonDown("Fire3"))
        {
            SceneManager.LoadScene("main");
        }
    }
}
