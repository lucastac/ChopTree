using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependencies
using Utils.Animations;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 _offset; // Offset position in relation to the focused tree
        private bool _shaking = false; // Informe if the camera is currently shaking 

        void Start()
        {
            _offset = transform.position;
        }

        // Change the camera focus to a new position
        public void ChangeFocus(Transform focusTarget, AnimationFinishedCallback callback = null)
        {
            AnimationHelper.AnimateObjectPosition(gameObject, transform.position, focusTarget.position + _offset, 0.3f, true, null, callback);
        }

        // Shake the camera using the ShakeAnimation class
        public void Shake(float magnitude, float time)
        {
            if (_shaking) return;
            _shaking = true;
            AnimationHelper.AnimateObjectShake(gameObject, magnitude, time, true, null, finishedShakeAnimation);
        }

        // Function called when the shake animation has finished
        private void finishedShakeAnimation()
        {
            _shaking = false;
        }
    }
}
