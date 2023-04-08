using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : BaseItem
{
    private int x;
    private int y;
    protected override void SetPositionToLocateItem(GameObject item)
    {
        
        // our (2 3)
        
        // right (4,4) (4,2)

         x = (int)item.transform.position.x;
         y = (int)item.transform.position.y;
         GetDownRightMovement();
         GetDownLeftMovement();
         GetUpLeftMovement();
         GetUpRightMovement();
         GetRightDownMovement();
         GetRightUpMovement();
         GetLeftDownMovement();
         GetLeftUpMovement();
         
    }

    #region GetObjects

    private void GetRightUpMovement()
    {
        if (x + 2 <= 7 && y + 1 <= 7)
           GetObjectFromPos(x + 2, y + 1).GetComponent<ItemPosition>().canComeHere = true;
        
    }
    
    private void GetRightDownMovement()
    {
        if (x + 2 <= 7 && y - 1 >= 0)
            GetObjectFromPos(x + 2, y - 1).GetComponent<ItemPosition>().canComeHere = true;
        
    }
    
    private void GetLeftUpMovement()
    {
        if (x - 2 >= 0 && y + 1 <= 7)
          GetObjectFromPos(x - 2, y + 1).GetComponent<ItemPosition>().canComeHere = true;
       
    }
    
    private void GetLeftDownMovement()
    {
        if (x - 2 >= 0 && y - 1 >= 0)
             GetObjectFromPos(x - 2, y - 1).GetComponent<ItemPosition>().canComeHere = true;
      
    }
    
    private void GetUpLeftMovement()
    {
        if (x - 1 >= 0 && y + 2 <= 7)
            GetObjectFromPos(x - 1, y + 2).GetComponent<ItemPosition>().canComeHere = true;
        
    } 
    
    private void GetUpRightMovement()
    {
        if (x + 1 <= 7 && y + 2 <= 7)
             GetObjectFromPos(x + 1, y + 2).GetComponent<ItemPosition>().canComeHere = true;
   
    }
    
    private void GetDownLeftMovement()
    {
        if (x - 1 >= 0 && y - 2 >= 0)
            GetObjectFromPos(x - 1, y - 2).GetComponent<ItemPosition>().canComeHere = true;
        
    } 
    
    private void GetDownRightMovement()
    {
        if (x + 1 <= 7 && y - 2 >= 0) 
            GetObjectFromPos(x + 1, y - 2).GetComponent<ItemPosition>().canComeHere = true;
      
    }

    #endregion

   
    

    protected override bool CheckCorners(Vector3 anyPosition, Transform hit)
    {
        return false; // atlar köşelerden gidemez
    }

}
