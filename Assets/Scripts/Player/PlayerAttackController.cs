using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public BreakableIce breakableIce;
    public LayerMask iceBlockLayers;
    public Transform attackPoint;
    
    public float attackRange = 1f;
    public int attackDamage = 40;

    public void Attack()
    {

        // detect targets in range of attack
        Collider2D[] hitTargets =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, iceBlockLayers);

        // damage them
        foreach (Collider2D target in hitTargets)
        {
            Debug.Log("We hit: " + target.name);
            target.GetComponent<BreakableIce>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}