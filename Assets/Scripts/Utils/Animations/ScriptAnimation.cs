using UnityEngine;

namespace Utils.Animations
{
    public delegate void AnimationFinishedCallback();
    public abstract class ScriptAnimation : MonoBehaviour 
    {
        protected AnimationCurve _animationCurve; // Animation curve used to evaluate time       
        protected AnimationFinishedCallback _AnimationFinishedCallback; // Callback function executed when the animation is finished
        protected float _duration; // Time to complete the animation
        protected float _currentTime; // Count how much time has passed since the begin of the animation
        protected bool _running = false; // Informe if the animation is currently running
        protected bool _onLateUpdate = false; // Informe if the animation should be updated on LateUpdate (usefull when animating camera)

        protected virtual void Update()
        {
            if (!_onLateUpdate && _running) ProcessNextFrame();
        }

        protected virtual void LateUpdate()
        {
            if (_onLateUpdate && _running) ProcessNextFrame();
        }

        // This functions should be override by child classes
        protected virtual void ProcessNextFrame()
        {

        }

        // Evalute the animation curve for a given time
        protected virtual float EvaluateCurve(float t)
        {
            if (_animationCurve == null) return t;
            return _animationCurve.Evaluate(t);
        }

        // Use the currentTime and duration to calculate the animation curve time
        protected virtual float EvaluateCurveTime()
        {
            return EvaluateCurve(_currentTime / _duration);
        }

        // Base function to be used by child classes
        protected virtual void RunAnimation(float timeToComplete = 1, bool onLateUpdate = false, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            _animationCurve = animationCurve;
            _duration = timeToComplete;
            _onLateUpdate = onLateUpdate;
            _AnimationFinishedCallback = callback;
        }
        
        // Child classes should call this function to inform when the animation has finished
        protected virtual void AnimationFinished()
        {
            if (_AnimationFinishedCallback != null) _AnimationFinishedCallback();
            _running = false;
            Destroy(this);
        }
    }
}