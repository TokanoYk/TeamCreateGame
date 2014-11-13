using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Novel
{
	public class GoComponent : AbstractComponent 
	{
		public GoComponent()
		{
			//必須項目
			this.arrayVitalParam = new List<string> {
				"name"
			};
			
			this.originalParam = new Dictionary<string, string>() {
				{"name",""},
			};
		}
		public override void start ()
		{
			string scene_name = this.param ["name"];
			Application.LoadLevel (scene_name);
			//FadeManager.Instance.LoadLevel(scene_name,1.0f);
		}
	}
}