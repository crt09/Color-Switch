using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

using ColorSwitch.Windows.GameCore.Components;

namespace ColorSwitch.Windows.GameCore.Entities {
	public class Player : Entity {
		public Color color {
			get => playerSprite.color;
			set => playerSprite.color = value;
        }

		private bool gameStarted = false;

		private Sprite playerSprite;
		private Texture2D playerTexture;
		private List<ColorEntity> colorEntities;

		public Player() : base("player") { }

        public override void onAddedToScene() {		
			playerTexture = scene.content.Load<Texture2D>("Player/player_circle");
			playerSprite = new Sprite(playerTexture);
			colorEntities = new List<ColorEntity>();
            
			transform.position = new Vector2(scene.sceneRenderTargetSize.X / 2, scene.sceneRenderTargetSize.Y / 2);

			addComponent(playerSprite);
			addComponent(new PlayerPhysics());
        }

		public override void update() {
			base.update();

			var physics = getComponent<PlayerPhysics>();

			if(gameStarted)
				physics.Update();
			physics.HandleColorEntities(colorEntities);

            if (Input.isKeyPressed(Keys.Up) || Input.leftMouseButtonPressed) {
				gameStarted = true;
				physics.ApplyImpulse();
            }			
        }
    }
}