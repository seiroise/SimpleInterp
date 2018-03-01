using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	[System.Serializable]
	public class IntrpAngle : IntrpFrame<float> {

		public IntrpAngle(
			float from, float to, IntrpType type = IntrpType.EaseInOut,
			System.Action<float> onUpdate = null, System.Action<float> onFinish = null
		) :base(from, to, type, onUpdate, onFinish){ }

		protected override void UpdateProc() {
			_value = _proc(_from, _difference, _t);
		}

		public override IntrpFrame<float> SetFromAndTo(float from, float to) {
			_from = Utilities.AdjustAngle(from);
			_to = Utilities.AdjustAngle(to);
			_difference = Utilities.CalcAngleDifference(_from, _to);
			return this;
		}
	}
}