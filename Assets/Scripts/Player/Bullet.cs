using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;
    public float damage = 25f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        var h = collision.collider.GetComponent<Health>();
        if (h != null)
        {
            h.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}