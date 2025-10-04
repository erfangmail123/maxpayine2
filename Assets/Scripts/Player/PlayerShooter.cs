using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float fireRate = 0.3f;

    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Fire();
            nextFire = Time.time + fireRate;
        }
    }

    public void Fire()
    {
        if (!bulletPrefab || !firePoint) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb) rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
    }
}
