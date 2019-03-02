using Nez;
using ColorSwitch.Windows.GameCore.Entities;
using ColorSwitch.Windows.GameCore.UiLib.Entities;
using Microsoft.Xna.Framework;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class GameScene : Scene {

		private Player player;

		public GameScene() : base() { }

		public override void initialize() {			
			player = new Player();
			addEntity(player);

			var entityBuilder = new EntityBuilder(player.touchableEntities);			
			addEntity(entityBuilder);

			initializeUi();	
		}

		private void initializeUi() {
			var pauseButton = new Button("UI/pause_button_normal", "UI/pause_button_hover");
			pauseButton.position = new Vector2(camera.bounds.width - 32, 32);
			pauseButton.OnClick += () => Core.exit();
			addEntity(pauseButton);

			var scoreText = new GameText("0");
			scoreText.position = new Vector2(16, 16);
			player.AddScoreText(scoreText);
			addEntity(scoreText);
		}
	}
}