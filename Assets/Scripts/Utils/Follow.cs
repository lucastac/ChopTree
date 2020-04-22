using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Follow : MonoBehaviour
    {
        [SerializeField]
        private Transform _target; // Target object to follow

        private Vector3 _offset; // Offset position from target position

        void Start()
        {
            _offset = transform.position - _target.position;
        }

        private void Update()
        {
            if (_target != null) transform.position = _target.position + _offset;
        }

        public void ChangeTarget(Transform newTarget)
        {
            _target = newTarget;
        }
    }
}
