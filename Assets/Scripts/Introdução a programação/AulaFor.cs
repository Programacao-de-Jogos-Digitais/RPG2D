using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaFor : MonoBehaviour
{
    public int[] arrayInt = {1,2,3,4,5};

    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < 3; i++)
        // {
        //     Debug.Log("Leu o for, i = " + i);
        // } 

        foreach (int valor in arrayInt)
        {
            Debug.Log(valor);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
