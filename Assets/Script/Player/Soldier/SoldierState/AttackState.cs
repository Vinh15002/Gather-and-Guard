

using System.Threading.Tasks;
using Script.ObjectPooling;
using Script.Weapon;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class AttackState : BaseState
{

    private float timeAttack = 0f;
    public AttackState(SoldierController soldierController, SoldierData soldierData, ManagerState managerState, string animName) : base(soldierController, soldierData, managerState, animName)
    {
        timeAttack = 0f;
    }


    public override void OnExecute()
    {
        base.OnExecute();
        

        if (soldierController.DirectionMovement.magnitude > 0.3)
        {
            managerState.ChangeState(soldierController.Move);
        }
        if (CheckDistance())
        {

            managerState.ChangeState(soldierController.Idle);

        }


        RotateDirectionAttack();
        Attack();

    }

    private void Attack()
    {
        if (timeAttack <= 0)
        {

          
           
            soldierController.SpawnWeapon();
          
            timeAttack = soldierData.CoolDown;
        }
        else
        {
            
            timeAttack -=  Time.deltaTime;
        }

    }

    


    private bool CheckDistance()
    {
        Vector3 start = soldierController.transform.position;
        Vector3 end = soldierController.target.position;
        start.y = 0;
        end.y = 0;

        return Vector3.Distance(start, end) > soldierData.RangeAttack;

    }

    private void RotateDirectionAttack()
    {
        Vector3 dir = (soldierController.target.position - soldierController.transform.position).normalized;
        Quaternion rotate = Quaternion.LookRotation(dir);
        soldierController.RB.rotation = rotate;
    }

   
}