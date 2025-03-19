using UnityEngine;

public class Torch : MonoBehaviour
{
    public Sprite fullTorchSprite;  

    public float lifetime = 30f;

    private Animator animator;
    private float timeSinceSpawn;

    private enum TorchState
    {
        Full,
        Medium,
        Low
    }

    void Start()
    {
        animator = GetComponent<Animator>();
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

        TorchState currentState = GetTorchState(remainingTime);

        switch (currentState)
        {
            case TorchState.Full:
                animator.SetInteger("TorchState", (int)TorchState.Full);
                break;

            case TorchState.Medium:
                animator.SetInteger("TorchState", (int)TorchState.Medium);
                break;

            case TorchState.Low:
                animator.SetInteger("TorchState", (int)TorchState.Low);
                break;
        }
    }

    private TorchState GetTorchState(float remainingTime)
    {
        if (remainingTime > 20f)
        {
            return TorchState.Full;
        }
        else if (remainingTime > 10f)
        {
            return TorchState.Medium;
        }
        else
        {
            return TorchState.Low;
        }
    }

    public void ResetLifetime()
    {
        timeSinceSpawn = 0f;
    }
}