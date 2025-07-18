using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ATTACKANGLE 
{
    LEFT,
    RIGHT, 
    TOP, 
    TOPRIGHT,
    TOPLEFT
}

public class UIAttackButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    PlayerBehaviour player;
    [SerializeField]
    ATTACKANGLE side;
    public void OnPointerClick(PointerEventData eventData)
    {
        player.Attack(side);
    }
}
