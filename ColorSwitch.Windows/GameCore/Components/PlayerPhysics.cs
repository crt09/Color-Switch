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
			impulseAccelerator = 0;
			impulseHandling = true;
		}  
	 
		public void Update() {
			if (impulseHandling) {
				if (impulseAccelerator < 10f) {
					entity.transform.position -= new Vector2(0, ImpulseSpeed - impulseAccelerator);
					impulseAccelerator += 1.0f;
				} else {
					impulseHandling = false;
				}
			} else {
				entity.transform.position += new Vector2(0, ImpulseSpeed - impulseAccelerator);
				if (impulseAccelerator > 0)
					impulseAccelerator -= 0.5f;
			}			
		}

		public void HandleTouchableEntities(List<TouchableEntity> colorEntities) {
			for (int i = 0; i < colorEntities.Count; i++) {
				if (colorEntities[i].isDestroyed) {
					colorEntities.RemoveAt(i); 
					i--;
				}
			}
			foreach (var colorEntity in colorEntities) {
				colorEntity.SendState(entity);
			}
		}
	}
}