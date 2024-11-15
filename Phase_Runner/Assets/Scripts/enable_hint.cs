using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable_hint : MonoBehaviour
{
    private bool object_enable = false;
    public GameObject hint_parents;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (object_enable == false)
            {
                Debug.Log(object_enable);
                hint_parents.transform.GetChild(0).gameObject.SetActive(true);
                object_enable = true;
            }
            else if(object_enable == true)
            {
                Debug.Log(object_enable);
                hint_parents.transform.GetChild(0).gameObject.SetActive(false);
                object_enable = false;
            }
        }
    }
}
