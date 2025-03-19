using System;
using UnityEngine;

public class BreakableIce : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth = 100;
    
    public Sprite fullIceSprite;  
    public Sprite crackedIceSprite; 
    public Sprite brokenIceSprite; 
    
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
    
    void UpdateSprite()
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

    void BreakIce()
    {
        // die animation?
        
        // destroy the ice block
        Destroy(gameObject);
    }
}