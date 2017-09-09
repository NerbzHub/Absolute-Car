using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrp_Camera : MonoBehaviour {

    public bool m_RightScreen = false;
    public GameObject m_Target = null;

    public float m_CameraDistace = 8.0f;
	// Use this for initialization
	void Awake ()
    {
		if(m_RightScreen)
        {
            GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(m_Target!= null)
        {
            //Set rotation
            Vector3 cameraRot = transform.rotation.eulerAngles;
            cameraRot.y = m_Target.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(cameraRot);

            //Set position
            transform.position = m_Target.transform.position - (transform.forward * m_CameraDistace);
        }
	}
}
