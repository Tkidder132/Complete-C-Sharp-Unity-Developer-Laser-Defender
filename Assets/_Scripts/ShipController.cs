using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5.0f;
    float xMin, xMax;
    public float padding = 1f;
	// Use this for initialization
	void Start ()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;
    }
	
	// Update is called once per frame
	void Update ()
    {
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
}
