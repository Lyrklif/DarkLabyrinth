using UnityEngine;

namespace Player
{
    public class PlayerAttackController : MonoBehaviour
    {
        public LayerMask iceBlockLayers;
        public Transform attackPoint;

        public float attackRange = 1.4f;
        public int attackDamage = 40;

        public void Attack()
        {

            // detect targets in range of attack
            Collider2D[] hitTargets = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, iceBlockLayers);

            // damage them
            foreach (Collider2D target in hitTargets)
            {
                target.GetComponent<Walls.BreakableIce>().TakeDamage(attackDamage);
            }
        }

        void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}