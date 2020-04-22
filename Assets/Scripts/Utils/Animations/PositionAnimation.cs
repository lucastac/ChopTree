using UnityEngine;

namespace Utils.Animations
{
    public class PositionAnimation : ScriptAnimation 
    {
        private Vector3 _targetPosition;
        private Vector3 _startPosition;

        protected override void ProcessNextFrame() 
        {
            if (_running)
            {
                _currentTime += Time.deltaTime;
                if (_currentTime >= _timeToComplete)
                {
                    AnimationFinished();
                } else {
                    float t = EvaluateCurveTime();
                    transform.position = Vector3.LerpUnclamped(_startPosition, _targetPosition, t);
                }
            }
        }

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