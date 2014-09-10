using UnityEngine;
using System.Collections;

namespace AISystem.Actions.Rigidbody2D{
	[Category("Rigidbody2D")]
	[System.Serializable]
	public class AddForce : BaseAction {
		public Vector2Parameter force;

		private UnityEngine.Rigidbody2D rigidbody;

		public override void OnEnter ()
		{
			rigidbody = ownerDefault.GetComponent<UnityEngine.Rigidbody2D> ();
		}

		public override void OnFixedUpdate()
		{
			if (rigidbody != null) {
				rigidbody.AddForce (owner.GetValue(force));
			}
			Finish ();
		}
	}
}