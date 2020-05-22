using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideDestroy : MonoBehaviour
{
    public string[] tagName;
 

   


   
    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < tagName.Length; i++)
        {
            if (other.gameObject.tag.Equals(tagName[i]))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
