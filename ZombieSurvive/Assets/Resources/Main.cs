//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class Main : MonoBehaviour
//{
//    public static ZombieData2[] zombieData2;

//    void Awake()
//    {
//        List<Dictionary<string, object>> data = CSVReader.Read("example");
//        zombieData2 = new ZombieData2[data.Count];

//        for (var i = 0; i < data.Count; i++)
//        {
//            print("ZOMBIE_TYPE " + data[i]["ZOMBIE_TYPE"] + " " +
//                   "HEALTH " + data[i]["HEALTH"] + " " +
//                   "DAMAGE " + data[i]["DAMAGE"] + " " +
//                   "SPEED " + data[i]["SPEED"] + " " +
//                   "SKIN_COLOR " + data[i]["SKIN_COLOR"]);

//            // ZombieData2 객체 생성
//            zombieData2[i] = new ZombieData2();

//            // ZombieData2 객체에 데이터 설정
//            float health = float.Parse(data[i]["HEALTH"].ToString());
//            float damage = float.Parse(data[i]["DAMAGE"].ToString());
//            float speed = float.Parse(data[i]["SPEED"].ToString());

//            Debug.Log(data[i]["SKIN_COLOR"]);
//            string convert = data[i]["SKIN_COLOR"].ToString();

//            if (convert.Length < 6)
//            {
//                convert = "0" + convert;
//            }
//            Color skinColor;
//            ColorUtility.TryParseHtmlString("#"+ convert + "FF", out skinColor);
//            zombieData2[i].SetUpData(health, damage, speed, skinColor);
//        }        
//    }

//    // Use this for initialization
//    void Start()
//    {
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}