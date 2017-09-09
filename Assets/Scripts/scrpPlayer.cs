using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpPlayer : MonoBehaviour {

    //To make it so that the car doesn't keep driving like a spaz in the air, maybe do a check for if colliding on ground then drive, if not then 
    // use the buttons to rotate. Or maybe even just not be able to do anything unless youre driving on the ground.


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

        //Forward
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * speedP1 * Time.deltaTime);
		}
			
        //Back
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back * speedP1 * Time.deltaTime);
		}

        //Right
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0, Time.deltaTime * 200.0f, 0);
		}

        //Left
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0, Time.deltaTime * -200.0f, 0);
		}

        //Shoot
		if (Input.GetKey(KeyCode.Space))
		{
			GameObject copy = Instantiate(m_BulletPrefab);
			copy.transform.position = transform.position + transform.forward;

			Rigidbody rb = copy.GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * 1000, ForceMode.Acceleration);
			//++bulletCountP1;
		}

        //Boost Start
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedP1 = speedP1 * 5;
        }

        //Boost finish
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedP1 = speedP1 / 5;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
        }

        //Quit
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}


	}
}
