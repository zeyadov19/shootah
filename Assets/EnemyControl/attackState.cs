using UnityEngine;

public class AttackState : IEnemyState
{
    private Enemy enemy;
    private Transform player;
    private float attackCooldown = 1f;
    private float timer;

    public EnemyStateType GetStateType() => EnemyStateType.Attack;

    public void EnterState(Enemy enemy)
    {
        this.enemy = enemy;
        player = GameObject.FindWithTag("Player").transform;
        timer = attackCooldown;
        enemy.agent.isStopped = true;
    }

   public void UpdateState()
{
    timer -= Time.deltaTime;
    if (timer <= 0f)
    {
        Debug.Log("Enemy attacks player!");
        timer = attackCooldown;

        // Do hitscan attack
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        Ray ray = new Ray(enemy.transform.position + Vector3.up, direction); // Slightly above ground
        if (Physics.Raycast(ray, out RaycastHit hit, 10f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(30f); // You can change damage amount
                    
                }
            }
        }
    }

    float distance = Vector3.Distance(enemy.transform.position, player.position);
    if (distance > 2f)
    {
        enemy.SwitchState(enemy.chaseState);
    }
}

    public void ExitState()
    {
        enemy.agent.isStopped = false;
    }
}
