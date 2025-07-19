using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D _rb;
    [SerializeField]
    protected SpriteRenderer sr;
    [SerializeField]
    protected EnemyTarget enemyTarget;               // El personaje principal

    public float attackRange = 2f;        // Rango para detenerse y atacar
    public float attackInterval = 1.5f;   // Tiempo entre ataques
    public LayerMask CharacterLayer;
    public bool stop;

    private float attackTimer = 0f;
    private bool playerInRange = false;
    Vector3 playerDir;

    protected HealthComponent health;

    protected Action AttackForm;

    private void Awake()
    {
        health = new HealthComponent();
        health.DeadCallback = Died;
    }

    private void Start()
    {
        enemyTarget = GameManager.Instance.enemyTarget;
    }

    public void Died()
    {
        Destroy(gameObject);
    }
    public virtual bool AttackRange()
    {
        Vector3 directionToPlayer = (enemyTarget.transform.position - transform.position).normalized;
        Vector3 circlePosition = transform.position + directionToPlayer * attackRange;

        return Physics2D.OverlapCircle(circlePosition, 0.5f, CharacterLayer);
    }

    public virtual EnemyBehaviour Initialize(ATTACKANGLE side)
    {
        return this;
    }

    private void Update()
    {
        playerDir = (enemyTarget.transform.position - transform.position).normalized;

        if(stop)
        {
            AttackForm?.Invoke();
        }
    }

    void FixedUpdate()
    {
        if (!stop)
        {
            Vector2 moveDelta = playerDir * EntityData.EnemyBasicFlying.speed * EntityData.gameData.currentGameSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + moveDelta);
        }
        if (AttackRange())
        {
            stop = true;
        }
    }

    public void TakeDamage(int damage)
    {
        health.TakeDamage(EntityData.fireballData.damage);
    }

}
