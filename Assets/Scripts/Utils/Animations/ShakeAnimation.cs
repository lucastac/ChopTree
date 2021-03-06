﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Animations
{
    public class ShakeAnimation : ScriptAnimation
    {
        private Vector3 _originalPosition; // Original position of the object before starts the shake
        private float _magnitude; // Magnitude of the shake

        protected override void ProcessNextFrame()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _duration)
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

        // Start the shake animation
        public void RunShakeAnimation(float magnitude, float time = 1, bool onLateUpdate = false, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            RunAnimation(time, onLateUpdate, animationCurve, callback);

            _magnitude = magnitude;
            _originalPosition = transform.position;
            _running = true;
        }
    }
}
