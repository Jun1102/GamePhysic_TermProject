using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	public class Toach : MonoBehaviour
	{
		public GameObject effect_prefab;
		public GameObject effect_spawn;
		// Use this for initialization
		void Start()
		{
			StartCoroutine(CreateEffect(effect_prefab, effect_spawn));
		}

		// Update is called once per frame
		void Update()
		{

		}

		public IEnumerator CreateEffect(GameObject effect, GameObject spawn)
		{
			while (true)
			{
				yield return new WaitForSeconds(0.25f);

				GameObject particle = Instantiate(effect, spawn.transform.position, spawn.transform.rotation);
				particle.transform.parent = spawn.transform;
			}
		}
	}
}