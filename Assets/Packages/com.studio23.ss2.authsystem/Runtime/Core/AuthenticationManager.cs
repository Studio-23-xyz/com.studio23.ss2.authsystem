using Studio23.SS2.AuthSystem.Data;
using UnityEngine;

namespace Studio23.SS2.AuthSystem.Core
{
    public delegate void AuthEvent();
    public class AuthenticationManager : MonoBehaviour
    {

        public static AuthenticationManager instance;

        public AuthEvent OnAuthSuccess;

        void Start () { 
            instance = this;
            Auth();
        }

        [SerializeField] private ProviderBase _providerBase;

        /// <summary>
        /// This method will check  user authentication for validating Digital Rights Managemment for the project
        /// </summary>
        public void Auth()
        {
            if (_providerBase != null)
            {
                _providerBase.OnAuthSuccess += ()=> OnAuthSuccess?.Invoke();
                _providerBase.Authenticate();
                Debug.Log("Authentication attempted.");
            }
            else
            {
                Debug.Log("Authentication provider is not set.");
            }
        }

        public UserData GetUserData()
        {
            return _providerBase.GetUserData();
        }


    }
}

