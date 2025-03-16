using UnityEngine;

public class BreakableIce : MonoBehaviour
{
    public GameObject breakEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);
        if (other.CompareTag("PlayerAttack"))
        {
            DestroyIce();
        }
    }

    public void Attack()
    {
        DestroyIce();
    }

    void DestroyIce()
    {
        if (breakEffect != null)
        {
            Instantiate(breakEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}