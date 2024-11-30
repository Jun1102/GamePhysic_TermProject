using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_object : MonoBehaviour
{

	public hint_data hint;
	public GameObject maze;

    private void Start()
    {
		maze = GameObject.Find("Plane");
    }

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
		Change_Hint.Instance.FindedHint();
		Change_Maze.Instance.ChangeMaze();
        maze.GetComponent<Change_Maze>().StopCoroutine(Change_Maze.Instance.Change);
		Change_Maze.Instance.Change = maze.GetComponent<Change_Maze>().StartCoroutine(Change_Maze.Instance.CheckTimeChangeMaze());
		Destroy(transform.parent.gameObject);
	}
}


