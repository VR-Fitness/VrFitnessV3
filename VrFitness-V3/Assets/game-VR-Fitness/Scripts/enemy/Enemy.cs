using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour   
{

    //public int health = 10;// enemy health
    public float shootintyerval = 2;//secunds between shooting
    public string PlayerTag = "PlayerShip"; // Tag og player ship for targeting


    //offset positions for  projectileSpawn gameobjects
     public float offsetSliderZ = 0;
     public float offsetSliderY = 0;
     public float offsetSliderX = 0;


    private GameObject target; //target for turrets to point at
  //  public GameObject DeathExplosionEffect; // gameobject to spawn when enemy dies
    public GameObject projectile; // projectile to use for shooting
    public TurretController[] turretController; // array of turretcontroller scripts

    private float timerDelay = 0;// internal counting time delay;

   
    private List<GameObject> projectileSpawnList = new List<GameObject>(); // list of projectileSpawn game objects

    //on game start
    private void Awake()
    {

        target = GameObject.FindGameObjectWithTag(PlayerTag); // get  player ship tag

        for (int i = 0; i < turretController.Length; i++)// add player tag target to turrets and create projectile spawnpoints
        {
            turretController[i].target1 = target;// add target to turretcontroller script
            Vector3 spawn = new Vector3(turretController[i].transform.position.x + offsetSliderX, turretController[i].transform.position.y + offsetSliderY, turretController[i].transform.position.z + offsetSliderZ); // create spawn position with offset
            GameObject projectileSpawn = new GameObject("projectileSpawn-" + i);// creating new gameobject
            projectileSpawn.transform.position = spawn; // set new gameobject position
            projectileSpawn.transform.parent = turretController[i].ChildRotate; // make new game object child of ChildRotate gameobject defined in turretcontroller
            projectileSpawnList.Add(projectileSpawn);
        }


        
    }

    private void Update()
    {       
        timerDelay += Time.deltaTime;

        if (timerDelay >= shootintyerval)
        {
            timerDelay = 0;

            for (int i = 0; i < projectileSpawnList.Count; i++)
            {
                if (FireRayCast(projectileSpawnList[i].transform, PlayerTag) == true) // check if ray hit anything
                {
                    Debug.Log("shoooot - ");
                    Shoot(projectileSpawnList[i].transform);
                }
            }                 
        }        
    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("col " + collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("projectile"))
        {

            Debug.Log("i was hit " + collision.gameObject.tag);
            TakeDamage(10);
        }
    }



    // debug gizmos for spawn positions
    private void OnDrawGizmos()
    {      
        for (int i = 0; i < projectileSpawnList.Count; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(projectileSpawnList[i].transform.position, 0.1f);
        }
    }
    */



    // draw ray to detect if line of site is player
    public bool FireRayCast(Transform tranformFrom, string PlayerTag)
    {
        RaycastHit hit;
        Vector3 p1 = tranformFrom.position;
        bool canShoot = false;
        
       
        if (Physics.SphereCast(p1,0.2f, tranformFrom.forward, out hit, 100)) // Cast a sphere wrapping character controller 100 meters forward
        {         
            if (hit.collider.tag.Equals(PlayerTag)) canShoot = true; // if hit has tag of player set true
            else canShoot = false;          
        }
        return canShoot;
    }





    public void Shoot(Transform SpawnPoint)
    {
        Vector3 direction = Vector3.zero;
        Rigidbody bulletRb = Instantiate(projectile, SpawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();       
        bulletRb.velocity += SpawnPoint.forward * 10;
    }


    /*
    //damage method
    public void TakeDamage(int damage)// take damage method
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerStats.AddMultiplierValue();
            DestroySelf();
        }
    }
 




    //destroy self method
    private void DestroySelf() // destroy self and spawn explsion gameopbject
    {
        GameObject clone = Instantiate(DeathExplosionEffect, transform.position, transform.rotation);
    }

       */


}
