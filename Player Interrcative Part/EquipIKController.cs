using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EquipIKController : MonoBehaviour
{
    [SerializeField]
    ActiveWeapon1 hands;
    void LeaveHand()
    {
        Debug.Log("Left");
        hands.handIk.weight = 0;
    }
}


