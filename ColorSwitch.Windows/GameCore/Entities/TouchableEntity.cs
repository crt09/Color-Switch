using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace ColorSwitch.Windows.GameCore.Entities {
	public abstract class TouchableEntity : Entity {

		public abstract Vector2 realSize { get; }

		public TouchableEntity(string name) : base(name) { }

		public abstract void SendState(Entity sender);

		public override void update() {
			base.update();
			if (transform.position.Y - (getComponent<Sprite>().height * 0.5f) > scene.camera.bounds.height) {
				destroy();
			}
		}
	}
}