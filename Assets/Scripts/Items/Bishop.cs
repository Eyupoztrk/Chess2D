using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : BaseItem
{
    protected override void SetPositionToLocateItem(GameObject item)
    {
        
        // our (2,3)
         // first Corner (3,4) (4,5) (5,6) (6,7)
         // first Corner (1,4) (0,5) 
         int x_pos = (int) item.transform.position.x;
         int y_pos = (int) item.transform.position.y;
         
        for (int x = x_pos + 1; x < 8; x++)
        {
            GameObject obj = GetObjectFromPos(x, ++y_pos);
            if (obj != null)
            {
                if (obj.GetComponent<ItemPosition>().GetIsAnyItemHere())
                {
                    obj.GetComponent<ItemPosition>().canComeHere = true;
                    break;
                }
                   
                obj.GetComponent<ItemPosition>().canComeHere = true;
            }
           
        } 
        x_pos = (int) item.transform.position.x;
        y_pos = (int) item.transform.position.y;
        for (int x = x_pos - 1; x >=0; x--)
        {
            GameObject obj = GetObjectFromPos(x, ++y_pos);
            if (obj != null)
            {
                if (obj.GetComponent<ItemPosition>().GetIsAnyItemHere())
                {
                    obj.GetComponent<ItemPosition>().canComeHere = true;
                    break;
                }
                obj.GetComponent<ItemPosition>().canComeHere = true;
            }
        }
        
        x_pos = (int) item.transform.position.x;
        y_pos = (int) item.transform.position.y;
        
        for (int x = x_pos + 1; x < 8; x++)
        {
            GameObject obj = GetObjectFromPos(x, --y_pos);
            if (obj != null)
            {
                if (obj.GetComponent<ItemPosition>().GetIsAnyItemHere())
                {
                    obj.GetComponent<ItemPosition>().canComeHere = true;
                    break;
                }
                obj.GetComponent<ItemPosition>().canComeHere = true;
            }
        }
        
        x_pos = (int) item.transform.position.x;
        y_pos = (int) item.transform.position.y;
        
        for (int x = x_pos - 1; x >=0; x--)
        {
            GameObject obj = GetObjectFromPos(x, --y_pos);
            if (obj != null)
            {
                if (obj.GetComponent<ItemPosition>().GetIsAnyItemHere())
                {
                    obj.GetComponent<ItemPosition>().canComeHere = true;
                    break;
                }
                obj.GetComponent<ItemPosition>().canComeHere = true;
            }
           
        } 
    }

    
    
    protected override bool CheckCorners(Vector3 anyPosition, Transform hit)
    {
        return false;
    }
}
