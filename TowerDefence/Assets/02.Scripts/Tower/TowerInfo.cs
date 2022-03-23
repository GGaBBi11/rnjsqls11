using UnityEngine;

[CreateAssetMenu(fileName = "New TowerInfo", menuName = "Tower/Create New Tower")]
public class TowerInfo : ScriptableObject
{
    public TowerType Type;
    public int level;
    public int price;
}

public enum TowerType
{
    TuMachineGun,
    Missile,
    Laser,
}
