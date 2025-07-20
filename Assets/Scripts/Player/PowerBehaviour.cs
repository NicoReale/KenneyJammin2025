using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBehaviour : MonoBehaviour
{
    public bool ManaOverflow;
    public float Power;
    public GameObject AreaDamage;


    private void PowerCharge()
    {
        Power = EntityData.playerData.Power;


        if(Power > 100)
        {
            ManaOverflow = true;
            EntityData.gameData.currentGameSpeed = Mathf.Pow(Power / 100, 2);
        }
        if (Power < 100)
        {
            EntityData.gameData.currentGameSpeed = 1;
        }

        if (ManaOverflow && Input.GetKeyDown(KeyCode.Space))
        {          
                Instantiate(AreaDamage, transform.position, Quaternion.identity);
                EntityData.playerData.Power = 0;
                ManaOverflow = false;
            
        }

    }





    private void Update()
    {
        PowerCharge();
    }
}
