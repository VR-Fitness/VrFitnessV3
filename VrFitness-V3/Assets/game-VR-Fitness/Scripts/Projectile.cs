using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{  public GameObject explosion;
    public string tagName;

    /*
    private void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.tag.Equals(tagName))
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                GameObject clone = Instantiate(explosion, transform.position, transform.rotation);

            }
        

    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(tagName))
        {
            //Destroy(collision.gameObject);
            GameObject clone = Instantiate(explosion, transform.position, transform.rotation);
            clone.transform.parent = collision.transform;
            Destroy(this.gameObject);


        }
        else
        {
            GameObject clone = Instantiate(explosion, transform.position, transform.rotation);
            clone.transform.parent = collision.transform;
            Destroy(this.gameObject);
        }
    }


    /*
    private void OnTriggerEnter(Collider other)
    {
      
            if (other.gameObject.tag.Equals(tagName))
            {           
                Destroy(other.gameObject);
                GameObject clone = Instantiate(explosion, transform.position, transform.rotation);
                clone.transform.parent = other.transform;
                Destroy(this.gameObject);
              

            }
            else
            {
              GameObject clone = Instantiate(explosion, transform.position, transform.rotation);
              clone.transform.parent = other.transform;
              Destroy(this.gameObject);
             }
        
    }

    */

}
