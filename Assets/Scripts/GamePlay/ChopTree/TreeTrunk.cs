using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.ChopTree
{
    public class TreeTrunk : MonoBehaviour
    {
        public void Chop()
        {
            Destroy(gameObject);
        }
    }
}
