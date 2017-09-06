using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpCamera1 : MonoBehaviour {

    //var camTarget
    //Vector3 camTarget;
    // Use this for initialization
    public int DistanceAwayX = 0;
    public int DistanceAwayY = 0;
    public int DistanceAwayZ = 0;
    
    void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        
        Vector3 PlayerPOS = GameObject.Find("CarModel").transform.transform.position;
        GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x + DistanceAwayX, PlayerPOS.y + DistanceAwayY, PlayerPOS.z - DistanceAwayZ);
    }
}
