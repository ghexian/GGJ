using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeWnd : MonoBehaviour {
    private Transform startGameBtn;
    
    void Awake()
    {
        startGameBtn = this.transform.Find("Button");
        BindEvent();
    }
    void BindEvent()
    {
        UIEventListener.Get(startGameBtn.gameObject).onClick += OnStartGameBtnClick;
    }
    void OnStartGameBtnClick(GameObject _obj)
    {
        Manager.instance.SettingEnter();
    }
}
