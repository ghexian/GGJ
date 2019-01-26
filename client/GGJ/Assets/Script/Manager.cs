using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GAMESTATE { WELCOME, SETTING, MAP, END }

public class Manager : MonoBehaviour {
    private GAMESTATE state;
    public WelcomeWnd welcomeWnd;
    public SettingWnd settingWnd;
    public MapWnd mapWnd;
    public EndWnd endWnd;
    [HideInInspector]
    public Dictionary<string, City> cityMap;

    void Init()
    {
        //初始化读表数据

        state = GAMESTATE.WELCOME;
    }
    void Awake()
    {
        Init();
    }
    void Update()
    {
        switch(state)
        {
            case GAMESTATE.WELCOME:
                OnBegin();
                break;
            case GAMESTATE.SETTING:
                OnSetting();
                break;
            case GAMESTATE.MAP:
                OnMap();
                break;
            case GAMESTATE.END:
                OnEnd();
                break;
        }
    }
    void OnBegin()
    {

    }
    void OnSetting()
    {

    }
    void OnMap()
    {

    }
    void OnEnd()
    {

    }
    void CloseWnd()
    {
        switch (state)
        {
            case GAMESTATE.WELCOME:
                welcomeWnd.gameObject.SetActive(false);
                break;
            case GAMESTATE.SETTING:
                settingWnd.gameObject.SetActive(false);
                break;
            case GAMESTATE.MAP:
                mapWnd.gameObject.SetActive(false);
                OnMap();
                break;
            case GAMESTATE.END:
                endWnd.gameObject.SetActive(false);
                break;
        }
    }
    public void SettingEnter()
    {
        if (state == GAMESTATE.SETTING)
            return;
        CloseWnd();
        state = GAMESTATE.SETTING;
        settingWnd.gameObject.SetActive(true);
    }
}