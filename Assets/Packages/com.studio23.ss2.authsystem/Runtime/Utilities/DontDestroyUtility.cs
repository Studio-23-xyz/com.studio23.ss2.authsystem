using UnityEngine;

namespace Studio23.SS2.AuthSystem.Utilities
{

    public class DontDestroyUtility : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}
