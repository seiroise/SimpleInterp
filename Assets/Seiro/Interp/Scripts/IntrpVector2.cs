using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	public class IntrpVector2 : IntrpFrame<Vector2> {
		public IntrpVector2(Vector2 from, Vector2 to, IntrpType type = IntrpType.EaseInOut, Action<Vector2> onUpdate = null, Action<Vector2> onFinish = null) : base(from, to, type, onUpdate, onFinish) {
		}

		protected override void UpdateProc() {
			_value.x = _proc(_from.x, _difference.x, _t);
			_value.y = _proc(_from.y, _difference.y, _t);
		}

		public override IntrpFrame<Vector2> SetFromAndTo(Vector2 from, Vector2 to) {
			_from = from;
			_to = to;
			_difference = _to - _from;

			return this;
		}
	}
}