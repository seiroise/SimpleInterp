using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	public class Demo : MonoBehaviour {

		public float delay = 4f;

		public float minX = -5f;
		public float maxX = 5f;
		public Transform f1, f2, f3, f4;

		public float minAngle = 135f;
		public float maxAngle = -45f;

		public Transform a1, a2, a3, a4;

		public Color fromColor;
		public Color toColor;

		public SpriteRenderer s;

		IntrpFloat _if1, _if2, _if3, _if4;
		IntrpAngle _ia1, _ia2, _ia3, _ia4;

		IntrpRGBA _rgba;

		void Awake() {
			var manager = IntrpManager.instance;
			_if1 = manager.Attach(new IntrpFloat(-5f, 5f, IntrpType.Liner, OnIF1Update));
			_if2 = manager.Attach(new IntrpFloat(-5f, 5f, IntrpType.EaseIn, OnIF2Update));
			_if3 = manager.Attach(new IntrpFloat(-5f, 5f, IntrpType.EaseOut, OnIF3Update));
			_if4 = manager.Attach(new IntrpFloat(-5f, 5f, IntrpType.EaseInOut, OnIF4Update));

			_ia1 = manager.Attach(new IntrpAngle(135f, -45f, IntrpType.Liner, OnIA1Update));
			_ia2 = manager.Attach(new IntrpAngle(135f, -45f, IntrpType.EaseIn, OnIA2Update));
			_ia3 = manager.Attach(new IntrpAngle(135f, -45f, IntrpType.EaseOut, OnIA3Update));
			_ia4 = manager.Attach(new IntrpAngle(135f, -45f, IntrpType.EaseInOut, OnIA4Update));

			_rgba = manager.Attach(new IntrpRGBA(fromColor, toColor, IntrpType.EaseInOut, OnRGBAUpdate));
		}

		void UpdatePosition(Transform t, float value) {
			if (t) {
				var p = t.position;
				p.x = value;
				t.position = p;
			}
		}

		void UpdateAngulerPosition(Transform t, float angle) {
			t.position = Quaternion.AngleAxis(angle, Vector3.forward) * new Vector3(5f, 0f, 0f);
		}

		public void OnIF1Update(float v) {
			UpdatePosition(f1, v);
		}

		public void OnIF2Update(float v) {
			UpdatePosition(f2, v);
		}

		public void OnIF3Update(float v) {
			UpdatePosition(f3, v);
		}

		public void OnIF4Update(float v) {
			UpdatePosition(f4, v);
		}

		public void OnIA1Update(float v) {
			if (a1) {
				UpdateAngulerPosition(a1, v);
			}
		}

		public void OnIA2Update(float v) {
			if (a2) {
				UpdateAngulerPosition(a2, v);
			}
		}

		public void OnIA3Update(float v) {
			if (a3) {
				UpdateAngulerPosition(a3, v);
			}
		}

		public void OnIA4Update(float v) {
			if (a4) {
				UpdateAngulerPosition(a4, v);
			}
		}

		public void OnRGBAUpdate(Color v) {
			if (s) {
				s.color = v;
			}
		}

		public void OnLerpClicked() {
			// position
			_if1.SetFromAndTo(minX, maxX).SetDelay(delay).Interpolate();
			_if2.SetFromAndTo(minX, maxX).SetDelay(delay).Interpolate();
			_if3.SetFromAndTo(minX, maxX).SetDelay(delay).Interpolate();
			_if4.SetFromAndTo(minX, maxX).SetDelay(delay).Interpolate();

			// anguler position
			_ia1.SetFromAndTo(minAngle, maxAngle).SetDelay(delay).Interpolate();
			_ia2.SetFromAndTo(minAngle, maxAngle).SetDelay(delay).Interpolate();
			_ia3.SetFromAndTo(minAngle, maxAngle).SetDelay(delay).Interpolate();
			_ia4.SetFromAndTo(minAngle, maxAngle).SetDelay(delay).Interpolate();

			// Color
			_rgba.SetFromAndTo(fromColor, toColor).SetDelay(delay).Interpolate();
		}
	}
}