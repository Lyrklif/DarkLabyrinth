using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public BreakableIce breakableIce;

    public void Attack()
    {
        if (breakableIce != null)
        {
            Debug.Log("Attack triggered!");
            breakableIce.Attack();
        }
    }
}