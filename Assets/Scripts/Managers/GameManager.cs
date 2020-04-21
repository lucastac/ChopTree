using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : SingletonMonobehaviour<GameManager>
    {
        [SerializeField]
        private TreeManager _treeManager;
        // Start is called before the first frame update
        void Start()
        {
            _instance = this;

            _treeManager.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _treeManager.ChopTree();
            }
        }
    }
}
