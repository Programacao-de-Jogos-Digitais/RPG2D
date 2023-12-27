using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaList : MonoBehaviour
{
    public List<int> idade = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        idade.Add(1);
        idade.Add(2);
        idade.Add(3);

        //idade.Remove(1);

        foreach (int item in idade)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
