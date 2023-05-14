using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool outOfBounds = false;

    void Start()
    {
        if (outOfBounds == true)
        {
            Time.timeScale = 0f;
            outOfBounds = true;
        }
        else
        {
            Time.timeScale = 1f;
            outOfBounds = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
