using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30f;
    public float bulletTimeScale = 0.25f;
    public float bulletTimeDuration = 0.6f;
    public AudioClip shootSfx;
    public AudioSource audioSource;
    public Animator animator;

    bool canShoot = true;

    public void OnShootButton()
    {
        if (canShoot) Shoot();
    }

    public void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        if (rb) rb.velocity = firePoint.forward * bulletSpeed;

        if (audioSource && shootSfx) audioSource.PlayOneShot(shootSfx);
        if (animator) animator.SetTrigger("Shoot");

        TriggerBulletTime();
    }

    public void TriggerBulletTime()
    {
        StopAllCoroutines();
        StartCoroutine(BulletTimeRoutine());
    }

    IEnumerator BulletTimeRoutine()
    {
        float origFixed = Time.fixedDeltaTime;
        Time.timeScale = bulletTimeScale;
        Time.fixedDeltaTime = origFixed * Time.timeScale;
        yield return new WaitForSecondsRealtime(bulletTimeDuration);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = origFixed;
    }
}