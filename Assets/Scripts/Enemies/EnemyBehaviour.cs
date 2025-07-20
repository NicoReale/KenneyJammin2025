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

    Vector3 playerDir;

    protected HealthComponent health;

    protected Action<float> AttackForm;
    protected Action<EnemyBehaviour> OnDied;
    [SerializeField]
    protected Animator animator;

    protected bool isSearching = true;

    protected abstract int Damage();

    protected bool isAttacking = false;

    private void Awake()
    {
        health = new HealthComponent();
        health.DeadCallback = Died;
    }

    private void Start()
    {
        enemyTarget = GameManager.Instance.enemyTarget;
        AttackForm += Attack;
        animator.SetBool("Stop", stop);
    }

    public abstract void Died();
    public abstract void Attack(float time);
    public virtual bool AttackRange()
    {
        Vector3 directionToPlayer = (enemyTarget.transform.position - transform.position).normalized;
        Vector3 circlePosition = transform.position + directionToPlayer * attackRange;

        if(!isSearching)
        {
            return false;
        }
        return Physics2D.OverlapCircle(circlePosition, 0.5f, CharacterLayer);
    }

    public virtual EnemyBehaviour Initialize(ATTACKANGLE side, Action<EnemyBehaviour> onDied)
    {
        OnDied += onDied;
        return this;
    }

    private void Update()
    {
        playerDir = (enemyTarget.transform.position - transform.position).normalized;

        if (isAttacking)
        {
            AttackForm?.Invoke(Time.deltaTime);
        }
    }


    void FixedUpdate()
    {
        if (!stop)
        {
            Vector2 moveDelta = playerDir * EntityData.EnemyBasicFlying.speed * EntityData.gameData.currentGameSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + moveDelta);
        }
        if (AttackRange() && stop == false)
        {
            stop = true;
            isAttacking = true;
            animator.SetBool("Stop", stop);
        }
    }

    public void TakeDamage(int damage)
    {
        health.TakeDamage(EntityData.fireballData.damage);
    }

    public void DamagePlayer()
    {
        GameManager.Instance.player.TakeDamage(Damage());
    }

}
