using Studio23.SS2.AuthSystem.Core;
using Studio23.SS2.AuthSystem.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsoleLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Image UserAvatar;
    
    public void UpdateText(string text)
    {
        Text.text = text;
    }

    public async void ShowUserData()
    {
        UserData userData= await AuthenticationManager.instance.GetUserData();
        Text.text = $"User ID: {userData.UserID}\nUser Name:{userData.UserName}\nUser NickName:{userData.UserNickname}";
        UserAvatar.sprite = Sprite.Create(userData.UserAvatar, new Rect(0,0,userData.UserAvatar.height,userData.UserAvatar.width), Vector2.zero);
    }




}
