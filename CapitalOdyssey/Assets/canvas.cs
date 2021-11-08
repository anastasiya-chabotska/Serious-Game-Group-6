using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvas : MonoBehaviour
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
        SceneManager.LoadScene("q2a");
    }

      public void OptionB(){
        Debug.Log("change scene");
        SceneManager.LoadScene("q4b");
    }
}
