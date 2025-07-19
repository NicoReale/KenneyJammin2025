using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBehaviour : MonoBehaviour
{
    public bool ManaOverflow;
    public float Power;

    private void PowerCharge()
    {
        if(Power > 100)
        {
            ManaOverflow = true;
            EntityData.gameData.currentGameSpeed = Mathf.Pow(Power / 100, 2);
        }
        if (Power < 100)
        {
            EntityData.gameData.currentGameSpeed = 1;
        }
    }
    private void Update()
    {
        PowerCharge();
    }
}
