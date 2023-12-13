using System;
using UnityEngine;

namespace Studio23.SS2.AuthSystem.Data
{
    public abstract class ProviderBase : ScriptableObject
    {
        public Core.AuthEvent OnAuthSuccess;
        public abstract void Authenticate();
        public abstract UserData GetUserData();
    }

}