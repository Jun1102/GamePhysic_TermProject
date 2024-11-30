using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
	public class Create_Box : MonoBehaviour
	{
		public List<GameObject> Boxs;
		public int Boundary = 48;
		public int Box_cnt = 30;
		public int Box_idx = 0;
		public Vector3 position;
		public float checkRadius = 0.5f;
		public LayerMask collisionLayer = ~0;

		// Use this for initialization
		void Start()
		{
			for (int i = 0; i < Box_cnt; i++)
			{
				Box_idx = Random.Range(0, Boxs.Count);
				for (int j = 0; j < 3; j++)
				{
					int x = Random.Range(-Boundary, Boundary);
					int z = Random.Range(-Boundary, Boundary);
					position = new Vector3(x, 2, z);
					if (Physics.CheckSphere(position, checkRadius, collisionLayer))
					{
						continue;
					}
					else
					{
						GameObject box = Instantiate(Boxs[Box_idx], position, Quaternion.identity);
						Rigidbody rb = box.AddComponent<Rigidbody>();
						rb.constraints = RigidbodyConstraints.FreezePositionZ;
						rb.constraints = RigidbodyConstraints.FreezePositionX;
						rb.AddForce(new Vector3(x, 0, z), ForceMode.Impulse);
						box.transform.parent = this.transform;
						break;
					}
				}

			}
		}
	}
}