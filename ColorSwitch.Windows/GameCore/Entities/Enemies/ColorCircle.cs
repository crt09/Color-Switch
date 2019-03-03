using ColorSwitch.Windows.GameCore.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace ColorSwitch.Windows.GameCore.Entities.Enemies {
	public class ColorCircle : TouchableEntity {

		private Texture2D circleTexture;
		private Sprite circleSprite;
		private float rotationSpeed = 1.5f;

		public override Vector2 realSize => circleTexture.Bounds.Size.ToVector2();

		public ColorCircle() : base("color-circle") { }

		public override void onAddedToScene() {
			circleTexture = scene.content.Load<Texture2D>("ColorEntities/color_circle");
			circleSprite = new Sprite(circleTexture);
			addComponent(circleSprite);	

			var physics = new ColorCirclePhysics();
			addComponent(physics);

			if (Random.nextInt(2) == 0)
				rotationSpeed = -rotationSpeed;
		}

		public override void update() {
			base.update();			
			transform.rotation += rotationSpeed * Time.deltaTime;
		}

		public override void SendState(Entity sender) {
			if (sender is Player player) {
				var playerCollider = player.getComponent<Collider>();

				foreach (var info in getComponent<ColorCirclePhysics>().colorInfo) {
					if (playerCollider.collidesWith(info.collider, out CollisionResult result)
					    && player.color != info.color) {
						player.kill();
					}
				}				
			}
		}		
	}
}