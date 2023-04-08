using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessManager : MonoBehaviour
{
    [SerializeField] private Locate locate;
 


    private void Start()
    {
        locate.SetItemsOnBoard();
    }
}
