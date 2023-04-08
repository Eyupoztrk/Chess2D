using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locate : MonoBehaviour
{[SerializeField] private GameObject rook;
    [SerializeField] private GameObject rookB;
    
    [SerializeField] private GameObject king;
    [SerializeField] private GameObject kingB;
    
    [SerializeField] private GameObject queen;
    [SerializeField] private GameObject queenB;
    
    [SerializeField] private GameObject bishop;
    [SerializeField] private GameObject bishopB;
    
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject knightB; 
    
    [SerializeField] private GameObject pawn;
    [SerializeField] private GameObject pawnB;
    
  
    private int size =8;
    public void SetItemsOnBoard()
    {
      //  Debug.Log(itemPositions[12].transform.position);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
               LocatePawn(i,j);
               LocateRook(i,j);
               LocateKnight(i,j);
               LocateBishop(i,j);
               LocateKing(i,j);
               LocateQueen(i,j);
            }
        }
    }

    private void LocatePawn(int i , int j)
    {
        if (j == 6)
            Instantiate(pawn, new Vector3(i, j, 0), Quaternion.identity);
        else if(j ==1)
            Instantiate(pawnB, new Vector3(i, j, 0), Quaternion.identity);
    }

    private void LocateRook(int i,int j)
    {
        if((i == 0 && j == 7) || (i == 7 && j == 7) )
            Instantiate(rook, new Vector3(i, j, 0), Quaternion.identity);
        
        if((i == 0 && j == 0) || (i == 7 && j == 0) )
            Instantiate(rookB, new Vector3(i, j, 0), Quaternion.identity);
    }
    
    private void LocateKnight(int i,int j)
    {
        if((i == 1 && j == 7) || (i == 6 && j == 7) )
            Instantiate(knight, new Vector3(i, j, 0), Quaternion.identity);
        
        if((i == 1 && j == 0) || (i == 6 && j == 0) )
            Instantiate(knightB, new Vector3(i, j, 0), Quaternion.identity);
    }
    
    private void LocateBishop(int i,int j)
    {
        if((i == 2 && j == 7) || (i == 5 && j == 7) )
            Instantiate(bishop, new Vector3(i, j, 0), Quaternion.identity);
        
        if((i == 2 && j == 0) || (i == 5 && j == 0) )
            Instantiate(bishopB, new Vector3(i, j, 0), Quaternion.identity);
    }
    
    private void LocateQueen(int i,int j)
    {
        if((i == 3 && j == 7)  )
            Instantiate(queen, new Vector3(i, j, 0), Quaternion.identity);
        
        if((i == 3 && j == 0)  )
            Instantiate(queenB, new Vector3(i, j, 0), Quaternion.identity);
    }
    
    private void LocateKing(int i,int j)
    {
        if((i == 4 && j == 7) )
            Instantiate(king, new Vector3(i, j, 0), Quaternion.identity);
        
        if((i == 4 && j == 0) )
            Instantiate(kingB, new Vector3(i, j, 0), Quaternion.identity);
    }
}
