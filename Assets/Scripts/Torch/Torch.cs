using UnityEngine;

public class Torch : MonoBehaviour
{
    public Sprite fullTorchSprite;  
    public Sprite mediumTorchSprite; 
    public Sprite lowTorchSprite;   

    public float lifetime = 30f;
    private Animator animator;

    private SpriteRenderer spriteRenderer;
    private float timeSinceSpawn;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeSinceSpawn = 0f;
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        UpdateSprite();

        if (timeSinceSpawn >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateSprite()
    {
        float remainingTime = lifetime - timeSinceSpawn;

        // from 20 to 30
        if (remainingTime > 20f) 
        {
            spriteRenderer.sprite = fullTorchSprite;
            animator.SetBool("IsFull", true);
            animator.SetBool("IsMedium", false);
            animator.SetBool("IsSmall", false);
        }
        // from 10 to 20
        else if (remainingTime > 10f)
        {
            spriteRenderer.sprite = mediumTorchSprite;
            animator.SetBool("IsFull", false);
            animator.SetBool("IsMedium", true);
            animator.SetBool("IsSmall", false);
        }
        // from 0 to 10
        else 
        {
            spriteRenderer.sprite = lowTorchSprite;
            animator.SetBool("IsFull", false);
            animator.SetBool("IsMedium", false);
            animator.SetBool("IsSmall", true);
        }
    }

    public void ResetLifetime()
    {
        timeSinceSpawn = 0f;
    }
}