using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private bool _chopTreeAction = false; // Informe if the player has recently performed the action to chop a tree

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) // For test purposes, the spacebar also triggers the chop tree action
            {
                _chopTreeAction = true; ;
            }
        }

        // Called when the player touchs the screen
        public void TouchOnScreen()
        {
            _chopTreeAction = true;
        }

        // Informe if the player has performed the action to chop a tree
        public bool chopTreeAction()
        {
            bool pressedChopTreeAction = _chopTreeAction;
            _chopTreeAction = false;
            return pressedChopTreeAction;
        }
    }
}
