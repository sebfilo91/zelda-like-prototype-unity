﻿using UnityEngine;
using System.Collections;

namespace AISystem.Actions{
	[HideOwnerDefault]
	[Category("Vector3")]
	[System.Serializable]
	public class Dot : BaseAction {
		[StoreParameter(true,typeof(FloatParameter))]
		public string store;
		public Vector3Parameter second;
		public Vector3Parameter first;
		
		public override void OnEnter ()
		{
			owner.SetFloat (store, Vector3.Dot( owner.GetValue(first),owner.GetValue(second)));
			Finish ();
		}
	}
}