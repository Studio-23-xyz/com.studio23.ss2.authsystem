using System;
using UnityEngine;


namespace Studio23.SS2.AuthSystem.Data
{
    [Serializable]
    public class UserData
    {
        /// <summary>
        /// UniqueID from platforms
        /// </summary>
        public string UserID;
        public string UserName;
        public string UserNickname;
        public Texture2D UserAvatar;

    }
}
