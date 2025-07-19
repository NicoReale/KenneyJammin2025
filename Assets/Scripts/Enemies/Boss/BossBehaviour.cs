using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float behaviorDuration = 3f;

    [Header("Lluvia de proyectiles")]
    public GameObject ProyectilePrefab;
    public Transform[] floorTargets;
    public float spawnHeight = 10f;
    public float timeBetweenProyectiles = 1f; 
    public int ProyectilesPerAttack = 5;

    private enum BossAction
    {
        Shoot,
        Jump,
        Charge,
        Summon
    }

    private BossAction currentAction;
    private bool isActing = false;

    void Start()
    {
        StartCoroutine(ExecuteBehavior());
    }

    private IEnumerator ExecuteBehavior()
    {
        while (true)
        {
            // Elegir nueva acción aleatoria distinta de la anterior
            BossAction newAction = GetRandomActionExcluding(currentAction);
            currentAction = newAction;

            Debug.Log("Nuevo comportamiento: " + currentAction);

            // Ejecutar comportamiento (simulado con debug por ahora)
            switch (currentAction)
            {
                case BossAction.Shoot:
                    yield return StartCoroutine(LluviaProyectiles());
                    break;
                case BossAction.Jump:
                    Disparos();
                    break;
                case BossAction.Charge:
                    Teleport();
                    break;
                case BossAction.Summon:
                    Summon(); //todavia no se un 4to, pueden ser solo 3
                    break;
            }

            // Esperar a que termine el comportamiento
            yield return new WaitForSeconds(behaviorDuration);
        }
    }

    private BossAction GetRandomActionExcluding(BossAction exclude)
    {
        List<BossAction> options = new List<BossAction>((BossAction[])System.Enum.GetValues(typeof(BossAction)));
        options.Remove(exclude); // Excluir el comportamiento anterior

        return options[Random.Range(0, options.Count)];
    }

   

    void ProyectilesArriba()
    {
        int index = Random.Range(0, floorTargets.Length);
        Transform target = floorTargets[index];

        Vector3 spawnPosition = new Vector3(
            target.position.x,
            target.position.y + spawnHeight,
            target.position.z
        );

        Instantiate(ProyectilePrefab, spawnPosition, Quaternion.identity);
    }
    private IEnumerator LluviaProyectiles()
    {
        for (int i = 0; i < ProyectilesPerAttack; i++)
        {
            ProyectilesArriba();
            yield return new WaitForSeconds(timeBetweenProyectiles);
        }
    }

    void Disparos()
    {
       
    }

    void Teleport()
    {
      
    }

    void Summon()
    {
        
    }
}

