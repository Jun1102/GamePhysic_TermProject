using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class ChangeHold : MonoBehaviour
	{
		public Dictionary<string, Material> materials = new Dictionary<string, Material>(4);
		public List<string> namesList;
		public List<Material> materialsList;
		public GameObject compass;
		public GameObject scroll;
		public string post;
		// Use this for initialization
		void Start()
		{
			for (int i = 0; i < materialsList.Count; i++)
			{
				materials.Add(namesList[i], materialsList[i]);
			}
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void LoadHoldObject()
		{
			string object_name = inventory.instance.GetHintName();
			if (post != object_name)
			{
				if (object_name != null)
				{
					compass.SetActive(false);
					scroll.GetComponent<Renderer>().material = materials[object_name];
					scroll.SetActive(true);
				}
				else
				{
					scroll.SetActive(false);
					compass.SetActive(true);
				}
				post = object_name;
			}
		}
	}
}