using UnityEngine;

namespace Torch
{
    public class TorchController : MonoBehaviour
    {
        [SerializeField]  LayerMask torchLayers;
        [SerializeField]  Transform torchPoint;
        [SerializeField]  GameObject torchPrefab;
        [SerializeField]  float checkRadius = 4f;

        public void AddTorchOnJump()
        {
            Vector3 position = torchPoint.position;

            if (!IsTorchInRadius(position))
            {
                Instantiate(torchPrefab, position, Quaternion.identity);
            }
            else
            {
                RefreshTorchLifetime(position);
            }
        }

        private bool IsTorchInRadius(Vector3 position)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(position, checkRadius, torchLayers);
            return targets.Length > 0;
        }

        private void RefreshTorchLifetime(Vector3 position)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(position, checkRadius, torchLayers);

            foreach (Collider2D target in targets)
            {
                Torch torch = target.GetComponent<Torch>();
                if (torch != null)
                {
                    torch.ResetLifetime();
                    break;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (torchPoint == null)
                return;

            Gizmos.DrawWireSphere(torchPoint.position, checkRadius);
        }
    }
}