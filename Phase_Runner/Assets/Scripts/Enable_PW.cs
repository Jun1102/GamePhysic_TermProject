using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_PW : MonoBehaviour
{
    public GameObject pwObject;

    private void Update()
    {
        if (enable_hint.object_enable == false)
            if (Input.GetKeyDown(KeyCode.E))
            {
                pwObject.transform.GetChild(1).gameObject.SetActive(true);
            }
    }
}
