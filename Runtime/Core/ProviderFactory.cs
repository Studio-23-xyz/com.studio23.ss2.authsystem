using Cysharp.Threading.Tasks;
using Studio23.SS2.AuthSystem.Data;
using UnityEngine;

namespace Studio23.SS2.AuthSystem.Core
{
    public class ProviderFactory : MonoBehaviour
    {
         private AuthProviderBase DummyAuthProvider;
         private AuthProviderBase AuthProvider;
        public async UniTask Initialize()
        {
            await LoadFromResources();
        }

        private async UniTask LoadFromResources()
        {
            ResourceRequest DummyAuthProviderResourceRequest =  Resources.LoadAsync<AuthProviderBase>("AuthSystem/Providers/DummyAuthProvider");
            ResourceRequest AuthProviderResourceRequest= Resources.LoadAsync<AuthProviderBase>("AuthSystem/Providers/AuthProvider");

            await DummyAuthProviderResourceRequest;
            await AuthProviderResourceRequest;

            DummyAuthProvider=  DummyAuthProviderResourceRequest.asset as AuthProviderBase;
            AuthProvider = AuthProviderResourceRequest.asset as AuthProviderBase;

        }

       

        public AuthProviderBase GetProvider()
        {
            return AuthProvider == null ? DummyAuthProvider : AuthProvider;
        }

    }
}