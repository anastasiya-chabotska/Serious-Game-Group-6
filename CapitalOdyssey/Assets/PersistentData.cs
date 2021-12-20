using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] double loan;
    [SerializeField] double education_cost;
    public bool isCuny = false;
    public bool isPrivate = false;
    [SerializeField] double earnings;
    [SerializeField] double investments;
    [SerializeField] double savings;
    [SerializeField] double invest_percent;
    [SerializeField] double savings_percent;
    [SerializeField] bool isLoan;
    [SerializeField] bool loanForgiven;
    [SerializeField] double taxes;

    public const int CUNY_COST = 6930*2;
    public const int PRIVATE_COST = 13475*2;
    public const int CUNY_LOAN_INTEREST = (int)(CUNY_COST*0.0466);
    public const int PRIVATE_LOAN_INTEREST = (int)(PRIVATE_COST*0.0466);
    public const int PART_TIME_JOB = 15*20*52; //per year
    //public const int FULL_TIME_JOB = 15*40*52; //per year
    public const int PUBLIC_SECTOR_JOB = 92068; //per year
    public const int PRIVATE_SECTOR_JOB = 76988; //per year
    public const int AVERAGE_SALARY = 36864; //per year
    public const int BILLS = (94 + 46 + 36 + 39 + 240 + 1621)*12; //per year

    public bool invest = false;
    public bool save = false;


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
       invest_percent = 0;
       savings_percent = 0;
       isLoan = false;
       loanForgiven = false;

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("NEW INSTANCE");
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

        isLoan = true;

        if (isCuny && !isPrivate){
            loan = education_cost + CUNY_LOAN_INTEREST;
            // education_cost = 0;
        }

        else if (isPrivate && !isCuny){
            loan = education_cost + PRIVATE_LOAN_INTEREST;
            // education_cost = 0;
        }


    }

    public void GetAPartTimeJobCollege(){
      earnings =+ 2 * PART_TIME_JOB;
      taxes =+ 2 * CalculateTax(PART_TIME_JOB);
    }


    public void PartTimeJob(){
        earnings =+ 17 * AVERAGE_SALARY/2;
        taxes =+ 17 * CalculateTax(AVERAGE_SALARY/2);
    }


    public void FullTimeJob(){
        earnings =+ 17 * AVERAGE_SALARY;
          taxes =+ 17 * CalculateTax(AVERAGE_SALARY);
    }

    public void PulicSectorJob(){

        earnings =+ 13 * PUBLIC_SECTOR_JOB; //13 years, from 22-35
          taxes =+ 13 * CalculateTax(PUBLIC_SECTOR_JOB);
        loan = 0; //forgive loan
        loanForgiven = true;
        // earnings -= education_cost;


    }


       public void PrivateSectorJob(){

        earnings =+ 13 * PRIVATE_SECTOR_JOB; //13 years, from 22-35
          taxes =+ 13 * CalculateTax(PRIVATE_SECTOR_JOB);
        // earnings -= education_cost;
        // earnings -= loan;
    

    }

    public void Invest10(){

investments = (earnings - taxes - BILLS) * 0.1 * 1.10; // ~10% rate 
invest_percent = 0.1;

    }


       public void Invest20(){

investments = (earnings -taxes - BILLS) * 0.2 * 1.10; // ~10% rate 
invest_percent = 0.2;

    }


    public void Save10(){


savings = (earnings -taxes - BILLS)  * 0.1 * 1.0006;

savings_percent = 0.1;
    }

    public void Save20(){

        savings = (earnings -taxes - BILLS) * 0.2 * 1.0006;

savings_percent = 0.2;

    }

    public double CalculateTax(int amount){
        if (amount <=9950){
            return amount * 0.1; //10%
        }
        else if (amount <=40525){
            return amount*0.12 + 995;
        }
        else if (amount <=86375){
            return 4664 + amount * 0.22;
        }
        else if (amount<=164925){
            return 14751 + amount * 0.24;
        }
        else return 0;
    }



    public string Results(){


        if (earnings == 0){
            string result = "Play the Game First To See the Results!";
            return result;
        }
        else {
        string result = "From the age of 18 to 35: ";
        if (isCuny){
            result += "\nYou chose to go to CUNY College which costed $"+education_cost;

        }
        if (isPrivate){
            result += "\nYou chose to go to a Private College which costed $"+education_cost;
        }

        if (isLoan){
            result += "\nYou also decided to take a loan which resulted in following interest added to your education cost: $";
            if (isCuny){
                result += CUNY_LOAN_INTEREST;
            }
            else if(isPrivate){
                result += PRIVATE_LOAN_INTEREST;
            }

            if (loanForgiven){
                result += "\nBy choosing to work in a public sector, your loan was forgiven";
            }


            // if (isLoan==false && (isCuny || isPrivate)){

            // }
        }

        result+="\nOver the years, you earned a gross total of $"+earnings;
        result+="\nYou paid $"+taxes+" in taxes";
        result+="\n$"+BILLS*13+" went to pay bills";
        result += "\nFrom that amount, you invested  "+(invest_percent*100)+"%, and now your investments total in $"+investments;
        result += "\nAlso, you chose to save "+(savings_percent*100)+"%, and now you have $"+savings+" in savings.";


        //Destroy(gameObject);

        return result;
        }

   


       
        // return "From 18 to 35 years you:\nEarned: "+(earnings)+"\nHave in Savings: "+savings+"\nHave in Investments: "+investments;
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
