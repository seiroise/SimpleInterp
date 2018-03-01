using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	public class IntrpVector3 : IntrpFrame<Vector3> {
		public IntrpVector3(Vector3 from, Vector3 to, IntrpType type = IntrpType.EaseInOut, Action<Vector3> onUpdate = null, Action<Vector3> onFinish = null) : base(from, to, type, onUpdate, onFinish) {
		}

		public override IntrpFrame<Vector3> SetFromAndTo(Vector3 from, Vector3 to) {
			_from = from;
			_to = to;
			_difference = _to - _from;

			return this;
		}

		protected override void UpdateProc() {
			_value.x = _proc(_from.x, _difference.x, _t);
			_value.y = _proc(_from.y, _difference.y, _t);
			_value.z = _proc(_from.z, _difference.z, _t);
		}
	}
}