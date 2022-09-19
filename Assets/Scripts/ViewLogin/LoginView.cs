using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : View
{
    [SerializeField] private Button _loginBtn;


    public override void Initialize()
    {
        _loginBtn.onClick.AddListener(() => { ViewManager.Show<MainMenu>(); });

        Debug.Log("ayy init workin");
    }
}
