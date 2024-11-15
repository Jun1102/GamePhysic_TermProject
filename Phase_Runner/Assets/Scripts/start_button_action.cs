using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_button_action : MonoBehaviour
{
   public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
}
