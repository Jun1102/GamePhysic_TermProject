using Assets.Scripts;
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
		Change_Hint.Instance.FindedHint();
		Change_Maze.Instance.ChangeMaze();
		Destroy(transform.parent.gameObject);
	}
}


