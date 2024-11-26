using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class Change_Maze : MonoBehaviour
	{
		public List<GameObject> Mazes;

		public GameObject Maze = null;
		public float ChangeTime = 10f;
		public int MaxChangeCnt = 5;
		// Use this for initialization
		void Start()
		{
			StartCoroutine(CheckTimeChangeMaze());
		}

		public IEnumerator CheckTimeChangeMaze()
		{
			int change_cnt = -1;
			while (change_cnt < MaxChangeCnt)
			{
				change_cnt++;
				ChangeMaze();
				yield return new WaitForSeconds(ChangeTime);
			}
		}

		public void ChangeMaze()
		{
			int idx = Random.Range(0, Mazes.Count);
			if (Maze != null)
			{
				Destroy(Change_Hint.Instance.hint);
				Maze?.SetActive(false);
			}
			Maze = Mazes[idx];
			Maze.SetActive(true);
			Change_Hint.Instance.ChangeHint(Maze.transform.GetChild(1).gameObject);
		}
	}
}