using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemPosition : MonoBehaviour
{
    [FormerlySerializedAs("isHaveAnyItemHere")] [SerializeField]private bool isAnyItemHere;
    public GameObject item;

    public bool canComeHere;

   

    public bool GetIsAnyItemHere()
    {
        return isAnyItemHere;
    }

    public void SetIsAnyItemHere(bool value)
    {
        isAnyItemHere = value;
    }
    
}
