using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class scrp_Player : MonoBehaviour {

    //To make it so that the car doesn't keep driving like a spaz in the air, maybe do a check for if colliding on ground then drive, if not then 
    // use the buttons to rotate. Or maybe even just not be able to do anything unless youre driving on the ground.

    //Key varibles
    //Decide what player this is
    public int m_Player = 1;
    private int m_PlayerScore = 0;
    public GameObject m_BulletPrefab = null;
    public GameObject m_UserInterface = null;
    private bool m_Grounded = true;
    private float m_SpawnDistance = 0.0f;

    //Used for explosion
    public ParticleSystem m_Explosion;

    //A public float for speed.
    public float m_Speed = 10.0f;
    public float m_RotateSpeed = 200.0f;
    public float m_BoostSpeed = 20.0f;
    public float m_JumpSpeed = 5.0f;
    
    //Inputs
    private string m_HorizontalAxis = "";
    private string m_VerticalAxis = "";
    private string m_Fire = "";
    private string m_Jump = "";
    private string m_Boost = "";

    //Shooting
    public float m_FireDelay= 0.5f;
    private float m_FireTimer = 0.5f;
    public float m_FireForce = 15.0f;

	

    // Use this for initialization
    void Awake ()
	{
        //Set player controls
        switch(m_Player)
        {
        case 1:
            m_HorizontalAxis = "Player1Horizontal";
            m_VerticalAxis = "Player1Vertical";
            m_Fire = "Player1Fire";
            m_Jump = "Player1Jump";
            m_Boost = "Player1Boost";
            break;
        case 2:
            m_HorizontalAxis = "Player2Horizontal";
            m_VerticalAxis = "Player2Vertical";
            m_Fire = "Player2Fire";
            m_Jump = "Player2Jump";
            m_Boost = "Player2Boost";
            break;
        }

        m_SpawnDistance = GetComponent<Collider>().bounds.size.z;
    }
	
	// Update is called once per frame
	void Update ()
    {

        //Forward/Back
        float speed = CrossPlatformInputManager.GetAxis("Vertical") * m_Speed;

        //Mobile Controls
        if (CrossPlatformInputManager.GetButton("BoostButton"))
            speed += m_BoostSpeed;
        transform.Translate(speed * Vector3.forward * Time.deltaTime);


        //Left/Right
        transform.Rotate(0, CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * m_RotateSpeed, 0);

		//Jump
		if (CrossPlatformInputManager.GetButton("JumpButton") && m_Grounded)
		{
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * m_JumpSpeed, ForceMode.Impulse);
			m_Grounded = false;
		}

		//Shoot
		if (CrossPlatformInputManager.GetButton("FireButton") && m_FireTimer<0)
		{
			
			//Position new bullet
			GameObject bullet = Instantiate(m_BulletPrefab);
            bullet.transform.position = transform.position + transform.forward * m_SpawnDistance;

            //Rotate to right direction
            bullet.transform.rotation = transform.rotation;

            //Need to fix in model
            bullet.transform.Rotate(Vector3.left, 90);

            //Fire Bullet
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * m_FireForce, ForceMode.Impulse);

            bullet.GetComponent<scrp_Bullet>().SetDetails(m_Player);
            m_FireTimer = m_FireDelay;

        }
        m_FireTimer -= Time.deltaTime;

        

		//If flip button pressed
		//Get whichever is larger:	
		//transform.localEulerAngles.x
		//transform.localEulerAngles.z

		//Add a force that flips back by that much
		//GetComponent<Rigidbody>().angularVelocity

		//Quit
		if (Input.GetAxisRaw("Menu") != 0)
		{
			Application.Quit();
		}
	}

    void OnCollisionEnter(Collision col)
    {
        //Lands on groud
        if (col.gameObject.tag == "Arena")
        {
            m_Grounded = true;
			
        }
		
        //Hit by bullet
        if (col.gameObject.tag == "Bullet")
        {
            //Debug.Log("Hit");
            if (col.gameObject.GetComponent<scrp_Bullet>().m_Team != m_Player)
                m_PlayerScore++;
            else
                m_PlayerScore--;

            m_UserInterface.GetComponent<scrp_UserInterface>().UpdateScore(col.gameObject.GetComponent<scrp_Bullet>().m_Team, m_PlayerScore);

            //Create explosion
            ParticleSystem explosion = Instantiate(m_Explosion, transform.position, transform.rotation);
            Destroy(explosion.gameObject, explosion.main.duration);

            Destroy(col.gameObject);
        }
    }
}
