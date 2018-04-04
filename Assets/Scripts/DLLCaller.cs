using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using TestCSharpLibrary;

public class DLLCaller : MonoBehaviour
{
    public GameObject player;

    float playerPosX;
    float playerPosY;
    float playerPosZ;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;
        playerPosZ = player.transform.position.z;
        //Debug.Log(playerPosX);
        //Debug.Log(playerPosY);
        //Debug.Log(playerPosZ);

        TestCSharpLibrary.TestCSharpLibrary.SetPlayerPosX(player.transform.position.x);
        TestCSharpLibrary.TestCSharpLibrary.SetPlayerPosY(player.transform.position.y);
        TestCSharpLibrary.TestCSharpLibrary.SetPlayerPosZ(player.transform.position.z);

    }
}
