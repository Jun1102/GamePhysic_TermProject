using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class Change_Hint : MonoBehaviour
	{
		private static Change_Hint instance;
		public static Change_Hint Instance { get { return instance; } }
		public List<GameObject> Hints;
		public List<bool> FindHints;
		public int findHintCnt = 0;
		public int idx = 0;
		public GameObject hint;


		private void Awake()
		{
			// 이미 인스턴스가 존재하면 현재 오브젝트를 파괴
			if (instance != null && instance != this)
			{
				Destroy(gameObject);
				return;
			}

			// 싱글톤 인스턴스 설정
			instance = this;
		}

		public void ChangeHint(GameObject spawn)
		{
			while (findHintCnt < Hints.Count)
			{
				idx = Random.Range(0, Hints.Count);
				if (!FindHints[idx])
				{
					hint = Instantiate(Hints[idx], spawn.transform.position, Quaternion.identity);
					hint.transform.parent = spawn.transform;
					break;
				}
			}
		}

		public void FindedHint()
		{
			FindHints[idx] = true;
			findHintCnt++;
			Debug.Log("FindHints: " + idx);
		}
	}
}