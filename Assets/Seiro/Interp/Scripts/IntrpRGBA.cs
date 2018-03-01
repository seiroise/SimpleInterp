using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	public class IntrpRGBA : IntrpFrame<Color> {
		public IntrpRGBA(Color from, Color to, IntrpType type = IntrpType.EaseInOut, Action<Color> onUpdate = null, Action<Color> onFinish = null) : base(from, to, type, onUpdate, onFinish) {
		}

		public override IntrpFrame<Color> SetFromAndTo(Color from, Color to) {
			_from = from;
			_to = to;
			_difference = _to - _from;

			return this;
		}

		protected override void UpdateProc() {
			_value.r = _proc(_from.r, _difference.r, _t);
			_value.g = _proc(_from.g, _difference.g, _t);
			_value.b = _proc(_from.b, _difference.b, _t);
			_value.a = _proc(_from.a, _difference.a, _t);
		}
	}
}