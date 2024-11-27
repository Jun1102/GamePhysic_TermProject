using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts
{
	public class FindHint : MonoBehaviour
	{
		private static FindHint instance;
		public static FindHint Instance { get { return instance; } }
		public GameObject compass;
		public GameObject directionSenter;
		public GameObject hintDirection;
		private GameObject closestHint;
		public GameObject[] hintPoints;
		public float activeDuration = 3f;
		public float cooldownTime = 5f;
		public float currentCooldown = 0;
		private bool isCoroutineRunning = false;

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

		// Update is called once per frame
		void Update()
		{
			closestHint = FindClosestHint();
			if (closestHint != null)
			{
				directionSenter.transform.LookAt(closestHint.transform);
			}
		}

		public float GetCompassCol()
		{
			return cooldownTime;
		}

		public void SetCoolTime(bool isRunning)
		{
			isCoroutineRunning = isRunning;
			hintDirection.SetActive(isCoroutineRunning);
		}

		public GameObject FindClosestHint()
		{
			GameObject closest = null;
			float closestDistance = Mathf.Infinity; // 초기값을 무한대로 설정

			foreach (GameObject hintPoint in hintPoints)
			{
				if (hintPoint == null || !hintPoint.activeInHierarchy) continue; // 타겟이 존재하지 않으면 스킵

				float distance = (hintPoint.transform.position - directionSenter.transform.position).sqrMagnitude; // 거리 계산 (squared magnitude 사용)

				if (distance < closestDistance) // 가장 가까운 타겟 찾기
				{
					closestDistance = distance;
					closest = hintPoint;
				}
			}

			return closest;
		}
	}
}