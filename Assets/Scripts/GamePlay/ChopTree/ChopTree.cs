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
        private AnimationCurve _initializeAnimationCurve;
        [SerializeField]
        private AnimationCurve _chopAnimationCurve;
        [SerializeField]
        [Range(0, 20)]
        private int _minTreeTrunks;
        [SerializeField]
        [Range(0, 4)]
        private int _variabilityTreeTrunks;
        [SerializeField]
        private GameObject _trunkPrefab;
        [SerializeField]
        private float _trunkOffset = 7.3f;
        [SerializeField]
        private GameObject _trunksRoot;
        [SerializeField]
        private GameObject _bottomGrass;

        private List<TreeTrunk> _trunks;
        private bool _initialized = false;
        private bool _chopping = false;
        private AnimationFinishedCallback _FinishedInitializeCallback;

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

            AnimationHelper.AnimateObjectPosition(_trunksRoot, _trunksRoot.transform.position - Vector3.up * _trunkOffset * _trunks.Count, _trunksRoot.transform.position, 1f, false, _initializeAnimationCurve, finishedInitialize);
            AnimationHelper.AnimateObjectScale(_bottomGrass, _bottomGrass.transform.localScale * 0.3f, _bottomGrass.transform.localScale, 0.5f, false, _chopAnimationCurve);
        }

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

        private void finishedChop()
        {
            _chopping = false;
        }

        private void finishedInitialize()
        {
            _initialized = true;
            if (_FinishedInitializeCallback != null) _FinishedInitializeCallback();
        }
    }
}
