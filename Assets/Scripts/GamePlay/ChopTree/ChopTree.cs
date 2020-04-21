﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependencies
using Utils.Animations;

namespace GamePlay.ChopTree
{
    public class ChopTree : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve _animationCurve;
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
        // Start is called before the first frame update
        public void Initialize()
        {
            int randomVariability = Random.Range(0, _variabilityTreeTrunks + 1);
            int numberOfTrunks = _minTreeTrunks + randomVariability;

            _trunks = new List<TreeTrunk>(numberOfTrunks);
            for (int i = 0; i < numberOfTrunks; i++)
            {
                GameObject trunk = Instantiate(_trunkPrefab, transform.position + Vector3.up * _trunkOffset * i, _trunkPrefab.transform.rotation, transform);
                _trunks.Add(trunk.GetComponent<TreeTrunk>());
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChopATrunk()
        {
            _trunks[0].Chop();
            _trunks.RemoveAt(0);
            AnimationHelper.AnimateObjectGoToPosition(gameObject, transform.position, transform.position - Vector3.up * _trunkOffset, 0.3f, _animationCurve);
        }
    }
}
