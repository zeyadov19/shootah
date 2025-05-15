
using UnityEngine;

public class PatrolState : IEnemyState
{
    private Enemy enemy;
    private Vector3 targetPoint;

    public EnemyStateType GetStateType() => EnemyStateType.Patrol;

    public void EnterState(Enemy enemy)
    {
        this.enemy = enemy;
        targetPoint = enemy.GetRandomPatrolPoint();
        enemy.agent.SetDestination(targetPoint);
        Debug.Log("patroling");
    }

    public void UpdateState()
    {
        if (!enemy.agent.pathPending && enemy.agent.remainingDistance < 0.5f)
        {
            enemy.SwitchState(enemy.idleState);
        }

        if (enemy.PlayerInRange())
        {
            enemy.SwitchState(enemy.chaseState);
            return;
        }

    }

    public void ExitState() { }
}


