using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : BaseItem
{
    protected override void SetPositionToLocateItem(GameObject item)
    {
        
        
        for (int x = (int) item.transform.position.x -1 ; x >= 0 ; x--) // left side
        {
            // buraya sol tarafta kalan kısımları getirir
            GameObject obj = GetObjectFromPos(x, (int)homePosition.y);
            if (obj.GetComponent<ItemPosition>().GetIsAnyItemHere())
            {
                obj.GetComponent<ItemPosition>().canComeHere = true;
                break;
            }
            obj.GetComponent<ItemPosition>().canComeHere = true;

        }
          
        for (int x = (int) item.transform.position.x + 1 ; x < 8 ; x++) // right side
        {
            // buraya sağ tarafta kalan kısımları getirir
            GameObject obj = GetObjectFromPos(x, (int)homePosition.y);
            if (obj.GetComponent<ItemPosition>().GetIsAnyItemHere())
            {
                obj.GetComponent<ItemPosition>().canComeHere = true;
                break;
            }
            obj.GetComponent<ItemPosition>().canComeHere = true;
                     
                  
        }


        for (int y = (int) item.transform.position.y - 1 ; y >= 0 ; y--) // down side
        {
            // buraya aşağı tarafta kalan kısımları getirir
            GameObject obj = GetObjectFromPos((int)homePosition.x, y);
            if (obj.GetComponent<ItemPosition>().GetIsAnyItemHere())
            {
                obj.GetComponent<ItemPosition>().canComeHere = true;
                break;
            }
            obj.GetComponent<ItemPosition>().canComeHere = true;
                   
        }
          
        for (int y = (int) item.transform.position.y + 1 ; y < 8 ; y++) // up side
        {
            // buraya yukarı tarafta kalan kısımları getirir
            GameObject obj = GetObjectFromPos((int)homePosition.x, y);
            if (obj.GetComponent<ItemPosition>().GetIsAnyItemHere())
            {
                obj.GetComponent<ItemPosition>().canComeHere = true;
                break;
            }
            obj.GetComponent<ItemPosition>().canComeHere = true;
                  
        }
        
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
