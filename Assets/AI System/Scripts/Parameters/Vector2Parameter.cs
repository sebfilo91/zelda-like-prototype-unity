using UnityEngine;
using System.Collections;

namespace AISystem{
	[System.Serializable]
	public class Vector2Parameter : NamedParameter {
		[SerializeField]
		private Vector2 value;
		
		public Vector2 Value
		{
			get{
				return this.value;
			}
			set{
				this.value = value;
			}
		}
	}
}