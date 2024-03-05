using Studio23.SS2.AuthSystem.Data;
using UnityEngine;

namespace Studio23.SS2.AuthSystem.Core
{
    public class ProviderFactory : MonoBehaviour
    {
         private AuthProviderBase DummyAuthProvider;
         private AuthProviderBase AuthProvider;
        public void Initialize()
        {
            LoadFromResources();
        }

        private void LoadFromResources()
        {
            DummyAuthProvider =  Resources.Load<AuthProviderBase>("AuthSystem/Providers/DummyAuthProvider");
            AuthProvider= Resources.Load<AuthProviderBase>("AuthSystem/Providers/AuthProvider");
        }

       

        public AuthProviderBase GetProvider()
        {
            return AuthProvider == null ? DummyAuthProvider : AuthProvider;
        }

    }
}