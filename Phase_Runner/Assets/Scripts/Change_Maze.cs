using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
	public class Change_Maze : MonoBehaviour
	{
		private static Change_Maze instance;
		public static Change_Maze Instance { get { return instance; } }
		public List<GameObject> Mazes;
		public GameObject Maze = null;
		public float ChangeTime = 10f;
		public int MaxChangeCnt = 6;
		public int change_cnt = -1;
		public GameObject Player;
		public GameObject Spawn;
		public CharacterController Controller;
		public Coroutine Change;

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(this);
			}
		}
		// Use this for initialization
		void Start()
		{
			if (Player != null)
			{
				Controller = Player.GetComponent<CharacterController>();
			}
			Change = StartCoroutine(CheckTimeChangeMaze());
		}

		public IEnumerator CheckTimeChangeMaze()
		{
			while (change_cnt < MaxChangeCnt)
			{
                change_cnt++;
				ChangeMaze();
                Timer.Instance.SetTime();
                yield return new WaitForSeconds(ChangeTime);
			}
		}

		public float GetMazeCol()
		{
			return ChangeTime;
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
			if (Player != null)
			{
				Controller.enabled = false; // 비활성화
				Player.transform.position = Spawn.transform.position;
				Controller.enabled = true;  // 다시 활성화
			}
			
        }
	}
}