using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(TurretController))]
public class EnemyShoot : MonoBehaviour
{

    public Transform SpawnPoint;
    private GameObject target;
    public GameObject bullet;
    public float shootInterval = 2;
    private float timer;
    public Rigidbody rb;


    private void Awake()
    {
       // rb = this.gameObject.transform.GetComponent<Rigidbody>();
        SpawnPoint = gameObject.transform.GetComponent<TurretController>().ChildRotate;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerShip");
        gameObject.transform.GetComponent<TurretController>().target1 = target;

     }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > shootInterval)
        {
            Fire();
            timer = 0;
        }
    }


    public void Fire()
    {
        var direction = Vector3.zero;
        Rigidbody bulletRb = Instantiate(bullet, SpawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        // bulletRb.velocity = SpawnPoint.forward  * 1 ;
      //  bulletRb.velocity = rb.velocity*1.5f;
        bulletRb.velocity += SpawnPoint.forward * 10;

    }
}
