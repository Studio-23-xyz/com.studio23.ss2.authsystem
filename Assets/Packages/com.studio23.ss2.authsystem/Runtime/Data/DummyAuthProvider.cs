using Cysharp.Threading.Tasks;
using UnityEngine;


namespace Studio23.SS2.AuthSystem.Data
{
    [CreateAssetMenu(fileName = "Default Auth Provider", menuName = "Studio-23/AuthSystem/Providers/Default Provider", order = 1)]
    public class DummyAuthProvider : ProviderBase
    {

        [Header("Debug Config")]
        public float SimulatedWaitTimeForLogin = 1f;
        public bool FailAuth;
        [Tooltip("Usually 0 is everything okay")]
        public int customReturnCode = -0000123;

        public UserData DummyUser;


        private void OnEnable()
        {
            _providerType = ProviderTypes.Default;
        }

        public override async UniTask<int> Authenticate()
        {
            await UniTask.WaitForSeconds(SimulatedWaitTimeForLogin,true);
            if(FailAuth)
            {
                Debug.LogError($"Authentication Failed error code:{customReturnCode}");
                return customReturnCode;
            }
            else
            {
                Debug.Log("<color=green>Authentication Successful</color>");
                return 0;
            }

        }

        public override UniTask<UserData> GetUserData()
        {
            return new UniTask<UserData>(DummyUser);
        }
    }
}