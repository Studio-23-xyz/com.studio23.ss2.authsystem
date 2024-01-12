using Studio23.SS2.AuthSystem.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Studio23.SS2.AuthSystem.Core
{
    public class ProviderFactory : MonoBehaviour
    {
        private Dictionary<ProviderTypes, ProviderBase> _providers;

        public void Initialize()
        {
            _providers = new Dictionary<ProviderTypes, ProviderBase>();
            LoadFromResources();
        }

        private void LoadFromResources()
        {
            ProviderBase[] providers =  Resources.LoadAll<ProviderBase>("AuthSystem");
            for (int i = 0; i < providers.Length; i++)
            {
                RegisterProvider(providers[i]);
            }
        }

        public void RegisterProvider(ProviderBase provider)
        {
            _providers[provider.ProviderType] = provider;
        }

        public ProviderBase GetProvider(ProviderTypes type)
        {
            return _providers[type];
        }

    }
}