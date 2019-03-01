using System.Collections.Generic;
using ColorSwitch.Windows.GameCore.Entities;
using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Components {
	public class PlayerPhysics : Component {

		private bool impulseHandling;
		private float impulseAccelerator;
		private static float ImpulseSpeed => 10f;

		public PlayerPhysics() : base() { }

		public void ApplyImpulse() {
			if (!enabled) return;
			impulseAccelerator = 0;
			impulseHandling = true;
		}  
	 
		public void Update() {
			if (!enabled) return;
			if (impulseHandling) {
				if (impulseAccelerator < 10f) {
					entity.transform.position -= new Vector2(0, ImpulseSpeed - impulseAccelerator) * Time.deltaTime * 50;
					impulseAccelerator += 1.0f;
				} else {
					impulseHandling = false;
				}
			} else {
				entity.transform.position += new Vector2(0, ImpulseSpeed - impulseAccelerator) * Time.deltaTime * 50;
				if (impulseAccelerator > 0)
					impulseAccelerator -= 0.5f;
			}			
		}

		public void HandleTouchableEntities(List<TouchableEntity> touchableEntities) {
			if (!enabled) return;
			for (int i = 0; i < touchableEntities.Count; i++) {
				if (touchableEntities[i].isDestroyed) {
					touchableEntities.RemoveAt(i); 
					i--;
				}
			}
			foreach (var touchableEntity in touchableEntities) {
				touchableEntity.SendState(entity);
			}
		}
	}
}