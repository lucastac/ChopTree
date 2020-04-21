using UnityEngine;

namespace Utils.Animations
{
    public class GoToPositionAnimation : ScriptAnimation 
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

        public void RunGoToPositionAnimation(Vector3 startPosition, Vector3 targetPosition, float time = 1, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            RunAnimation(time, animationCurve, callback);
            _startPosition = startPosition;
            _targetPosition = targetPosition;

            transform.position = startPosition;
            _running = true;
        }
    }
}