using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class check_Interaction : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private GameObject interaction_object = null;
    public float maxDistance = 2.0f;
    private int layer_mask;
    public static bool interact_obj;
    void Start()
    {
        layer_mask = 1 << 7;
        interact_obj = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit, maxDistance, layer_mask))
        {
            UnityEngine.Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);
            interaction_object = hit.collider.gameObject;
            hit.collider.transform.GetChild(0).gameObject.SetActive(true);
            interact_obj=true;
        }
        if (Physics.Raycast(ray, out hit, maxDistance, layer_mask) == false)
        {
            interact_obj = false;
            if (interaction_object != null)
                interaction_object.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            UnityEngine.Debug.Log(interact_obj);
        }
    }

    
}
