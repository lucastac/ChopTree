using UnityEngine;

namespace Utils.Animations
{
    public class PositionAnimation : ScriptAnimation 
    {
        private Vector3 _targetPosition; // Position of the object at the start of the animation
        private Vector3 _startPosition; // Position of the object at the end of the animation

        protected override void ProcessNextFrame() 
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _duration)
            {
                AnimationFinished();
            } else {
                float t = EvaluateCurveTime();
                transform.position = Vector3.LerpUnclamped(_startPosition, _targetPosition, t);
            }
        }

        // Start the position animation
        public void RunPositionAnimation(Vector3 startPosition, Vector3 targetPosition, float time = 1, bool onLateUpdate = false, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            RunAnimation(time, onLateUpdate, animationCurve, callback);
            _startPosition = startPosition;
            _targetPosition = targetPosition;

            transform.position = startPosition;
            _running = true;
        }
    }
}