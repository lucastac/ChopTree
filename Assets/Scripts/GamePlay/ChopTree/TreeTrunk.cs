using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.ChopTree
{
    public class TreeTrunk : MonoBehaviour
    {
        [SerializeField]
        private GameObject _destroyEffect;
        public void Chop()
        {
            Destroy(Instantiate(_destroyEffect, transform.position + Vector3.up * 2, _destroyEffect.transform.rotation), 3);
            Destroy(gameObject);
        }
    }
}
