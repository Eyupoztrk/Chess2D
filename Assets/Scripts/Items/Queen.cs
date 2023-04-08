using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : BaseItem
{
    protected override void SetPositionToLocateItem(GameObject item)
    {


        int x_pos = (int)item.transform.position.x;
        int y_pos = (int)item.transform.position.y;
        GameObject obj = null;

          obj =  GetObjectFromPos(x_pos + 1, y_pos);
          if(obj != null) 
              obj.GetComponent<ItemPosition>().canComeHere = true;
          
        obj =  GetObjectFromPos(x_pos - 1, y_pos);
        if(obj != null)
        obj.GetComponent<ItemPosition>().canComeHere = true;
        
        obj = GetObjectFromPos(x_pos, y_pos -1);
        if(obj != null)
        obj .GetComponent<ItemPosition>().canComeHere = true;
        
        
        obj =  GetObjectFromPos(x_pos, y_pos +1);
        if(obj != null)
        obj.GetComponent<ItemPosition>().canComeHere = true;
        
        obj =  GetObjectFromPos(x_pos + 1, y_pos + 1);
        if(obj != null)
        obj .GetComponent<ItemPosition>().canComeHere = true;
        
        
        obj =   GetObjectFromPos(x_pos - 1, y_pos - 1);
        if(obj != null)
        obj.GetComponent<ItemPosition>().canComeHere = true;
        
        obj =  GetObjectFromPos(x_pos + 1, y_pos - 1);
        if(obj != null)
        obj .GetComponent<ItemPosition>().canComeHere = true;
        
        
        obj =   GetObjectFromPos(x_pos - 1, y_pos + 1);
        if(obj != null)
        obj.GetComponent<ItemPosition>().canComeHere = true;
        

    }

    protected override bool CheckCorners(Vector3 anyPosition, Transform hit)
    {
        return false;
    }
}
