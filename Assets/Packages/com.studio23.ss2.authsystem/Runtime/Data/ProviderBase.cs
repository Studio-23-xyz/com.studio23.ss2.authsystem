using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Studio23.SS2.AuthSystem.Data
{
    public abstract class ProviderBase : MonoBehaviour
    {
        public abstract UniTask<int> Authenticate();
        public abstract UniTask<UserData> GetUserData();
    }

}