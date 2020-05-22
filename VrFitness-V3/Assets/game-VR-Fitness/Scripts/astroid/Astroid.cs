using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Equals("PlayerShip"))
        {
            Destroy(collision.gameObject);
        }
    }
}
