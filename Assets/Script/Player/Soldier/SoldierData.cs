using UnityEngine;

public class SoldierData : MonoBehaviour
{

    [SerializeField] private SoldierSO data;
    [SerializeField] public int Health {  get; private set; }
    [SerializeField] public int Damage { get; private set; }
    [SerializeField] public float LocalScale { get; private set; }

    [SerializeField] public float RangeAttack { get; private set; }

    private void Awake()
    {
        Health = data.Health;
        Damage = data.Damage;
        LocalScale = data.LocalScale;
        RangeAttack = data.RangeAttack;
    }

}