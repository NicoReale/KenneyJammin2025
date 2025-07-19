using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    float speed;
    PlayerBehaviour player;
    [SerializeField]
    SpriteRenderer sr;
    int dir = -1;

    public Transform Character;              // El personaje principal
    public float attackRange = 2f;        // Rango para detenerse y atacar
    public float attackInterval = 1.5f;   // Tiempo entre ataques
    public Transform CharacterCheck;
    public LayerMask CharacterLayer;
    public bool stop;

    private float attackTimer = 0f;
    private bool playerInRange = false;


    private void Start()
    {
        
        if (AttackRange())
        {
            attackTimer += Time.deltaTime * EntityData.gameData.currentGameSpeed;


            if (attackTimer >= attackInterval)
            {
                Attack();
                attackTimer = 0f;
            }
        }
        void Attack()
        {
            // Acá va lo que hace el ataque: daño, animación, etc.
            Debug.Log("Enemigo ataca con su espada");
        }
    }
    private bool AttackRange()
    {
        Debug.Log("en rango");

        return Physics2D.OverlapCircle(transform.position + new Vector3(dir, 0 ,0), 0.5f, CharacterLayer);
        
    }

    public EnemyBehaviour Initialize(ATTACKANGLE side)
    {
        player = GameManager.Instance.player;

        if(side == ATTACKANGLE.LEFT)
        {
            dir = 1;
        }
        else sr.flipX = true;

        return this;
    }

    void Update()
    {
        if(!stop)
        {
            transform.position += (Vector3.right * dir) * (EntityData.EnemyMelee.speed * EntityData.gameData.currentGameSpeed) * Time.deltaTime;
        }
        if (AttackRange())
        {
            stop = true;
        }
    }
}
