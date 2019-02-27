using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace ColorSwitch.Windows.GameCore.Entities {
	public class Player : Entity {
		public Player() : base("player") { }

		private Texture2D playerTexture;

		public override void onAddedToScene() {
			playerTexture = scene.content.Load<Texture2D>("Player/player_circle");
			addComponent(new Sprite(playerTexture));
			transform.position = new Vector2(scene.sceneRenderTargetSize.X / 2, scene.sceneRenderTargetSize.Y / 2);
		}

		public override void update() {
			base.update();
			if (Input.isKeyPressed(Keys.Up)
			    || Input.leftMouseButtonPressed) {
				// jump
			}
		}
	}
}