using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum GAMESTATE { WELCOME, SETTING, MAP, END }

public class Manager : MonoBehaviour {
    private GAMESTATE state;
    public WelcomeWnd welcomeWnd;
    public SettingWnd settingWnd;
    public MapWnd mapWnd;
    public EndWnd endWnd;
    [HideInInspector]
    public Dictionary<string, City> cityMap;
    public static Manager instance;
    void Init()
    {
        //初始化读表数据
        AnalyzeMain(ReadCsv(Application.dataPath + "/Config/Main.csv"));
        state = GAMESTATE.WELCOME;
        instance = this;
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

    private List<string> ReadCsv(string filePath)
    {
        //string filePath = "C:\\Users\\user\\Desktop\\Main.csv";
        FileInfo fi = new FileInfo(filePath);
        if (!fi.Directory.Exists)
        {
            print("文件不存在");
            fi.Directory.Create();
        }
        List<string> csv = new List<string>();
        StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);
        string str = "";
        while (str != null)
        {
            str = sr.ReadLine();
            if (str == null)
            {
                break;
            }
            csv.Add(str);
        }
        return csv;
    }

    private void AnalyzeMain(List<string> csv)
    {
        if (csv == null || csv.Count <= 0)
            return;
        cityMap = new Dictionary<string, City>();
        string[] str, adjs, price;
        City city;
        for (int i = 0; i < csv.Count; ++i)
        {
            str = csv[i].Split(',');
            if(cityMap.ContainsKey(str[0]))
            {
                city = cityMap[str[0]];
                city.name = str[1];
            }
            else
            {
                city = new City(str[0], str[1]);
            }
            adjs = str[2].Split(':');
            price = str[4].Split(':');
            for(int j = 0; j < adjs.Length; ++j)
            {
                if (city.adjs.ContainsKey(adjs[j]))
                    continue;
                //city.adjs.Add(adjs[j], new Edge(adjs[j], int.Parse(price[j])));
                //if (cityMap[adjs[i]].adjs.ContainsKey(city.id))
                //   continue;
                //cityMap[adjs[i]].adjs.Add();
            }
        }
        
    }
}