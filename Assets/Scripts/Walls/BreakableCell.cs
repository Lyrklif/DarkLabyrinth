using UnityEngine;

namespace Walls
{
    public class BreakableCell : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;

        public void Initialize(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                BreakCell();
            }
        }

        public void BreakCell()
        {
            Destroy(gameObject);
        }
    }
}