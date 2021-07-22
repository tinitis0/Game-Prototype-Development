using UnityEngine;

public class Bullet : MonoBehaviour {


    private Transform target;


    public float bulletSpeed = 50f;
    public int damage = 50;

    public float ExplosionRadius = 0f;

    public GameObject bulletImpactEffect;

    public void Find (Transform _target)
    {
        target = _target;
    }

	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
          TargetHit();
          return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

    void TargetHit ()

    {
        GameObject effectInstance = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);

        if (ExplosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

     void Explode ()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy STD = enemy.GetComponent<Enemy>();


        if (STD != null)
        {
            STD.DamageTaken(damage);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
