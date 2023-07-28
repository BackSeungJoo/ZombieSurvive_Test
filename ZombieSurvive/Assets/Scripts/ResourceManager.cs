using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEditor;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager m_instance;

    public static ResourceManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    // private string dataPath = default;
    private static string zombieDataPath = default;
    public ZombieData zombieData_default = default; // 캐싱했다.

    private void Awake()
    {
        // dataPath = Application.dataPath;
        // zombieDataPath = string.Format("{0}/{1}", Application.dataPath, "01_ZombieSurvive/Scriptable");

        // byte[] byteZombieData = System.IO.File.ReadAllBytes(zombieDataPath);

        zombieDataPath = "Scriptable";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Default");

        zombieData_default = Resources.Load<ZombieData>(zombieDataPath);

        // Debug.LogFormat("Data Path: {0}", zombieDataPath);
        // Debug.LogFormat("Zombie data: {0}, {1}, {2}", zombieData_.health, zombieData_.damage, zombieData_.speed);

        Debug.LogFormat("게임 save 데이터는 이곳에 저장하는 것이 일반적이다. -> {0}", Application.persistentDataPath);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
