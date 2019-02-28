using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace ColorSwitch.Windows.GameCore.Entities {
	public class Player : Entity {
		public Player() : base("player") { }

		public Color color {
			get => playerSprite.color;
			set => playerSprite.color = value;
        }

		private Sprite playerSprite;
		private Texture2D playerTexture;
		private Physics physicsHandler;

		private bool gameStarted = false;

		public override void onAddedToScene() {
			physicsHandler = new Physics(this);			

			playerTexture = scene.content.Load<Texture2D>("Player/player_circle");
			playerSprite = new Sprite(playerTexture);

            addComponent(playerSprite);
			transform.position = new Vector2(scene.sceneRenderTargetSize.X / 2, scene.sceneRenderTargetSize.Y / 2);	
		}

		public override void update() {
			base.update();

			if(gameStarted)
				physicsHandler.Update();

			if (Input.isKeyPressed(Keys.Up) || Input.leftMouseButtonPressed) {
				gameStarted = true;
				physicsHandler.ApplyImpulse();
			}
		}
    }
}