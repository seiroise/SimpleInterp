using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	public abstract class IntrpFrame<T> : IInterpolatable {
		
		protected T _from;
		protected T _to;
		protected T _value;
		protected T _difference;
		protected float _elapsed;
		protected float _delay;
		protected float _t;

		protected bool _isInterpolated;

		public System.Action<T> onUpdate;
		public System.Action<T> onFinish;

		protected System.Func<float, float, float, float> _proc;

		public IntrpFrame(T from, T to, IntrpType type = IntrpType.EaseInOut, System.Action<T> onUpdate = null, System.Action<T> onFinish = null) {
			SetFromAndTo(from, to);
			SetIntrpType(type);
			this.onUpdate = onUpdate;
			this.onFinish = onFinish;
		}

		bool IInterpolatable.Update(float dt) {
			if (_isInterpolated) {
				_elapsed += dt;
				if (_elapsed >= _delay) {
					_t = 1f;
					_value = _to;
					if (onUpdate != null) {
						onUpdate.Invoke(_value);
					}
					if (onFinish != null) {
						onFinish.Invoke(_value);
					}
					_isInterpolated = false;
				} else {
					_t = _elapsed / _delay;
					UpdateProc();
					if (onUpdate != null) {
						onUpdate.Invoke(_value);
					}
				}
			}
			return _isInterpolated;
		}

		bool IInterpolatable.IsNeededUpdate() {
			return _isInterpolated;
		}

		void IInterpolatable.Interpolate() {
			_elapsed = 0f;
			_isInterpolated = true;
		}

		public void Interpolate() {
			((IInterpolatable)this).Interpolate();
		}

		protected abstract void UpdateProc();

		public abstract IntrpFrame<T> SetFromAndTo(T from, T to);

		public IntrpFrame<T> SetIntrpType(IntrpType type) {
			switch (type) {
			default:
			case IntrpType.Liner:
				_proc = Utilities.Liner;
				break;
			case IntrpType.EaseIn:
				_proc = Utilities.EaseIn;
				break;
			case IntrpType.EaseOut:
				_proc = Utilities.EaseOut;
				break;
			case IntrpType.EaseInOut:
				_proc = Utilities.EaseInOut;
				break;
			}
			return this;
		}

		public IntrpFrame<T> SetDelay(float delay) {
			_delay = Mathf.Max(delay, 0f);
			return this;
		}
	}
}