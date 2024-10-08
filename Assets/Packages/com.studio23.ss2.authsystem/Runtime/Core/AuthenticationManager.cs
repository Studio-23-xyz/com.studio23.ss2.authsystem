using Cysharp.Threading.Tasks;
using Studio23.SS2.AuthSystem.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Studio23.SS2.AuthSystem.Core
{
    [RequireComponent(typeof(ProviderFactory))]
    public class AuthenticationManager : MonoBehaviour
    {

        public static AuthenticationManager Instance;

        [SerializeField] private bool AuthOnStart = true;

        private ProviderFactory _providerFactory;
        [SerializeField] private AuthProviderBase _authProviderBase;

        [Header("Events")]
        public UnityEvent<int> OnAuthSuccess;
        public UnityEvent<int> OnAuthFailed;


        private bool _initialized = false;
        private bool _isAuthenticated;
        void Awake()
        {
            Instance = this;
            _providerFactory = GetComponent<ProviderFactory>();
        }




        private async void Start()
        {
            if (!AuthOnStart) return;
            await Authenticate();
        }

        /// <summary>
        /// Auth Method Ensures that this is called first
        /// </summary>
        /// <returns></returns>
        private async UniTask Initialize()
        {
            if(_initialized) return;
            await _providerFactory.Initialize();
            _authProviderBase = _providerFactory.GetProvider();
            if (_authProviderBase == null)
            {
                Debug.LogWarning("Authentication authProvider is not set. Did you forget to create a provider? Studio-23>AuthSystem>Providers");
                return;
            }
            _initialized = true;
        }

       

        /// <summary>
        /// This method will check  user authentication for validating Digital Rights Management for the project
        /// </summary>
        public async UniTask Authenticate()
        {
            await Initialize();

            Debug.Log($"{_authProviderBase.name}: Authentication attempted.");
            int result = await _authProviderBase.Authenticate();

            if (result == 0)
            {
                OnAuthSuccess?.Invoke(result);
                _isAuthenticated = true;
                Debug.Log($"{_authProviderBase.name}: Authentication success.");
            }
            else
            {
                _isAuthenticated = false;
                OnAuthFailed?.Invoke(result);
                Debug.Log($"{_authProviderBase.name}: Authentication Failed ErrorCode:{result}.");
            }

        }

        /// <summary>
        /// Helper Method for Unity UI calls if needed as it can't call UniTasks
        /// </summary>
        public async void AuthenticateFromUI()
        {
            await Authenticate();
        }

        /// <summary>
        /// Gets the user related data
        /// </summary>
        /// <returns></returns>
        public async UniTask<UserData> GetUserData()
        {
            if(!_isAuthenticated)
            {
                Debug.LogError($"{_authProviderBase.name}: Must Authenticate First");
                return null;
            }
            return await _authProviderBase.GetUserData();
        }


    }
}

