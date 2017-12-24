using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public float health = 200f;
    public GameObject projectile;
    public float projectileSpeed = 5.0f;

    void Update()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -.75f, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        ProjectileController missile = collider.gameObject.GetComponent<ProjectileController>();
        if(missile)
        {
            missile.Hit();
            health -= missile.GetDamage();
            if(health <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("Hit by a missile");
        }
    }
}
