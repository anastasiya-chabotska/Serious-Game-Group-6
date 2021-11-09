using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] double loan;
    [SerializeField] double education_cost;
    [SerializeField] bool isCuny;
    [SerializeField] bool isPrivate;
    [SerializeField] double earnings;
    [SerializeField] double investments;
    [SerializeField] double savings;
    public const int CUNY_COST = 20000;
    public const int PRIVATE_COST = 80000;
    public const int CUNY_LOAN_INTEREST = 746;
    public const int PRIVATE_LOAN_INTEREST = 2984;
    public const int PART_TIME_JOB = 15*20*52; //per year
    public const int FULL_TIME_JOB = 15*40*52; //per year
    public const int PUBLIC_SECTOR_JOB = 50000; //per year
    public const int PRIVATE_SECTOR_JOB = 75000; //per year


    // [SerializeField] string playerName;
    // [SerializeField] int currentLevelIndex;

    public static PersistentData Instance; 

    // Start is called before the first frame update
    void Start()
    {
       score = 0;
       education_cost = 0;
       loan = 0;
       earnings = 0;
       investments = 0;
       savings = 0;

    }

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }


    public void GoToCuny(){

        education_cost += CUNY_COST;
        isCuny = true;
        isPrivate = false;

    }

    public void GoToPrivate(){
        education_cost += PRIVATE_COST;
        isPrivate = true;
        isCuny = false;
        
    }


    public void GetALoan(){

        if (isCuny && !isPrivate){
            loan = education_cost + CUNY_LOAN_INTEREST;
            education_cost = 0;
        }

        else if (isPrivate && !isCuny){
            loan = education_cost + PRIVATE_LOAN_INTEREST;
            education_cost = 0;
        }


    }

    public void GetAPartTimeJobCollege(){
      earnings =+ 2 * PART_TIME_JOB;
    }

    public void PulicSectorJob(){

        earnings =+ 13 * PUBLIC_SECTOR_JOB; //13 years, from 22-35
        loan = 0; //forgive loan


    }


       public void PrivateSectorJob(){

        earnings =+ 13 * PRIVATE_SECTOR_JOB; //13 years, from 22-35
    

    }

    public void Invest10(){

investments = earnings * 0.1 * 1.12; // ~12% rate 
earnings -= earnings * 0.1;
    }


       public void Invest20(){

investments = earnings * 0.2 * 1.12; // ~12% rate 
earnings -= earnings * 0.2;
    }


    public void Save10(){


savings = earnings * 0.1;
earnings -= earnings *0.1; 
    }

    public void Save20(){

        savings = earnings * 0.2;
earnings -= earnings *0.2; 

    }



    public string Results(){
        return "From 18 to 35 years you:\nHave Earned: "+(earnings-loan-education_cost)+"\nHave in Savings: "+savings+"\nHave in Investments: "+investments;
    }

    // public void SetName(string n)
    // {
    //     playerName = n;
    // }

    // public void SetScore(int s)
    // {
    //     playerScore = s;
    // }

    // public string GetName()
    // {
    //     return playerName;
    // }

    // public int GetScore()
    // {
    //     return playerScore;
    // }

    // public void SetIndex(int i)
    // {
    //     currentLevelIndex = i;
    // }

    // public int GetIndex()
    // {
    //     return currentLevelIndex;
    // }
    // Update is called once per frame
    void Update()
    {
        
    }
}
