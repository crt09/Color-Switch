using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace ColorSwitch.Windows.GameCore.Entities {
	public class Star : TouchableEntity {

		private Texture2D starTexture;
		private Sprite starSprite;

		public Star() : base("star") { }

		public override void onAddedToScene() {
			starTexture = scene.content.Load<Texture2D>("ColorEntities/star");
			starSprite = new Sprite(starTexture);
			addComponent(starSprite);

			var collider = new CircleCollider(starTexture.Height / 2);
			addComponent(collider);

			transform.position = new Vector2(400, 300);
		}

		public override void SendState(Entity sender) {
			if (sender is Player player) {
				var switcherCollider = getComponent<Collider>();
				var playerCollider = player.getComponent<Collider>();
				if (switcherCollider.collidesWith(playerCollider, out CollisionResult result)) {
					// TODO: score logic
					destroy();
				}
			}
		}
	}
}