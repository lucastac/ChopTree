using UnityEngine;

namespace Utils.Animations
{
    public delegate void AnimationFinishedCallback();
    public abstract class ScriptAnimation : MonoBehaviour 
    {
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
        protected virtual void RunAnimation(float timeToComplete, AnimationCurve animationCurve, AnimationFinishedCallback callback = null)
        {
            _animationCurve = animationCurve;
            _timeToComplete = timeToComplete;
            _AnimationFinishedCallback = callback;
        }

        protected virtual void AnimationFinished()
        {
            if (_AnimationFinishedCallback != null) _AnimationFinishedCallback();
            _running = false;
            Destroy(this);
        }
    }
}