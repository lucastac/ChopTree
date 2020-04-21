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
        private GameObject _treePrefab;
        [SerializeField]
        private CameraController _cameraController;

        private ChopTree _currentTree;
        public void Initialize()
        {
            CreatenewTree();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChopTree()
        {
            if (_currentTree.ChopATrunk())
            {
                CreatenewTree();
            }
        }

        private void CreatenewTree()
        {
            GameObject newTree = Instantiate(_treePrefab, transform);

            if (_currentTree)
            {
                Vector3 currentTreePosition = new Vector3(_currentTree.transform.position.x, 0, _currentTree.transform.position.z);
                newTree.transform.position = currentTreePosition + new Vector3(Random.Range(-10, 10), 0, 30);
                Destroy(_currentTree.gameObject);
            }

            _currentTree = newTree.GetComponent<ChopTree>();
            _currentTree.Initialize(FocusTree);
        }

        private void FocusTree()
        {
            _cameraController.ChangeFocus(_currentTree.transform);
        }
    }
}
