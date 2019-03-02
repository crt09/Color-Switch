using Nez;
using ColorSwitch.Windows.GameCore.Entities;
using ColorSwitch.Windows.GameCore.UiLib.Entities;
using Microsoft.Xna.Framework;
using ColorSwitch.Windows.GameCore.Helpers;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class GameScene : Scene {

		private Player player;

		public GameScene() : base() {
			setDesignResolution(400, 700, SceneResolutionPolicy.BestFit);
		}

		public override void initialize() {		
			player = new Player();
			addEntity(player);

			var entityBuilder = new EntityBuilder(player.touchableEntities);			
			addEntity(entityBuilder);

			initializeUi();	
		}

		private void initializeUi() {
			var scoreText = new GameText("0");
			scoreText.position = new Vector2(16, 16);
			player.AddScoreText(scoreText);
			addEntity(scoreText);
		}
	}
}