using UnityEngine;

namespace Walls
{
    public class BreakableIce : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        private int currentHealth;
        
        private BreakableCell breakableCell;
        private ReplaceSprites replaceSprites;

        private void Start()
        {
            currentHealth = maxHealth;
            
            // Получаем или добавляем компоненты
            breakableCell = gameObject.GetComponent<BreakableCell>() ?? gameObject.AddComponent<BreakableCell>();
            replaceSprites = gameObject.GetComponent<ReplaceSprites>() ?? gameObject.AddComponent<ReplaceSprites>();
            
            // Инициализируем компоненты
            breakableCell.Initialize(maxHealth);
            replaceSprites.Initialize(maxHealth, () => currentHealth);
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            replaceSprites.UpdateSprite();
            
            if (currentHealth <= 0)
            {
                breakableCell.BreakCell();
            }
        }
    }
}