using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enable_hint : MonoBehaviour
{
    private bool object_enable = false;
    public hint_object hint;
    public Image content;

    private void Update()
    {
        if (check_Interaction.interact_obj == false)
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(inventory.instance.GetHintContent() != null)
                    EnableHint(inventory.instance.GetHintContent());
            }
                
    }

    public void EnableHint(Sprite image)
    {
        if (object_enable == false)
        {
            Debug.Log(object_enable);
            transform.GetChild(0).gameObject.SetActive(true);
            content = transform.GetChild(0).GetComponent<Image>();
            content.sprite = image;
            object_enable = true;
        }
        else if (object_enable == true)
        {
            Debug.Log(object_enable);
            transform.GetChild(0).gameObject.SetActive(false);
            object_enable = false;
        }
    }
 }
    
            
          

