using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependencies
using GamePlay.ChopTree;

namespace Managers
{
    public class TreeManager : SingletonMonobehaviour<TreeManager>
    {
        [SerializeField]
        private int _numberOfTrees;        
        [SerializeField]
        private GameObject _treePrefab;

        private List<ChopTree> _trees;
        public void Initialize()
        {
            _instance = this;
            _trees = new List<ChopTree>(_numberOfTrees);

            for (int i = 0; i < _numberOfTrees; i++)
            {
                GameObject tree = Instantiate(_treePrefab, transform);
                _trees.Add(tree.GetComponent<ChopTree>());
            }

            _trees[0].Initialize();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChopTree()
        {
            if (_trees[0].ChopATrunk())
            {
                Destroy(_trees[0].gameObject);
                _trees.RemoveAt(0);
                GameObject newTree = Instantiate(_treePrefab, transform);
                _trees.Add(newTree.GetComponent<ChopTree>());
                _trees[0].Initialize();
            }
        }
    }
}
