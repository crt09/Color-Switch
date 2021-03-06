﻿using Nez;
using ColorSwitch.Windows.GameCore.Entities;
using ColorSwitch.Windows.GameCore.UiLib.Entities;
using Microsoft.Xna.Framework;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class GameScene : Scene {

		private Player player;

		public GameScene() : base() {
			setDesignResolution(400, 700, SceneResolutionPolicy.BestFit);
		}

		public override void initialize() {		
			player = new Player();
			addEntity(player);

			var entityBuilder = new EntityBuilder(Player.touchableEntities);			
			addEntity(entityBuilder);

			Player.score = 0;
			var scoreText = new GameText($"{Player.score}", HorizontalAlign.Left);
			scoreText.position = new Vector2(16, 16);			
			player.AddScoreText(scoreText);
			addEntity(scoreText);
		}
	}
}