using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	[System.Serializable]
	public class IntrpFloat : IntrpFrame<float> {

		public IntrpFloat (
			float from, float to, IntrpType type = IntrpType.EaseInOut,
			System.Action<float> onUpdate = null, System.Action<float> onFinish = null
		) :base(from, to, type, onUpdate, onFinish){ }

		protected override void UpdateProc() {
			_value = _proc(_from, _difference, _t);
		}

		public override IntrpFrame<float> SetFromAndTo(float from, float to) {
			_from = from;
			_to = to;
			_difference = _to - _from;

			return this;
		}
	}
}