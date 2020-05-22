using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Rigidbody[] prefab;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > 1)
        {
            float randomFor = Random.Range(3, 6);

            for (int i = 0; i < randomFor; i++)
            {
                float randomX = Random.Range(-1.5f, 1.5f);
                float randomY = Random.Range(-1.0f, 1.5f);
                float randomZ = Random.Range(-1.5f, 1.5f);
                float randomSpeed = Random.Range(-30, -10);
                float randomType = Random.Range(10, 100);
                Rigidbody clone;

                if (randomType > 20)
                {
                    clone = Instantiate(prefab[0], new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + randomZ), transform.rotation);
                    clone.velocity = transform.TransformDirection(Vector3.forward * randomSpeed);
                    clone.angularVelocity = new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1));
                }
                else
                {
                    clone = Instantiate(prefab[1], new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + randomZ), transform.rotation);
                    clone.velocity = transform.TransformDirection(Vector3.forward * randomSpeed/2);
                }

               
               
            }
           

            timer = 0;
        }

        //Instantiate(prefab, transform.position, Quaternion.identity);
       
    }
}
