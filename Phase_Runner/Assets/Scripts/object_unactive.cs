using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_unactive : MonoBehaviour
{
    public void UnActive()
    {
        this.gameObject.SetActive(false); 
    }
}
