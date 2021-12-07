using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script : MonoBehaviour
{

    public Text results;

    // Start is called before the first frame update
    void Start()
    {

        results.text = PersistentData.Instance.Results();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
