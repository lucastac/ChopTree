using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependencies
using Utils.Animations;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 _offset;
        // Start is called before the first frame update
        void Start()
        {
            _offset = transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeFocus(Transform focusTarget)
        {
            AnimationHelper.AnimateObjectGoToPosition(gameObject, transform.position, focusTarget.position + _offset, 0.3f, true);
        }
    }
}
