using Cysharp.Threading.Tasks;
using Studio23.SS2.AuthSystem.Data;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Studio23.SS2.AuthSystem.Core
{
    [RequireComponent(typeof(ProviderFactory))]
    public class AuthenticationManager : MonoBehaviour
    {

        public static AuthenticationManager instance;

        [SerializeField] private bool AuthOnStart = true;

        private ProviderFactory _providerFactory;
        [SerializeField] private ProviderTypes _providerType;
        [SerializeField] private ProviderBase _providerBase;

        [Header("Events")]
        public UnityEvent<int> OnAuthSuccess;
        public UnityEvent<int> OnAuthFailed;


        private bool _isAuthenticated;
        void Awake()
        {
            instance = this;
            _providerFactory = GetComponent<ProviderFactory>();
        }


        public void SetProviderType()
        {
            _providerType = ProviderTypes.Default;
#if UNITY_GAMECORE
            _providerType = ProviderTypes.XboxGameCore;
#endif

#if MICROSOFT_GAME_CORE
            _providerType = ProviderTypes.XboxPc;
#endif

#if STEAMWORKS_ENABLED
            _providerType = ProviderTypes.Steam;
#endif

        }

        private async void Start()
        {
            SetProviderType();
            _providerFactory.Initialize();
            _providerBase = _providerFactory.GetProvider(_providerType);
            if (_providerBase == null)
            {
                Debug.LogWarning("Authentication provider is not set.");
                return;
            }



            if (!AuthOnStart) return;
            await Authenticate();
        }

        public async void AuthenticateFromUI()
        {
            await Authenticate();
        }

        /// <summary>
        /// This method will check  user authentication for validating Digital Rights Management for the project
        /// </summary>
        public async Task Authenticate()
        {
            if (_providerBase == null)
            {
                Debug.LogError("Provider was null. Did you forget to create a provider?");
         
            }

            Debug.Log("Authentication attempted.");
            int result = await _providerBase.Authenticate();

            if (result == 0)
            {
                OnAuthSuccess?.Invoke(result);
                _isAuthenticated = true;
                Debug.Log("Authentication success.");
            }
            else
            {
                _isAuthenticated = false;
                OnAuthFailed?.Invoke(result);
                Debug.Log($"Authentication Failed ErrorCode:{result}.");
            }

        }
        /// <summary>
        /// Gets the user related data
        /// </summary>
        /// <returns></returns>
        public async UniTask<UserData> GetUserData()
        {
            if(!_isAuthenticated)
            {
                Debug.LogError($"Must Authenticate First");
                return null;
            }
            return await _providerBase.GetUserData();
        }


    }
}

