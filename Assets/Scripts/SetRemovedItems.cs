using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRemovedItems : MonoBehaviour
{
    public static SetRemovedItems Instance { get; private set; }
    public GameObject[] whites;
    public GameObject[] blacks;


    private int i=0; // for whites
    private int j=0; // for blacks
    
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetWhites(GameObject gameObject)
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, whites[i].transform.position, 2f);
        i++;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    
    public void SetBlacks(GameObject gameObject)
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, blacks[j].transform.position, 2f);
        j++;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    
    
}
