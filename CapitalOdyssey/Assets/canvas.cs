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

    	public void OptionC(){
        Debug.Log("change scene");
        SceneManager.LoadScene("q3a");
    }
	public void OptionD(){
        Debug.Log("change scene");
        SceneManager.LoadScene("q4a");
    }

    public void Scene5(){
        SceneManager.LoadScene("q5");
    }

        
    public void Option5A(){
        Debug.Log("change scene");
        SceneManager.LoadScene("q7b");
    }

      public void Option5B(){
        Debug.Log("change scene");
        SceneManager.LoadScene("q6a");
    }
    
    public void Option6A(){
        Debug.Log("change scene");
        SceneManager.LoadScene("q7");
    }

      public void Option6B(){
        Debug.Log("change scene");
        SceneManager.LoadScene("q7");
    }
}
