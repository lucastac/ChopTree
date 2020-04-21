using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private bool _chopTreeAction = false;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _chopTreeAction = true; ;
            }
        }

        public void TouchOnScreen()
        {
            _chopTreeAction = true;
        }

        public bool chopTreeAction()
        {
            bool pressedChopTreeAction = _chopTreeAction;
            _chopTreeAction = false;
            return pressedChopTreeAction;
        }
    }
}
