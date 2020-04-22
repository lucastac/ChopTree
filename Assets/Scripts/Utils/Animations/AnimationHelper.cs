using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Animations
{
    public class AnimationHelper
    {
        public static void AnimateObjectPosition(GameObject targetObject, Vector3 startPosition, Vector3 targetPosition, float time = 1, bool onLateUpdate = false, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            PositionAnimation anim = targetObject.AddComponent<PositionAnimation>();
            anim.RunPositionAnimation(startPosition, targetPosition, time, onLateUpdate, animationCurve, callback);
        }

        public static void AnimateObjectScale(GameObject targetObject, Vector3 startScale, Vector3 targetScale, float time = 1, bool onLateUpdate = false, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            ScaleAnimation anim = targetObject.AddComponent<ScaleAnimation>();
            anim.RunScaleAnimation(startScale, targetScale, time, onLateUpdate, animationCurve, callback);
        }

        public static void AnimateObjectShake(GameObject targetObject, float magnitude, float time = 1, bool onLateUpdate = false, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            ShakeAnimation anim = targetObject.AddComponent<ShakeAnimation>();
            anim.RunShakeAnimation(magnitude, time, onLateUpdate, animationCurve, callback);
        }
    }
}
