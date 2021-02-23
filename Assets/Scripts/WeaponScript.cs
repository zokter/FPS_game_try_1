using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera FPScam;

    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(FPScam.transform.position + FPScam.transform.forward/2, FPScam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            damageTransfer(hit);
        }
    }

    void damageTransfer(RaycastHit hit)
    {
        EnemyHit enemy = hit.transform.GetComponent<EnemyHit>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
