using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Animations
{
    public class ShakeAnimation : ScriptAnimation
    {
        private Vector3 _originalPosition;
        private float _magnitude;

        protected override void ProcessNextFrame()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _timeToComplete)
            {
                transform.position = _originalPosition;
                AnimationFinished();
            }
            else
            {
                float t = EvaluateCurveTime();
                Vector3 randomOffset = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
                transform.position = _originalPosition + Vector3.LerpUnclamped(randomOffset, Vector3.zero, t) * _magnitude;
            }
        }

        public void RunShakeAnimation(float magnitude, float time = 1, bool onLateUpdate = false, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            RunAnimation(time, onLateUpdate, animationCurve, callback);

            _magnitude = magnitude;
            _originalPosition = transform.position;
            _running = true;
        }
    }
}
