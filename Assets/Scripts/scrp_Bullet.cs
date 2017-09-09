using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrp_Bullet : MonoBehaviour {

    //Used to colour bullet
    public Material[] materials;
    //Used for explosion
    public ParticleSystem m_Explosion;
    public int m_Team;

    //Set colour for bullet
    public void SetDetails(int teamValue)
    {
        m_Team = teamValue;
        //Get within range of a array - player 1 is array[0]
        if (materials.Length > m_Team - 1)
            GetComponent<Renderer>().sharedMaterial = materials[m_Team - 1];
	}

    void OnDestroy()
    {
        //Create explosion
        ParticleSystem explosion = Instantiate(m_Explosion, transform.position, transform.rotation);
        Destroy(explosion.gameObject, explosion.main.duration);
    }
}
