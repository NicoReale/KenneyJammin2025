using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTutorial : MonoBehaviour
{
    float timer = 60;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0 )
        {
            Destroy(gameObject);
        }
    }
}
