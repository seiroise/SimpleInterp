using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	public class IntrpGroup : IInterpolatable {

		public System.Action onFinish;

		IInterpolatable[] _intrps;
		bool _isInterpolated;

		public IntrpGroup(System.Action onFinish, params IInterpolatable[] intrps) {
			this.onFinish = onFinish;
			_intrps = intrps;
			_isInterpolated = false;
		}

		bool IInterpolatable.IsNeededUpdate() {
			return _isInterpolated;
		}

		bool IInterpolatable.Update(float dt) {
			if (_isInterpolated) {
				bool flag = false;
				for (var i = 0; i < _intrps.Length; ++i) {
					flag |= _intrps[i].Update(dt);
				}
				if (!flag) {
					
					_isInterpolated = false;
				}
			}
			return _isInterpolated;
		}

		void IInterpolatable.Interpolate() {
			for (var i = 0; i < _intrps.Length; ++i) {
				_intrps[i].Interpolate();
			}
			_isInterpolated = true;
		}
	}
}