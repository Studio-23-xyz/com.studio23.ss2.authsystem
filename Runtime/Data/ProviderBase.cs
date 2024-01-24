using Cysharp.Threading.Tasks;
using Studio23.SS2.AuthSystem.Core;
using UnityEngine;

namespace Studio23.SS2.AuthSystem.Data
{

    public abstract class ProviderBase : ScriptableObject
    {
        [SerializeField]
        protected ProviderTypes _providerType;

        public ProviderTypes ProviderType { get { return _providerType; } }
        public abstract UniTask<int> Authenticate();
        public abstract UniTask<UserData> GetUserData();
    }

}