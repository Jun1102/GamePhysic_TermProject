using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_object : MonoBehaviour
{
    
    public hint_data hint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }

    }
    public void OnInteract()
    {
        inventory.instance.AddItem(hint);
        Destroy(transform.parent.gameObject);
    }
}


