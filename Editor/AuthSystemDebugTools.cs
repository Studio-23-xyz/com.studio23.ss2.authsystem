using Cysharp.Threading.Tasks;
using Studio23.SS2.AuthSystem.Core;
using Studio23.SS2.AuthSystem.Data;
using UnityEditor;
using UnityEngine;

namespace Studio23.SS2.AuthSystem.Editor
{
    [CustomEditor(typeof(AuthenticationManager))]
    public class AuthSystemDebugTools : UnityEditor.Editor
    {
        private bool _showDebugTools;

        private UserData userData;

        public override async void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AuthenticationManager authManager = (AuthenticationManager)target;

            // Start Debug Tools foldout section
            _showDebugTools = EditorGUILayout.BeginFoldoutHeaderGroup(_showDebugTools, "Debug Tools");

            if (_showDebugTools)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                if (GUILayout.Button("Get User Data"))
                {
                   userData =  await authManager.GetUserData();
                }

                if(userData != null)
                {
                    EditorGUILayout.LabelField("User Information", EditorStyles.boldLabel);
                    EditorGUILayout.LabelField($"Name: {userData.UserName}");
                    EditorGUILayout.LabelField($"NickName: {userData.UserNickname}");
                    EditorGUILayout.LabelField($"UserID: {userData.UserID}");

                    if(userData.UserAvatar != null)
                    {
                        EditorGUILayout.LabelField("Avatar", EditorStyles.boldLabel);
                        Rect textureRect = GUILayoutUtility.GetRect(100, 100, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                        EditorGUI.DrawPreviewTexture(textureRect, userData.UserAvatar);
                    }


                }

                EditorGUILayout.EndVertical();
            }

            // End Debug Tools foldout section
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }

}

