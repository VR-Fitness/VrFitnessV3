using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShit : MonoBehaviour
{
    private int Health;

    // Start is called before the first frame update
    void Start()
    {
         Health = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {
        Damage();
    }



void Damage()
    {
        Health -=10;
        if (Health <= 0)
        {  // return;
            //Destroy(GameObject);
            // HEALTHBAR eller HEALTH POINT TAVLE
            //animfat.SetBool("Explosion", true);
            
        }
    }
    void Attack()
    { }
}
