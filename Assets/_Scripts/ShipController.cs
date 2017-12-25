using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5.0f;
    float xMin, xMax;
    public float padding = 1f;

    public GameObject projectile;
    public float projectileSpeed = 5.0f;
    public float firingRate = 0.2f;
    public float health = 500.0f;

    public AudioClip fireSound;
    private LevelManagerController levelManager;

	// Use this for initialization
	void Start ()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManagerController>();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.0001f, firingRate);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

		if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, .75f, 0);
        GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        ProjectileController missile = collider.gameObject.GetComponent<ProjectileController>();
        if (missile)
        {
            missile.Hit();
            health -= missile.GetDamage();
            if (health <= 0)
            {
                Death();
            }
            Debug.Log("Hit by a missile");
        }
    }

    void Death()
    {
        Destroy(gameObject);
        levelManager.LoadLevel("Win");
    }
}
