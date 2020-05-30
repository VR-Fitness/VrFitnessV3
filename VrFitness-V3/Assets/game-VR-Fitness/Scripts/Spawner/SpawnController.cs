using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject[] spawnPoints;
    public Rigidbody[] Prefabs;
    public float speed = 10f;
    public float minimumspeed = 3f;
    public int spawnType = 0; // 0 astroid - 1 ship
    public float spawnDelay;
    public float maximumspawnDelay = 3f;
    public float minimumSpawnDelay = 1f;
    public int shipSpawnChanceProcent = 10;
    public int minimumshipSpawnChanceProcent = 5;
    public int maximumshipSpawnChanceProcent = 100;

    private List<Rigidbody> objectsList = new List<Rigidbody>(); // list of  game objects spawned
    private float timerCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        

       



    }

    // Update is called once per frame
    void Update()
    {
        timerCount += Time.deltaTime;

        if (timerCount >= spawnDelay)
        {
            Spawn();
            timerCount = 0;
        }


        //Debug.Log("objectsList count " + objectsList.Count);
    }


    public void IncreaseSpeed()
    {
       

            speed += 0.1f;
        
    }
    public void DecreaseSpeed()
    {
        if (speed < minimumspeed + 0.1f)

        {
            speed -= 0.1f;
        }
    }
    public void IncreaseSpawnDelay()

    {
        if (maximumspawnDelay > spawnDelay)
        {

            spawnDelay += 0.3f;
        }

    }

    public void DecreaseSpawnDelay()

    {
        if (minimumSpawnDelay < spawnDelay + 0.3f)
        {
            spawnDelay -= 0.3f;
        }
    }

    public void IncreasShipSpawnChanceProcent ()

    {
        if (maximumshipSpawnChanceProcent > shipSpawnChanceProcent)
        {
            shipSpawnChanceProcent += 5;
        }
    }


    public void DecreasShipSpawnChanceProcent()

    {
        if (shipSpawnChanceProcent < minimumshipSpawnChanceProcent - 5)
        {
            shipSpawnChanceProcent -= 5;
        }
    }

    private void Spawn()
    {
        Rigidbody clone;
        int spawnPos = GetSpawnPointsRandomPosition();
        spawnType = ProcentChangeOfShipSpawn();

        clone = Instantiate(Prefabs[spawnType], new Vector3(spawnPoints[spawnPos].transform.position.x, spawnPoints[spawnPos].transform.position.y, spawnPoints[spawnPos].transform.position.z), transform.rotation);
        if (spawnType == 0)
        {
            clone.velocity = transform.TransformDirection(Vector3.forward * speed * -1);
            clone.angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));

        }
        else
        {
            clone.velocity = transform.TransformDirection(Vector3.forward * speed * -1);
        }

        // objectsList.Add(clone);
    }



    private int GetSpawnPointsRandomPosition()
    {
        return Random.Range(0, spawnPoints.Length);
    }



    private int ProcentChangeOfShipSpawn()
    {
        int roll= Random.Range(1, 100);

        if (shipSpawnChanceProcent >= roll)
        {
            return 1;
        }
        else
        {
            return 0;
        }

      }
}
