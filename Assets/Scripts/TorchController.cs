using UnityEngine;

public class TorchController : MonoBehaviour
{
    public LayerMask torchLayers;
    public Transform torchPoint;
    public GameObject torchPrefab; 
    public float checkRadius = 4f;

    public void AddTorchOnJump()
    {
        Vector3 position = torchPoint.position;
            
        if (!IsTorchInRadius(position))
        {
            Instantiate(torchPrefab, position, Quaternion.identity);
        }
    }

    
    private bool IsTorchInRadius(Vector3 position)
    {
        Collider2D[] targets =  Physics2D.OverlapCircleAll(position, checkRadius, torchLayers);
        
        return targets.Length > 0;
    }
    
    
    void OnDrawGizmosSelected()
    {
        if (torchPoint == null)
            return;
        
        Gizmos.DrawWireSphere(torchPoint.position, checkRadius);
    }
}