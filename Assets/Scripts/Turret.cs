using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemy;
    
    public float range = 15f;

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public bool useLaser = false;

    public int slowingDamage = 25;
    public float slowing = .5f;
    
    public LineRenderer lineR;

    public string enemyTag = "Enemy";

    public Transform Rotator;
    public float turnSpeed = 10f;

    public Transform firePoint;

	// Use this for initialization
	void Start ()
    {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // finding all of the enemies on the map
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies) // for all enemies found calculate the distance to them
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // return distance in units then stored in the float
            if (distanceToEnemy < shortestDistance) 
            {
                shortestDistance = distanceToEnemy; // finds the closest enemy to the target
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null; // when taget goeas out of range the target isnt locked onto anymore
        }

    }

	// Update is called once per frame
	void Update ()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineR.enabled)
                    lineR.enabled = false;
            }

            return;// if target is not found, then do nothing
        }
             

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot(); // shoot method
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime; // shoot coundown will be decreased every second by 1
        }

         

	}
    void LockOnTarget() // target lock on
    {
       
        Vector3 dir = target.position - transform.position; // finds the position of enemy and takes away the position of turret to find the distance
        Quaternion lookRotation = Quaternion.LookRotation(dir); // changes rotation to x,y,z axes so the turret only turns on y axes
        Vector3 rotation = Quaternion.Lerp(Rotator.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // smoothly rotates from one enemy to other
        Rotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Laser()
    {
        targetEnemy.DamageTaken(slowingDamage * Time.deltaTime); // targetted enemy takes slowing damage every secound
        targetEnemy.Slow(slowing);
        if (!lineR.enabled)
            lineR.enabled = true;
        
        lineR.SetPosition(0, firePoint.position);
        lineR.SetPosition(1, target.position);

    }

    void Shoot() // gets bullet prefab to appear at the firepoint which is at the end of turrets barrel.
    {
        GameObject BULLET = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = BULLET.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Find(target);

    }



    private void OnDrawGizmosSelected () // draws the range of the turret when its selected
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
