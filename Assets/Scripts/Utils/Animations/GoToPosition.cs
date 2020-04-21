using UnityEngine;

namespace Utils.Animations
{
    public class GoToPosition : ScriptAnimation 
    {
        private Vector3 _targetPosition;
        private Vector3 _startPosition;

        private void Update() 
        {
            if (_running)
            {
                _currentTime += Time.deltaTime;
                if (_currentTime >= _timeToComplete)
                {
                    AnimationFinished();
                } else {
                    float t = EvaluateCurveTime();
                    transform.position = Vector3.Lerp(_startPosition, _targetPosition, t);
                }
            }
        }

        public void RunGoToPositionAnimation(Vector3 startPosition, Vector3 targetPosition, AnimationCurve animationCurve = null, float time = 1, AnimationFinishedCallback callback = null)
        {
            RunAnimation(animationCurve, time, callback);
            _startPosition = startPosition;
            _targetPosition = targetPosition;

            transform.position = startPosition;
            _running = true;
        }
    }
}