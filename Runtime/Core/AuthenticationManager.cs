using Studio23.SS2.AuthSystem.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Studio23.SS2.AuthSystem.Core
{
   
    public class AuthenticationManager : MonoBehaviour
    {

        public static AuthenticationManager instance;

        public UnityEvent OnAuthSuccess;
        [SerializeField] private bool AuthOnStart=true;

        void Awake () { 
            instance = this;
        }

        private void Start()
        {
            if (!AuthOnStart) return;
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
                _providerBase.OnAuthSuccess.AddListener(()=>OnAuthSuccess?.Invoke());
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

