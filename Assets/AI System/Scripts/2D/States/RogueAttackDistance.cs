using UnityEngine;
using System.Collections;

namespace AISystem.States.Sprites{
	[CanCreate(true)]
	[System.Serializable]
	public class RogueAttackDistance : RogueMovement {
		[StoreParameter(true,typeof(GameObjectParameter))]
		public string target;
		[StoreParameter(true,typeof(GameObjectParameter))]
		public string projectile;
		[StoreParameter(true,typeof(Vector3Parameter))]
		public string enemyPosition;
		
		protected GameObject mTarget;
		protected GameObject mProjectile;
		protected Vector3 mPosition;

		public override void OnEnter ()
		{
			mTarget = owner.GetGameObject (target);
			mProjectile = owner.GetGameObject (projectile);
			mPosition = owner.GetVector3 (enemyPosition);
		}

		// Use this for initialization
		public override void OnAwake () {
			
		}
		
		// Update is called once per frame
		public override void OnFixedUpdate () {

		}

		public override void OnExit () {

		}
			
		
	}
}
