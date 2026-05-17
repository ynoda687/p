using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    public int damage = 20;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision other)
    {
        Health hp = other.gameObject.GetComponent<Health>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

