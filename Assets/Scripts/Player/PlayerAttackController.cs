using UnityEngine;

namespace Player
{
    public class PlayerAttackController : MonoBehaviour
    {
        [SerializeField] LayerMask iceBlockLayers;
        [SerializeField] Transform attackPoint;

        [SerializeField] float attackRange = 1.4f;
        [SerializeField] int attackDamage = 40;

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

        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}