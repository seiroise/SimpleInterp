using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	public class IntrpAngleVector3 : IntrpFrame<Vector3> {
		public IntrpAngleVector3(Vector3 from, Vector3 to, IntrpType type = IntrpType.EaseInOut, Action<Vector3> onUpdate = null, Action<Vector3> onFinish = null) : base(from, to, type, onUpdate, onFinish) {
		}

		public override IntrpFrame<Vector3> SetFromAndTo(Vector3 from, Vector3 to) {
			_from.x = Utilities.AdjustAngle(from.x);
			_from.y = Utilities.AdjustAngle(from.y);
			_from.z = Utilities.AdjustAngle(from.z);

			_to.x = Utilities.AdjustAngle(to.x);
			_to.y = Utilities.AdjustAngle(to.y);
			_to.z = Utilities.AdjustAngle(to.z);

			_difference.x = Utilities.CalcAngleDifference(_from.x, _to.x);
			_difference.y = Utilities.CalcAngleDifference(_from.y, _to.y);
			_difference.z = Utilities.CalcAngleDifference(_from.z, _to.z);

			return this;
		}

		protected override void UpdateProc() {
			_value.x = _proc(_from.x, _difference.x, _t);
			_value.y = _proc(_from.y, _difference.y, _t);
			_value.z = _proc(_from.z, _difference.z, _t);
		}
	}
}