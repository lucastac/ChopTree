using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class SingletonMonobehaviour<T> : MonoBehaviour where T : SingletonMonobehaviour<T>
    {
        protected static T _instance;
        public static T GetInstance()
        {
            return _instance;
        }
    }
}
