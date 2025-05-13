using System;
using UnityEngine;

namespace Walls
{
    public class BreakableIce : MonoBehaviour
    {
        [SerializeField] int maxHealth = 100;
        private int currentHealth = 100;

        [SerializeField] Sprite fullIceSprite;
        [SerializeField] Sprite crackedIceSprite;
        [SerializeField] Sprite brokenIceSprite;

        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            currentHealth = maxHealth;
            spriteRenderer = GetComponent<SpriteRenderer>();
            UpdateSprite();
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            UpdateSprite();

            // play hurt animation
            if (currentHealth <= 0)
            {
                BreakIce();
            }
        }

        private void UpdateSprite()
        {
            if (currentHealth > maxHealth * 0.66f) // more them 66% health
            {
                spriteRenderer.sprite = fullIceSprite;
            }
            else if (currentHealth > maxHealth * 0.33f) // from 33% to 66% health
            {
                spriteRenderer.sprite = crackedIceSprite;
            }
            else // less then 33% health
            {
                spriteRenderer.sprite = brokenIceSprite;
            }
        }

        private void BreakIce()
        {
            // die animation?

            // destroy the ice block
            Destroy(gameObject);
        }
    }
}