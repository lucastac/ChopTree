using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.ChopTree
{
    public class TreeTrunk : MonoBehaviour
    {
        [SerializeField]
        private GameObject _destroyEffectPrefab; // Reference to destroy effect prefab
        
        // Destroy the trunk and instantiate the destroy effect
        public void Chop()
        {
            Destroy(Instantiate(_destroyEffectPrefab, transform.position + Vector3.up * 2, _destroyEffectPrefab.transform.rotation), 3);
            Destroy(gameObject);
        }
    }
}
