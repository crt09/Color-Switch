using ColorSwitch.Windows.GameCore.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace ColorSwitch.Windows.GameCore.Entities.Special {
	public class ColorSwitcher : TouchableEntity {

		private Texture2D switcherTexture;
		private Sprite switcherSprite;

		public override Vector2 realSize => switcherTexture.Bounds.Size.ToVector2();

		public ColorSwitcher() : base("color-switcher") { }

		public override void onAddedToScene() {
			switcherTexture = scene.content.Load<Texture2D>("ColorEntities/color_switcher");
			switcherSprite = new Sprite(switcherTexture);
			addComponent(switcherSprite);

			var collider = new CircleCollider(switcherTexture.Height / 2);
			addComponent(collider);
		}

		public override void SendState(Entity sender) {
			if (sender is Player player) {
				var switcherCollider = getComponent<Collider>();
				var playerCollider = player.getComponent<Collider>();
				if (switcherCollider.collidesWith(playerCollider, out CollisionResult result)) {
					Color newColor;
					do {
						newColor = getRandomColor;
					} while (newColor == player.color);
					player.color = newColor;
					destroy();
				}
			}
		}

		private Color getRandomColor => 
			GameColor.GetColorById((uint)Random.nextInt(4));
	}
}