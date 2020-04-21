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

        private List<TreeTrunk> _trunks;
        private bool _initialized = false;
        private AnimationFinishedCallback _FinishedInitializeCallback;
        // Start is called before the first frame update
        public void Initialize(AnimationFinishedCallback callback = null)
        {
            _FinishedInitializeCallback = callback;
            int randomVariability = Random.Range(0, _variabilityTreeTrunks + 1);
            int numberOfTrunks = _minTreeTrunks + randomVariability;

            _trunks = new List<TreeTrunk>(numberOfTrunks);
            for (int i = 0; i < numberOfTrunks; i++)
            {
                GameObject trunk = Instantiate(_trunkPrefab, transform.position + Vector3.up * _trunkOffset * i, _trunkPrefab.transform.rotation, transform);
                _trunks.Add(trunk.GetComponent<TreeTrunk>());
            }

            AnimationHelper.AnimateObjectGoToPosition(gameObject, transform.position - Vector3.up * _trunkOffset * _trunks.Count, transform.position, 1f, false, _initializeAnimationCurve, finishedInitialize);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool ChopATrunk()
        {
            if (!_initialized) return false;
            if (_trunks.Count == 0) return true;
            _trunks[0].Chop();
            _trunks.RemoveAt(0);
            AnimationHelper.AnimateObjectGoToPosition(gameObject, transform.position, transform.position - Vector3.up * _trunkOffset, 0.3f, false, _chopAnimationCurve);
            return _trunks.Count == 0;
        }

        private void finishedInitialize()
        {
            _initialized = true;
            if (_FinishedInitializeCallback != null) _FinishedInitializeCallback();
        }
    }
}
