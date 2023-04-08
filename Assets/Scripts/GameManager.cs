using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance { get; private set; }
    public GameObject gridPrefab;
    public int gridSize;
    public List<GameObject> itemPositions;
    public List<GameObject> infoPoints;


    [Header("TIMER")] 
    public int time;

    [SerializeField] private TextMeshProUGUI minuteForBlackText;
    [SerializeField] private TextMeshProUGUI secondForBlackText;
    [SerializeField] private TextMeshProUGUI minuteForWhiteText;
    [SerializeField] private TextMeshProUGUI secondForWhiteText;
    
    
    private int minuteForBlack;
    private int minuteForWhite;
    private float secondForBlack;
    private float secondForWhite;

   [HideInInspector] public bool black = false;
   [HideInInspector] public bool white = false;

   [HideInInspector] public bool isTimeOverForBlack;
   [HideInInspector] public bool isTimeOverForWhite;

   [Header("Sound")] 
   [SerializeField] private AudioSource clickSound;

   
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

    private void Start()
    {
        SetStartTime();
    }
    
    



    private void SetStartTime()
    {
        minuteForBlack =time - 1;
        minuteForWhite =time - 1;
        secondForBlack = 59;
        secondForWhite = 59;
    }

    private void Update()
    {
        if (black)
        {
            SetTimeForBlackPlayer();
            SetUIBlackTimer();
        }


        if (white)
        {
            SetTimeForWhitePlayer();
            SetUIWhiteTimer();
        }
          


        if ((int)secondForWhite == 0 && (int)minuteForWhite == 0)
        {
            white = false;
            isTimeOverForWhite = true;
        }


        if ((int)secondForBlack == 0 && (int)minuteForBlack == 0)
        {
            black = false;
            isTimeOverForBlack = true;
        }
            
        
       
        
    }




    #region TIMER

    public void SetTimeForBlackPlayer()
    {
        secondForBlack -= Time.deltaTime;

        if (secondForBlack <= 0)
        {
            minuteForBlack--;
            secondForBlack = 59;
        }
    }
    
    public void SetTimeForWhitePlayer()
    {
        secondForWhite -= Time.deltaTime;

        if (secondForWhite <= 0)
        {
            minuteForWhite--;
            secondForWhite = 59;
        }
    }
    
    
    // UI PART FOR TIMER //

    private void SetUIBlackTimer()
    {
        minuteForBlackText.text = minuteForBlack.ToString();
        secondForBlackText.text = secondForBlack.ToString("#0");
    }
    
    private void SetUIWhiteTimer()
    {
        minuteForWhiteText.text = minuteForWhite.ToString();
        secondForWhiteText.text = secondForWhite.ToString("#0");
    }
    

    #endregion

    #region Sound

    public void PlaySound()
    {
        clickSound.Play();
    }

    #endregion
    
    
}
