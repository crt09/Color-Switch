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

		public List<ColorEntity> colorEntities;

		private bool gameStarted = false;
		private Texture2D playerTexture;
		private Sprite playerSprite;

		public Player() : base("player") {
			colorEntities = new List<ColorEntity>();
        }

        public override void onAddedToScene() {		
			playerTexture = scene.content.Load<Texture2D>("Player/player_circle");
			playerSprite = new Sprite(playerTexture);	
			addComponent(playerSprite);
            
			var physics = new PlayerPhysics();
			addComponent(physics);

			var collider = new CircleCollider(playerTexture.Height / 2);
            addComponent(collider);

			transform.position = new Vector2(scene.sceneRenderTargetSize.X / 2, scene.sceneRenderTargetSize.Y / 2);
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