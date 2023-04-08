using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    
    private GameObject Parent;
    

    private void Start()
    {
       
    }

    public void Create()
    {
        Parent = new GameObject("Board");
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                var copy= Instantiate(GameManager.Instance.gridPrefab, new Vector3(i , j, 0), Quaternion.identity);
                copy.transform.parent = Parent.transform;
                copy.transform.name = "(" + i + "," + j + ")";
            }
        }
    }

}
