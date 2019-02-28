using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace ColorSwitch.Windows.GameCore.Entities {
	public class ColorSwitcher : ColorEntity {

		private Texture2D switcherTexture;
		private Sprite switcherSprite;

		public ColorSwitcher() : base("color-switcher") { }

		public override void onAddedToScene() {
			switcherTexture = scene.content.Load<Texture2D>("ColorEntities/color_switcher");
			switcherSprite = new Sprite(switcherTexture);
			addComponent(switcherSprite);

			var collider = new CircleCollider(switcherTexture.Height / 2);
            addComponent(collider);

			transform.position = new Vector2(400, 100);
		}

		public override void OnTouch(Entity sender) {
			if (sender is Player player) {
				var switcherCollider = getComponent<Collider>();
				var playerCollider = player.getComponent<Collider>();
				if (switcherCollider.collidesWith(playerCollider, out CollisionResult result)) {
					// TODO: switching logic
					player.color = Color.Red;
					destroy();
				}
			}
		}
	}
}