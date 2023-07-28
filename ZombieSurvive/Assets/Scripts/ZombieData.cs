using UnityEngine;

// 좀비 생성시 사용할 셋업 데이터
[CreateAssetMenu(menuName = "Scriptable/ZombieData", fileName = "Zombie Data")]
public class ZombieData : ScriptableObject {
    public float health = 100f; // 체력
    public float damage = 20f; // 공격력
    public float speed = 2f; // 이동 속도
    public Color skinColor = Color.white; // 피부색
}

//public class ZombieData2
//{
//    public float health = default; // 체력
//    public float damage = default; // 공격력
//    public float speed = default; // 이동 속도
//    public Color skinColor = default; // 피부색

//    public ZombieData2 () { }

//    public ZombieData2(ZombieData data) 
//    {
//        health = data.health;
//        damage = data.damage;
//        speed = data.speed;
//        skinColor = data.skinColor;
//    }

//    public void SetUpData(float health_, float damage_, float speed_, Color skinColor_)
//    {
//        health = health_;
//        damage = damage_;
//        speed = speed_;
//        skinColor = skinColor_;
//    }
//}