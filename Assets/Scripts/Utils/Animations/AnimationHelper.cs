using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Animations
{
    public class AnimationHelper
    {
        public static void AnimateObjectGoToPosition(GameObject targetObject, Vector3 startPosition, Vector3 targetPosition, float time = 1, AnimationCurve animationCurve = null, AnimationFinishedCallback callback = null)
        {
            GoToPositionAnimation anim = targetObject.AddComponent<GoToPositionAnimation>();
            anim.RunGoToPositionAnimation(startPosition, targetPosition, time, animationCurve, callback);
        }
    }
}
