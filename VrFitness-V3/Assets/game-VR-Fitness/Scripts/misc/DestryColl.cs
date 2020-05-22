using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryColl : MonoBehaviour
{

    public GameObject DeathExplosionEffect; // gameobject to spawn when enemy dies

    private void OnCollisionEnter(Collision collision)
    {
        PlayerStats.AddMultiplierValue();
        DestroySelf();
       
    }


    //destroy self method
    private void DestroySelf() // destroy self and spawn explsion gameopbject
    {
        GameObject cloneExplosion = Instantiate(DeathExplosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
