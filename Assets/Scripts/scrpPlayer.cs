using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpPlayer : MonoBehaviour {

	//A public float for speed.
	public float speedP1 = 1.0f;
	public GameObject m_BulletPrefab = null;
	//public int bulletCountP1 = 0;

    ////Camera
    //public float cameraDistOffset = 10;
    //private Camera player1Cam;
    //private GameObject player1;

	// Use this for initialization
	void Awake ()
	{
        //player1Cam = GetComponent<Camera>();
        //player1 = GameObject.Find("Player1")
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log(bulletCountP1);

		Vector3 pos;
		pos.x = transform.position.x;

		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * speedP1 * Time.deltaTime);
		}
			
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back * speedP1 * Time.deltaTime);
		}


		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0, Time.deltaTime * 200.0f, 0);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0, Time.deltaTime * -200.0f, 0);
		}

		if (Input.GetKey(KeyCode.Space))
		{
			GameObject copy = Instantiate(m_BulletPrefab);
			copy.transform.position = transform.position + transform.forward;

			Rigidbody rb = copy.GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * 1000, ForceMode.Acceleration);
			//++bulletCountP1;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
