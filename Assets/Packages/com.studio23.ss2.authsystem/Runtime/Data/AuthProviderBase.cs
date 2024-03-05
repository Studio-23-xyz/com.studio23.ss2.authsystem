using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Studio23.SS2.AuthSystem.Data
{

    public abstract class AuthProviderBase : ScriptableObject
    {
        
        public abstract UniTask<int> Authenticate();
        public abstract UniTask<UserData> GetUserData();
    }

}