using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;



public class PlayerControllers : MonoBehaviour {

    public GameObject obj;

    Dictionary<int, string> myDictionary = new Dictionary<int, string>();

    private float m_X, m_Y = 0;
    private float m_moveSpeed   = 10;
    private float m_rotateSpeed = 1;
    
	
	void Start () {
      
	}	
	void Update () {
        Control();
	}

    void Control()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("WWW");
            //读取CSV文件
            string filePath = "C:\\Users\\user\\Desktop\\Main.csv";
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Directory.Exists)
            {
                print("文件不存在");
                fi.Directory.Create();
            }
            StreamReader sr = new StreamReader(filePath,System.Text.Encoding.UTF8);
            string str = "";
            string s = Console.ReadLine();
            while (str != null)
            {
                str = sr.ReadLine();
                if (str == null)
                {
                    break;         
                }
                string[] xu = new String[7];
                xu = str.Split(',');
                int    m_StartID        = int.Parse(xu[0]);
                string m_CityName       = xu[1];
                string m_Adjacent       = xu[2];
                string m_AdjacentName   = xu[3];
                string m_TicketNumbers  = xu[4];
                string m_TicketPrice    = xu[5];
                string m_CityDesc       = xu[6];

                myDictionary.Add(m_StartID, str);

            }
        }

    }
}
