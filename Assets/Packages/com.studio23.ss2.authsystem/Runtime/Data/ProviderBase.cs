using UnityEngine;
using UnityEngine.Events;

namespace Studio23.SS2.AuthSystem.Data
{
    public abstract class ProviderBase : MonoBehaviour
    {
        public UnityEvent OnAuthSuccess;
        public UnityEvent OnAuthFailed;
        public abstract void Authenticate();
        public abstract UserData GetUserData();
    }

}