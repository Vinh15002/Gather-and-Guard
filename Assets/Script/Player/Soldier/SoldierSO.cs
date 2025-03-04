using UnityEngine;


[CreateAssetMenu(fileName ="Soldier", menuName = "Data/Solider")]
public  class SoldierSO : ScriptableObject
{
    public int Health;
    public int Damage;
    public float LocalScale;

    public float RangeAttack;
}