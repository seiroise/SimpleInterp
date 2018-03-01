using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	public class IntrpManager : MonoBehaviour {

		static IntrpManager _instance;

		static public IntrpManager instance {
			get {
				if (!_instance) {
					_instance = GameObject.FindObjectOfType<IntrpManager>();
					if (!_instance) {
						var gObj = new GameObject("IntrpManager");
						_instance = gObj.AddComponent<IntrpManager>();
					}
				}
				return _instance;
			}
		}

		List<IInterpolatable> _items;

		void Awake() {
			if (!instance.Equals(this)) {
				Destroy(this);
			} else {
				_items = new List<IInterpolatable>();
			}
		}

		void Update() {
			if (_items.Count > 0) {
				var dt = Time.deltaTime;
				for (int i = 0; i < _items.Count; ++i) {
					_items[i].Update(dt);
				}
			}
		}

		public IInterpolatable Attach(IInterpolatable item) {
			_items.Add(item);
			return item;
		}

		public IntrpFloat Attach(IntrpFloat item) {
			_items.Add(item);
			return item;
		}

		public IntrpAngle Attach(IntrpAngle item) {
			_items.Add(item);
			return item;
		}

		public IntrpVector2 Attach(IntrpVector2 item) {
			_items.Add(item);
			return item;
		}

		public IntrpVector3 Attach(IntrpVector3 item) {
			_items.Add(item);
			return item;
		}

		public IntrpAngleVector3 Attach(IntrpAngleVector3 item) {
			_items.Add(item);
			return item;
		}

		public IntrpRGBA Attach(IntrpRGBA item) {
			_items.Add(item);
			return item;
		}

		public void Detach(IInterpolatable item) {
			_items.Remove(item);
		}

		public void DetachAll() {
			_items.RemoveRange(0, _items.Count);
		}
	}
}