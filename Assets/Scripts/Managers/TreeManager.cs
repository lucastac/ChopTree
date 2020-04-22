using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependencies
using GamePlay.ChopTree;
using Controllers;

namespace Managers
{
    public class TreeManager : MonoBehaviour
    {    
        [SerializeField]
        private GameObject _treePrefab; // Prefab of a choptree
        [SerializeField]
        private CameraController _cameraController; // Reference to the camera controller

        private ChopTree _currentTree; // Current target tree
        private bool _focusTree = true; // Informe if currently there is a tree focused by the camera
        
        public void Initialize()
        {
            CreatenewTree();
        }

        // Perform a chop on the currently tree
        public void ChopTree()
        {
            if (_focusTree)
            {
                if (_currentTree.ChopATrunk())
                {
                    CreatenewTree(); // If the current tree is over, then create a new one
                }
                else
                {
                    _cameraController.Shake(0.4f, 0.2f); // If a trunk was chopped, then shake the camera
                }
            }
        }

        // Create a new tree and destroy the previous one
        private void CreatenewTree()
        {
            GameObject newTree = Instantiate(_treePrefab, transform);

            if (_currentTree)
            {
                Vector3 currentTreePosition = new Vector3(_currentTree.transform.position.x, 0, _currentTree.transform.position.z);
                newTree.transform.position = currentTreePosition + new Vector3(Random.Range(-10, 10), 0, 30);
                Destroy(_currentTree.gameObject);
            }

            _focusTree = false;
            _currentTree = newTree.GetComponent<ChopTree>();
            _currentTree.Initialize(FocusTree);
        }

        // Informe camera to focus on the new tree
        private void FocusTree()
        {
            _cameraController.ChangeFocus(_currentTree.transform, finishedFocusTreeAnimation);
        }

        // Called when the camera has successfully focused the new tree
        private void finishedFocusTreeAnimation()
        {
            _focusTree = true;
        }
    }
}
