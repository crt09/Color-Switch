using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using ColorSwitch.Windows.GameCore.Components;
using ColorSwitch.Windows.GameCore.UiLib.Entities;

namespace ColorSwitch.Windows.GameCore.Entities {
	public class Player : Entity {

		public Color color {
			get => playerSprite.color;
			set => playerSprite.color = value;
		}
		private uint _score = 0;
		public uint score {
			get => _score;
			set {
				scoreText?.setText(value.ToString());
				_score = value;
			}
		}
		private GameText scoreText;

		public List<TouchableEntity> touchableEntities;

		private bool gameStarted = false;
		private Texture2D playerTexture;
		private Sprite playerSprite;

		public Player() : base("player") {
			touchableEntities = new List<TouchableEntity>();
		}

		public Player AddScoreText(GameText scoreText) {
			this.scoreText = scoreText;
			return this;
		}

		public override void onAddedToScene() {		
			playerTexture = scene.content.Load<Texture2D>("Player/player_circle");
			playerSprite = new Sprite(playerTexture);	
			addComponent(playerSprite);
			
			var physics = new PlayerPhysics();
			addComponent(physics);

			var collider = new CircleCollider(playerTexture.Height / 2);
			addComponent(collider);

			transform.position = new Vector2(scene.camera.bounds.size.X * 0.5f, 590);
			color = GameColor.GetColorById((uint)Random.nextInt(4));
		}

		public override void update() {
			base.update();

			var physics = getComponent<PlayerPhysics>();

			if(gameStarted)
				physics.Update();
			physics.HandleTouchableEntities(touchableEntities);

			if (Input.leftMouseButtonPressed) {
				gameStarted = true;
				physics.ApplyImpulse();				
			}

			var halfScreen = scene.camera.bounds.size * 0.5f;
			if (transform.position.Y < halfScreen.Y) {
				var movement = new Vector2(0, halfScreen.Y - transform.position.Y);
				moveAllTouchableEntitiesBy(movement);
				transform.position += movement;
			}

			if (!scene.camera.bounds.intersects(getComponent<Sprite>().bounds)) {
				kill();
			}			
		}

		private void moveAllTouchableEntitiesBy(Vector2 movement) {
			foreach (var touchableEntity in touchableEntities) {
				touchableEntity.transform.position += movement;
			}
		}

		public void kill() {
			var storage = GameDataStorage.getInstance();
			storage.Load();
			if (score > storage.BestScore) {
				storage.BestScore = score;
				storage.Save();
			}
			destroy();
		}
	}
}