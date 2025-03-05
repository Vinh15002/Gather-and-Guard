using DG.Tweening;
using System;
using System.Collections;
using Script.ObjectPooling;
using Script.Weapon;
using UnityEngine;

public class SoldierController : MonoBehaviour
{

    public Transform WeaponTarget;
    public Vector3 DirectionMovement { get;set; }
    public SoldierData SoldierData { get ; private set;}
    public Animator Animator {  get; private set; }
    public Rigidbody RB { get; private set; }

    
    
    
    #region  State Machine

    public ManagerState ManagerState { get; private set; }
    public IdleState Idle { get; private set; }
    public MoveState Move {  get; private set; }

    public AttackState Attack { get; private set; }

    public Transform target { get; private set; }


    #endregion
    


    

    private void Start()
    {

        ManagerState = new ManagerState();
        SoldierData = GetComponent<SoldierData>();
        Idle = new IdleState(this, SoldierData, ManagerState, "Idle");
        Move = new MoveState(this, SoldierData, ManagerState, "Move");
        Attack = new AttackState(this, SoldierData, ManagerState, "Attack");
        transform.localScale = Vector3.one * SoldierData.LocalScale;
        Animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        ManagerState.Initilize(Idle);
    }

    private void Update()
    {
        ManagerState.CurrentState.OnExecute();
    }





    public void SetPostion(Vector3 postion)
    {
        this.transform.DOLocalMove(postion, 1f);
    }

    public void onMove(Vector3 directionMovement)
    {
        DirectionMovement = directionMovement;
    }

    public void SetAttack(Collider collider)
    {

        target = collider.transform;
        ManagerState.ChangeState(Attack);
       
    }


    public void SpawnWeapon()
    {
        StartCoroutine(RemoveWeaponCouroutine());
    }

    private IEnumerator RemoveWeaponCouroutine()
    {
        
        yield return new WaitForSeconds(0.05f);
        this.WeaponTarget.gameObject.SetActive(false);
        GameObject weapon = WeaponPooling.Instance.GetPooledObject();
        weapon.transform.position = WeaponTarget.position;
        weapon.SetActive(true);
        weapon.GetComponent<WeaponMovement>().SetTarget(target.position, weapon.transform.position, SoldierData.CoolDown - 0.1f);
        weapon.GetComponent<WeaponDealDamage>().SetDamage(SoldierData.Damage);
        yield return new WaitForSeconds(SoldierData.CoolDown - 0.1f);
        this.WeaponTarget.gameObject.SetActive(true);
    }

 


}