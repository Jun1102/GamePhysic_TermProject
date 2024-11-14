using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts
{
	public class FindHint : MonoBehaviour
	{
		public GameObject directionSenter;
		public GameObject hintDirection;
		private GameObject closestHint;
		public GameObject[] hintPoints;
		public float activeDuration = 3f;
		public float cooldownTime = 5f;
		public float currentCooldown = 0;
		private bool isCoroutineRunning = false;

		// Update is called once per frame
		void Update()
		{
			if (currentCooldown > 0)
			{
				currentCooldown -= Time.deltaTime;
			}

			if (Input.GetKeyDown(KeyCode.Q) && !isCoroutineRunning)
			{
				if (currentCooldown <= 0)
				{
					StartCoroutine(ActivateDirection());
				}
				else
				{
					Debug.Log("Cooldown: " + currentCooldown.ToString("F2"));
				}
			}

			closestHint = FindClosestHint();
			if (closestHint != null)
			{
				directionSenter.transform.LookAt(closestHint.transform);
			}
		}

		IEnumerator ActivateDirection()
		{
			isCoroutineRunning = true;
			hintDirection.SetActive(true);

			yield return new WaitForSeconds(activeDuration);

			hintDirection.SetActive(false);
			isCoroutineRunning = false;
			currentCooldown = cooldownTime;
		}

		public GameObject FindClosestHint()
		{
			GameObject closest = null;
			float closestDistance = Mathf.Infinity; // 초기값을 무한대로 설정

			foreach (GameObject hintPoint in hintPoints)
			{
				if (hintPoint == null) continue; // 타겟이 존재하지 않으면 스킵

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