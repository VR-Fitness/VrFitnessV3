using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float shootintyerval = 2;//secunds between shooting
    public string PlayerTag = "PlayerShip"; // Tag og player ship for targeting
    public GameObject projectile; // projectile to use for shooting

    private GameObject target; //target for turrets to point at
    private float timerDelay = 0;// internal counting time delay;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag(PlayerTag); // get  player ship tag
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerDelay += Time.deltaTime;

        if (timerDelay >= shootintyerval)
        {
            timerDelay = 0;
            
                if (FireRayCast(this.transform, PlayerTag) == true) // check if ray hit anything
                {
                    //Debug.Log("shoooot - ");
                    Shoot(this.transform);
                }           
        }
    }



    public void Shoot(Transform SpawnPoint)
    {
        Vector3 direction = Vector3.zero;
        Rigidbody bulletRb = Instantiate(projectile, SpawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.velocity += SpawnPoint.forward * 10;
    }


    // draw ray to detect if line of site is player
    public bool FireRayCast(Transform tranformFrom, string PlayerTag)
    {
        RaycastHit hit;
        Vector3 p1 = tranformFrom.position;
        bool canShoot = false;

        if (Physics.SphereCast(p1, 0.2f, tranformFrom.forward, out hit, 100)) // Cast a sphere wrapping character controller 100 meters forward
        {
            if (hit.collider.tag.Equals(PlayerTag)) canShoot = true; // if hit has tag of player set true
            else canShoot = false;
        }
        return canShoot;
    }
}
