using System.Collections.Generic;
using ColorSwitch.Windows.GameCore.Entities;
using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Components {
	public class PlayerPhysics : Component {

		private bool impulseHandling;
		private float impulseAccelerator;
		private const float IMPULSE_SPEED = 11f;

		public PlayerPhysics() : base() { }

		public void ApplyImpulse() {
			if (!enabled) return;
			impulseAccelerator = 0;
			impulseHandling = true;
		}  
	 
		public void Update() {
			if (!enabled) return;

			var impulseMovement = new Vector2(0, IMPULSE_SPEED - impulseAccelerator) * Time.deltaTime * 45;
			var impulseAcceleratorStep = 1.0f * Time.deltaTime * 60;

			if (impulseHandling) {
				if (impulseAccelerator < IMPULSE_SPEED) {
					entity.position -= impulseMovement;
					impulseAccelerator += impulseAcceleratorStep;
				} else {
					impulseHandling = false;
				}
			} else {
				entity.position += impulseMovement;
				if (impulseAccelerator > 0)
					impulseAccelerator -= impulseAcceleratorStep;
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
				if(touchableEntity.getComponent<Collider>() != null)
					touchableEntity.SendState(entity);
			}
		}
	}
}