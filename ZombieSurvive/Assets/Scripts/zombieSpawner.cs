using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ������Ʈ�� �ֱ������� ����
public class zombieSpawner : MonoBehaviour
{
    public Zombie zombiePrefab; // ������ ���� ���� ������
    public ZombieData[] zombieDatas;    // ����� ���� �¾� ������
    public Transform[] spawnPoints;     // ���� Ai�� ��ȯ�� ��ġ

    private List<Zombie> zombies = new List<Zombie>();  // ������ ���� ��� ����Ʈ
    private int wave;   // ���� ���̺�

    private void Awake()
    {
        List<Dictionary<string, object>> zombies = CSVReader.Read("example");

        for (int i = 0; i < zombies.Count; i++)
        {
            ZombieData zombie = ScriptableObject.CreateInstance<ZombieData>();
            //Debug.Log(zombies[i]);
            //Debug.LogFormat("type : " + zombies[i]["ZOMBIE_TYPE"] + " hp : " + zombies[i]["HEALTH"] + " dmg : " + zombies[i]["DAMAGE"]
            //    + "\nspd : " + zombies[i]["SPEED"] + " skin : " + zombies[i]["SKIN_COLOR"] + "\n\n");

            zombie.health = float.Parse(zombies[i]["HEALTH"].ToString());
            zombie.damage = float.Parse(zombies[i]["DAMAGE"].ToString());
            zombie.speed = float.Parse(zombies[i]["SPEED"].ToString());
            ColorUtility.TryParseHtmlString(zombies[i]["SKIN_COLOR"].ToString(), out zombie.skinColor);

            zombieDatas[i] = zombie;
        }
    }

    void Update()
    {
        // ���ӿ��� ������ ���� �������� ����
        if(GameManager.instance != null && GameManager.instance.isGameover)
        {
            return;
        }

        // ���� ��� ����ģ ��� ���� ���� ����
        if(zombies.Count <= 0)
        {
            SpawnWave();
        }

        // UI ����
        UpdateUI();
    }

    // ���̺� ������ UI�� ǥ��
    private void UpdateUI()
    {
        // ���� ���̺�� ���� ���� �� ǥ��
        UIManager.instance.UpdateWaveText(wave, zombies.Count);
    }

    // ���� ���̺꿡 ���� ���� ����
    private void SpawnWave()
    {
        // ���̺� 1 ����
        wave++;

        // ���� ���̺� * 1.5�� �ݿø��� ����ŭ ���� ����
        int spawnCount = Mathf.RoundToInt(wave * 1.5f);

        // spawnCount ��ŭ ���� ����
        for (int i = 0; i < spawnCount; i++)
        {

            // ���� ���� ó�� ����
            CreateZombie();
        }
    }

    // ���� �����ϰ� ���� ������ ��� �Ҵ�
    private void CreateZombie()
    {
        // ����� ���� ������ �������� ����
        ZombieData zombieData = zombieDatas[Random.Range(0, zombieDatas.Length)];

        // ������ ��ġ�� �������� ����
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ���� ���������� ���� ���� ����
        Zombie zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);

        // ������ ������ �ɷ�ġ ����
        zombie.Setup(zombieData);

        // ������ ���� ����Ʈ�� �߰�
        zombies.Add(zombie);

        // ������ onDeath �̺�Ʈ�� �͸� �޼��� ���
        // ����� ���� ����Ʈ���� ����
        zombie.onDeath += () => zombies.Remove(zombie);
        // ����� ���� 10�� �ڿ� �ı�
        zombie.onDeath += () => Destroy(zombie.gameObject, 10f);
        // ���� ��� �� ���� ���
        zombie.onDeath += () => GameManager.instance.AddScore(100);
    }

}
