using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class q7script : MonoBehaviour
{


    GameObject[] button1;
    GameObject[] button2;


    // Start is called before the first frame update
    void Start()
    {
         button1 = GameObject.FindGameObjectsWithTag("a");
         button2 = GameObject.FindGameObjectsWithTag("b");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OptionA(){
        Debug.Log("change scene");
        SceneManager.LoadScene("q7a");
    }

      public void OptionB(){
        Debug.Log("change scene");
        SceneManager.LoadScene("q5");
    }


    public void Invest10(){

        PersistentData.Instance.Invest10();
        SceneManager.LoadScene("q5");

    }

    public void Invest20(){

      PersistentData.Instance.Invest20();
       SceneManager.LoadScene("q5");
    }


    public void Save10(){
        PersistentData.Instance.Save10();
        loadEnd();

    }

    public void Save20(){
        PersistentData.Instance.Save20();
        loadEnd();
    }

      public void loadEnd(){
        SceneManager.LoadScene("results");
    
       
    }
}
