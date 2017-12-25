using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public int scoreValue = 5;
    public float health = 200f;
    public GameObject projectile;
    public float projectileSpeed = 5.0f;
    public float firingRate = 1.0f;
    float elapsedTime = 0.0f;

    ScoreController scoreKeeper;
    public AudioClip fireSound;
    public AudioClip deathSound;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreController>();
        firingRate = Random.Range(1, 5);
    }

    void Update()
    {
        if(elapsedTime >= firingRate)
        {
            Fire();
            elapsedTime = elapsedTime - firingRate;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -.75f, 0);
        GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
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
                Death();
            }
            Debug.Log("Hit by a missile");
        }
    }

    void Death()
    {
        scoreKeeper.AddScore(scoreValue);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
    }
}
