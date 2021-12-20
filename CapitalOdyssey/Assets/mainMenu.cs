using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        Destroy(PersistentData.Instance);
        SceneManager.LoadScene("q1");
    }

    
    public void ViewResult()
    {
        SceneManager.LoadScene("results");
    }
}
