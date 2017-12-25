using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float damage = 100f;

    public float GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
