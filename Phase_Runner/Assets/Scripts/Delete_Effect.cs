using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	public class Delete_Effect : MonoBehaviour
	{
		public float survive_time = 0f;

		public void Update()
		{
			survive_time += Time.deltaTime;
			if (survive_time > 1f)
			{
				Destroy(gameObject);
			}
		}
	}
}