using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependencies
using Utils.Animations;

namespace GamePlay.ChopTree
{
    public class ChopTree : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve _initializeAnimationCurve; // Animation curve for creating tree animation
        [SerializeField]
        private AnimationCurve _chopAnimationCurve; // Animation curve for chopping a trunk animation
        [SerializeField]
        [Range(0, 20)]
        private int _minTreeTrunks; // Minimum amount of trunks in a tree
        [SerializeField]
        [Range(0, 4)]
        private int _variabilityTreeTrunks; // Max random variability amount of trunks
        [SerializeField]
        private GameObject _trunkPrefab; // Reference to the trunk prefab
        [SerializeField]
        private float _trunkOffset = 7.3f; // distance between 2 neighbor trunks
        [SerializeField]
        private GameObject _trunksRoot; // Reference to the GameObject used as root to the trunks
        [SerializeField]
        private GameObject _bottomGrass; // Reference to the GameObject grass at the bottom of the tree

        private List<TreeTrunk> _trunks; // The list with all trunks in the tree
        private bool _initialized = false; // Informe if the tree has been initialized
        private bool _chopping = false; // Informe if a chop action is currently in progress
        private AnimationFinishedCallback _FinishedInitializeCallback; // Callback function to be called when the tree has been initialized

        public void Initialize(AnimationFinishedCallback callback = null)
        {
            _FinishedInitializeCallback = callback;
            int randomVariability = Random.Range(0, _variabilityTreeTrunks + 1);
            int numberOfTrunks = _minTreeTrunks + randomVariability;

            _trunks = new List<TreeTrunk>(numberOfTrunks);
            for (int i = 0; i < numberOfTrunks; i++)
            {
                GameObject trunk = Instantiate(_trunkPrefab, transform.position + Vector3.up * _trunkOffset * i, _trunkPrefab.transform.rotation, _trunksRoot.transform);
                _trunks.Add(trunk.GetComponent<TreeTrunk>());
            }

            // Animate the trunks position
            AnimationHelper.AnimateObjectPosition(_trunksRoot, _trunksRoot.transform.position - Vector3.up * _trunkOffset * _trunks.Count, _trunksRoot.transform.position, 1f, false, _initializeAnimationCurve, finishedInitialize);
            // Animate the bottom grass scale
            AnimationHelper.AnimateObjectScale(_bottomGrass, _bottomGrass.transform.localScale * 0.3f, _bottomGrass.transform.localScale, 0.5f, false, _chopAnimationCurve);
        }

        // Remove one trunk from the tree and run the animation
        public bool ChopATrunk()
        {
            if (!_initialized || _chopping) return false;
            if (_trunks.Count == 0) return true;
            _chopping = true;
            _trunks[0].Chop();
            _trunks.RemoveAt(0);
            AnimationHelper.AnimateObjectPosition(_trunksRoot, _trunksRoot.transform.position, _trunksRoot.transform.position - Vector3.up * _trunkOffset, 0.3f, false, _chopAnimationCurve, finishedChop);
            return _trunks.Count == 0;
        }

        // Funtion called when the chop animation has finished
        private void finishedChop()
        {
            _chopping = false;
        }

        // Funtion called when the initialize tree animation has finished
        private void finishedInitialize()
        {
            _initialized = true;
            if (_FinishedInitializeCallback != null) _FinishedInitializeCallback();
        }
    }
}
