using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependencies
using Utils.Animations;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 _offset;
        private bool _shaking = false;
        // Start is called before the first frame update
        void Start()
        {
            _offset = transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeFocus(Transform focusTarget, AnimationFinishedCallback callback = null)
        {
            AnimationHelper.AnimateObjectPosition(gameObject, transform.position, focusTarget.position + _offset, 0.3f, true, null, callback);
        }

        public void Shake(float magnitude, float time)
        {
            if (_shaking) return;
            _shaking = true;
            AnimationHelper.AnimateObjectShake(gameObject, magnitude, time, true, null, finishedShakeAnimation);
        }

        private void finishedShakeAnimation()
        {
            _shaking = false;
        }
    }
}
