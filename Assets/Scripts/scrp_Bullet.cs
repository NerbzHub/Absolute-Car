using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrp_Bullet : MonoBehaviour
{

    //Used to colour bullet
    public Material[] materials;

    public int m_Team;

    //--------------------------------------------------------------------------------------
    // Set colour for bullet
    //
    // Param
    //		teamValue: Which team the bullet is on
    //--------------------------------------------------------------------------------------
    public void SetDetails(int teamValue)
    {
        m_Team = teamValue;
        //Get within range of a array - player 1 is array[0]
        if (materials.Length > m_Team - 1)
            GetComponent<Renderer>().sharedMaterial = materials[m_Team - 1];
    }
}
