using UnityEngine;
using System.Collections;

public class Welcome_screen : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void StartGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
