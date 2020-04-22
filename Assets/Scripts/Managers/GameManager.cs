using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TreeManager _treeManager; // Reference to the tree manager
        [SerializeField]
        private InputManager _inputManager; // Reference to the input manager

        void Start()
        {
            _treeManager.Initialize();
        }

        void Update()
        {
            // Informe to the tree manager when the player has performed the action to chop a tree
            if (_inputManager.chopTreeAction())
            {
                _treeManager.ChopTree();
            }
        }
    }
}
