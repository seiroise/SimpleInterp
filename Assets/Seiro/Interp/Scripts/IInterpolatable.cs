using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	public interface IInterpolatable {

		bool Update(float dt);

		bool IsNeededUpdate();

		void Interpolate();
	}
}