using UnityEngine;

namespace GGMPool
{
    public class PoolManagerMono : MonoBehaviour
    {
        [field:SerializeField]
        public PoolManagerSO _poolManagerSO { get; private set; }

        private void Awake()
        {
            _poolManagerSO.InitializePool(transform);
        }
    }
}
