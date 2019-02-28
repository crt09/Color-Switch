using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Entities {
	public class Physics {

		public Physics(Entity entity) {
			this.entity = entity;
		}

		public void ApplyImpulse() {
			impulseAccelerator = 0;
			impulseHandling = true;
		}
        
        private Entity entity;
        private bool impulseHandling;
		private float impulseAccelerator;

		private static float ImpulseSpeed => 10f;

		public void Update() {
			if (impulseHandling) {
				if (impulseAccelerator < 10f) {
					entity.transform.position -= new Vector2(0, ImpulseSpeed - impulseAccelerator);
					impulseAccelerator += 1.0f;
				} else {
					impulseHandling = false;
				}
			}
			else {
				entity.transform.position += new Vector2(0, ImpulseSpeed - impulseAccelerator);
                if (impulseAccelerator > 0)
					impulseAccelerator -= 0.5f;
			}
		}
	}
}