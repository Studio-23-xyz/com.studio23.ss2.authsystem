using Cysharp.Threading.Tasks;
using Studio23.SS2.AuthSystem.Data;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Studio23.SS2.AuthSystem.Core
{
   
    public class AuthenticationManager : MonoBehaviour
    {

        public static AuthenticationManager instance;

        public UnityEvent OnAuthSuccess;
        public UnityEvent OnAuthFailed;
        [SerializeField] private bool AuthOnStart=true;

        [SerializeField] private ProviderBase _providerBase;
        void Awake () { 
            instance = this;
        }

        private async void Start()
        {
            if (!AuthOnStart) return;
            await Auth();
        }



        /// <summary>
        /// This method will check  user authentication for validating Digital Rights Management for the project
        /// </summary>
        public async Task Auth()
        {
            if (_providerBase != null)
            {
                Debug.Log("Authentication attempted.");
                int result=await _providerBase.Authenticate();

                if(result==0)
                {
                    OnAuthSuccess?.Invoke();
                    Debug.Log("Authentication success.");
                }
                else
                {
                    OnAuthFailed?.Invoke();
                    Debug.Log($"Authentication Failed ErrorCode:{result}.");
                }

              
            }
            else
            {
                OnAuthFailed?.Invoke();
                Debug.Log("Authentication provider is not set.");
            }
        }

        public async UniTask<UserData> GetUserData()
        {
            return await _providerBase.GetUserData();
        }


    }
}

