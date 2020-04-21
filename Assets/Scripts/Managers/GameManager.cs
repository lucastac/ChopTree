using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TreeManager _treeManager;
        [SerializeField]
        private InputManager _inputManager;
        // Start is called before the first frame update
        void Start()
        {
            _treeManager.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            if (_inputManager.chopTreeAction())
            {
                _treeManager.ChopTree();
            }
        }
    }
}
