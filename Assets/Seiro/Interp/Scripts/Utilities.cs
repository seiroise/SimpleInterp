using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seiro.Interp {

	[System.Serializable]
	public enum IntrpType {
		Liner,
		EaseIn,
		EaseOut,
		EaseInOut
	}

	public class Utilities {

		public static float CalcAngleDifference(float from, float to) {
			var difference = to - from;
			if (difference > 180f) {
				from += 360f;
				difference = to - from;
			} else if (difference < -180f) {
				to += 360f;
				difference = to - from;
			}
			return difference;
		}

		public static float AdjustAngle(float angle) {
			if (angle <= 0f) {
				angle = 360f - (-angle % 360f);
			}
			return angle % 360f;
		}

		public static float Liner(float b, float d, float t) {
			return b + d * t;
		}

		public static float EaseIn(float b, float d, float t) {
			return b + d * t * t;
		}

		public static float EaseOut(float b, float d, float t) {
			return b + d * t * (2 - t);
		}

		public static float EaseInOut(float b, float d, float t) {
			return b + d * (t * t) * (3 - 2 * t);
		}
	}
}