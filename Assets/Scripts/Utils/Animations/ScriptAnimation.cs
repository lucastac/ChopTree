using UnityEngine;

namespace Utils.Animations
{
    public abstract class ScriptAnimation : MonoBehaviour 
    {
        public delegate void AnimationFinishedCallback();

        protected AnimationCurve _animationCurve;       
        protected AnimationFinishedCallback _AnimationFinishedCallback;
        protected float _timeToComplete;
        protected float _currentTime;
        protected bool _running = false;

        protected virtual float EvaluateCurve(float t)
        {
            if (_animationCurve == null) return t;
            return _animationCurve.Evaluate(t);
        }

        protected virtual float EvaluateCurveTime()
        {
            return EvaluateCurve(_currentTime / _timeToComplete);
        }
        protected virtual void RunAnimation(AnimationCurve animationCurve, float timeToComplete, AnimationFinishedCallback callback = null)
        {
            _animationCurve = animationCurve;
            _timeToComplete = timeToComplete;
            _AnimationFinishedCallback = callback;
        }

        protected virtual void AnimationFinished()
        {
            _AnimationFinishedCallback();
            _running = false;
            Destroy(this);
        }
    }
}