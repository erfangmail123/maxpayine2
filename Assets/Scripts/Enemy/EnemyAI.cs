using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2.5f;
    public float stopDistance = 10f;
    public float fireRate = 1.8f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootingRange = 20f;
    public Animator animator;

    CharacterController controller;
    float nextFireTime = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 dir = player.position - transform.position;
        float dist = dir.magnitude;
        dir.y = 0;

        if (dist > stopDistance)
        {
            Vector3 move = dir.normalized * moveSpeed;
            controller.Move(move * Time.deltaTime);
            if (animator) animator.SetFloat("Speed", 1f);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 5f);
        }
        else
        {
            if (animator) animator.SetFloat("Speed", 0f);
        }

        if (dist <= shootingRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;
        GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        if (rb) rb.velocity = (player.position - firePoint.position).normalized * 20f;
        if (animator) animator.SetTrigger("Shoot");
    }
}