using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("astroid") || collision.gameObject.tag.Equals("projectileEnemy") || collision.gameObject.tag.Equals("enemy"))
        {
            //Debug.Log("i got hit");
            Destroy(collision.gameObject);                
            PlayerStats.Addamage();
            PlayerStats.ResetMultiplier();
        }
    }
}
