using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrp_SplashScreen : MonoBehaviour {

    public float timer = 3f;
    public string levelToLoad = "Level01";

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("DisplayScene");
	}
	
    IEnumerator DisplayScene()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(levelToLoad);
    }
}
