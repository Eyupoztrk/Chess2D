using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    protected Vector3 homePosition; // dokunduğumuz andaki taşın bulunduğu pozisyon
    public List<GameObject> lastObjects; // dokunduğumuz andaki pozisyonda bulunan obje
    [SerializeField] private LayerMask layerMask; 

    private void Start()
    {
        var hit = SetRaycast(); // başlar başlamaz bir ışın gönderiyoruz 
        if (hit)
        {
            hit.transform.GetComponent<ItemPosition>().SetIsAnyItemHere(true); // bulunduğumuz objeye burada bulunduğumuzu true yapıyoruz
            hit.transform.GetComponent<ItemPosition>().item = this.gameObject; // bulunan objenin biz olduğunu belirliyoruz
        }
        SetWhiteTimer(); // ilk başlayan takım beyaz oyuncular
    }
    

    public void Down() // taşlara dokunduğunda çalışır
    {
        var hit = SetRaycast();
        if (hit)
        {
            homePosition = transform.position; 
            lastObjects.Add(hit.transform.gameObject as GameObject); // taşa dokunduğumuzda ışının vurduğu yer bizim bulunduğumuz son yerdir
            
           SetPositionToLocateItem(hit.transform.gameObject as GameObject); // dokunduğumuz andaki taşın gidebileceği yerleri belirler
           SetActiveInfoPoints(transform.position); // o yerleri gösterir
        }

       
    }

    public void Drag() // taşı sürüklerken çalışır
    {
        // taşın konumunu mouse'un konumuna getirir
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y); 
    }

  
    public virtual void Up() // taşı bıraktığımızda çalışır
    {
       
        var hit = SetRaycast();
        if (hit)
        {
            // taşın gidebileceği yerlerin durmunu kontrol eder ama eğer gideceği yerde bir taş varsa çalışmaz
            if (CheckAnyposition(hit.transform.gameObject) &&
                !hit.transform.GetComponent<ItemPosition>().GetIsAnyItemHere()) 
            {
                
                RemoveLastObjectOnBoard(); // taşı bıraktığımızda ki bulunan son objeyi siler
                transform.position = hit.transform.position; // yeni konumumuzu belirler
                hit.transform.GetComponent<ItemPosition>().SetIsAnyItemHere(true); //buraya ait olduğumuzu belirler
                hit.transform.GetComponent<ItemPosition>().item = this.gameObject;
                
                
                // zamanlayıcıyı belirler
                if(this.CompareTag("BlackItem"))
                    SetWhiteTimer();
                if(this.CompareTag("WhiteItem"))
                    SetBlackTimer();
                
                GameManager.Instance.PlaySound(); // sesi oynatır
              

            }
            // taşın gidebileceği yerlerin durmunu kontrol eder ve eğer gideceği yerde bir taş varsa çalışır 
            else if (CheckAnyposition(hit.transform.gameObject) &&
                     hit.transform.GetComponent<ItemPosition>().GetIsAnyItemHere()) 
            {

                if (!hit.transform.GetComponent<ItemPosition>().item.transform.tag.Equals(transform.tag)) // kendi taşımızı yiyemeyiz
                    {
                        RemoveItem(hit.transform);
                        RemoveLastObjectOnBoard();
                        transform.position = hit.transform.position;
                        hit.transform.GetComponent<ItemPosition>().SetIsAnyItemHere(true);
                        hit.transform.GetComponent<ItemPosition>().item = this.gameObject;
                        
                    }
                    else
                    {
                        transform.position = homePosition;
                    }
               
                if(this.CompareTag("BlackItem"))
                    SetWhiteTimer();
                if(this.CompareTag("WhiteItem"))
                    SetBlackTimer();
                
                GameManager.Instance.PlaySound();

            }
            else
            {
                if (CheckCorners(hit.transform.position,hit.transform)) // eğer köşelerde bir taş varsa git (piyonlar için)
                {
                    RemoveItem(hit.transform);
                    RemoveLastObjectOnBoard();
                    transform.position = hit.transform.position;
                    hit.transform.GetComponent<ItemPosition>().SetIsAnyItemHere(true);
                    hit.transform.GetComponent<ItemPosition>().item = this.gameObject;
                    
                    if(this.CompareTag("BlackItem"))
                        SetWhiteTimer();
                    if(this.CompareTag("WhiteItem"))
                        SetBlackTimer();

                    GameManager.Instance.PlaySound();

                }
                else
                transform.position = homePosition;
            }
        } 
        else  // bir yere çarpmıyorsa önceki yerine geri dön
        {
            transform.position = homePosition;
        }
        
        SetInactiveInfoPoints(); // info noktalarını kapat

    }
    
    // ışın göndermemizi sağlar
    private RaycastHit2D SetRaycast()
    {
        var hit = Physics2D.Raycast(transform.position, Vector3.forward, 100, layerMask);
        return hit;
       
    }
    
    // Info noktlarını actif hale getirir
    protected virtual void SetActiveInfoPoints(Vector3 position)
    { 
        foreach (var item in GameManager.Instance.itemPositions)
        {
            if (item.GetComponent<ItemPosition>().canComeHere)
            {
                item.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    // Info noktlarını inactif hale getirir
    protected virtual void SetInactiveInfoPoints()
    {
        foreach (var item in GameManager.Instance.itemPositions)
        {
            item.GetComponent<SpriteRenderer>().enabled = false;
            item.GetComponent<ItemPosition>().canComeHere = false;
        }
    }

    // herhangi bir noktayı kontrol eder (oraya gidebilir miyiz ya da orada bir taş varsa o taşı alabilir miyiz gibi)
    protected virtual bool CheckAnyposition(GameObject item) /// 
    {
        if (item.GetComponent<ItemPosition>().canComeHere)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual void SetPositionToLocateItem(GameObject item)
    {
        foreach (var i in GameManager.Instance.itemPositions)
        {
            CheckAnyposition(i);
        }
    }
    
    // x ve y noktalarının bulunduğu yerdeki objeyi bulup döndürür
    protected virtual GameObject GetObjectFromPos(int x, int y)
    {
        GameObject returnedObjcet = null;
        foreach (var item in GameManager.Instance.itemPositions)
        {
            if (item.transform.position.x == x && item.transform.position.y == y)
            {
                returnedObjcet = item;
                break;
            }
        }

        return returnedObjcet;

    }
    
    
   

    #region Removaling

    protected virtual bool CheckCorners(Vector3 anyPosition,Transform hit) // piyonlar için köşeleri kontrol eder
    {
        if (hit.GetComponent<ItemPosition>().GetIsAnyItemHere())
        {
            if (anyPosition.y  + 1 == homePosition.y)
            {
                if (anyPosition.x - 1 == homePosition.x || anyPosition.x + 1 == homePosition.x)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
        
    }
    
    
    private void RemoveLastObjectOnBoard()
    {
        lastObjects[0].GetComponent<ItemPosition>().SetIsAnyItemHere(false);
        lastObjects[0].GetComponent<ItemPosition>().item = null;
        lastObjects.Clear();
    }
    
    // Taş alma kısmı *** 
    private void RemoveItem(Transform hit)
    {
        Debug.Log(hit.GetComponent<ItemPosition>().item.name);
        if(hit.GetComponent<ItemPosition>().item.CompareTag("BlackItem"))
        SetRemovedItems.Instance.SetBlacks(hit.GetComponent<ItemPosition>().item);
        
        if(hit.GetComponent<ItemPosition>().item.CompareTag("WhiteItem"))
        SetRemovedItems.Instance.SetWhites(hit.GetComponent<ItemPosition>().item);
       
    }
    #endregion

    #region Timer

    private void SetWhiteTimer()
    {
        GameManager.Instance.white = true;
        GameManager.Instance.black = false;
    } 
    
    private void SetBlackTimer()
    {
        GameManager.Instance.white = false;
        GameManager.Instance.black = true;
    }

    #endregion
}
