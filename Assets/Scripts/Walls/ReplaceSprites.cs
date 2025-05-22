using UnityEngine;
using System;

namespace Walls
{
    public class ReplaceSprites : MonoBehaviour
    {
        [SerializeField] private Sprite fullIceSprite;
        [SerializeField] private Sprite crackedIceSprite;
        [SerializeField] private Sprite brokenIceSprite;

        private SpriteRenderer spriteRenderer;
        private int maxHealth;
        private Func<int> getCurrentHealth;

        public void Initialize(int maxHealth, Func<int> getCurrentHealthCallback)
        {
            this.maxHealth = maxHealth;
            this.getCurrentHealth = getCurrentHealthCallback;
            
            spriteRenderer = GetComponent<SpriteRenderer>();
            UpdateSprite();
        }

        public void UpdateSprite()
        {
            int currentHealth = getCurrentHealth();
            
            if (currentHealth > maxHealth * 0.66f)
            {
                spriteRenderer.sprite = fullIceSprite;
            }
            else if (currentHealth > maxHealth * 0.33f)
            {
                spriteRenderer.sprite = crackedIceSprite;
            }
            else
            {
                spriteRenderer.sprite = brokenIceSprite;
            }
        }
    }
}