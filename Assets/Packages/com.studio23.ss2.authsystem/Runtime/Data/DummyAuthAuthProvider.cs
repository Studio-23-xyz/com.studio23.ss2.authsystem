using Cysharp.Threading.Tasks;
using UnityEngine;


namespace Studio23.SS2.AuthSystem.Data
{

    public class DummyAuthAuthProvider : AuthProviderBase
    {

        [Header("Debug Config")]
        public float SimulatedWaitTimeForLogin = 1f;
        public bool FailAuth;
        [Tooltip("Usually 0 is everything okay")]
        public int customReturnCode = -0000123;

        public UserData DummyUser;


     
        public override async UniTask<int> Authenticate()
        {
            await UniTask.WaitForSeconds(SimulatedWaitTimeForLogin,true);
            if(FailAuth)
            {
                Debug.LogError($"{name}: Authentication Failed error code:{customReturnCode}");
                return customReturnCode;
            }
            else
            {
                Debug.Log($"{name}: <color=green>Authentication Successful</color>");
                return 0;
            }

        }

        public override UniTask<UserData> GetUserData()
        {
            return new UniTask<UserData>(DummyUser);
        }
    }
}