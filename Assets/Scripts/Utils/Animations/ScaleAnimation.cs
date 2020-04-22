using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Animations
{
    public class ScaleAnimation : ScriptAnimation
    {
        private Vector3 _targetScale; // Scale of the object at the start of the animation
        private Vector3 _startScale; // Scale of the object at the end of the animation

        protected override void ProcessNextFrame()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _duration)
            {
                AnimationFinished();
            }
            else
            {
                float t = EvaluateCurveTime();
                transform.localScale = Vector3.LerpUnclamped(_startScale, _targetScale, t);
            }
        }

        // Start the scale animation
        public void RunScaleAnimation(Vector3 startScale, Vector3 targetScale, float time = 1, bool onLateUpdate = false, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            RunAnimation(time, onLateUpdate, animationCurve, callback);
            _startScale = startScale;
            _targetScale = targetScale;

            transform.localScale = startScale;
            _running = true;
        }
    }
}
