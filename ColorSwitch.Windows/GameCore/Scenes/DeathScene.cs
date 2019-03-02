using ColorSwitch.Windows.GameCore.Entities;
using ColorSwitch.Windows.GameCore.Helpers;
using ColorSwitch.Windows.GameCore.Serialization;
using ColorSwitch.Windows.GameCore.UiLib.Entities;
using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class DeathScene : Scene {
		public DeathScene() : base() {
			setDesignResolution(400, 700, SceneResolutionPolicy.BestFit);
		}

		public override void initialize() {
			var halfScreen = camera.bounds.size * 0.5f;

			var restartButton = new Button("UI/restart_button_normal", "UI/restart_button_hover");
			restartButton.position = new Vector2(halfScreen.X, halfScreen.Y);
			restartButton.Click += RestartButtonOnClick;
			addEntity(restartButton);

			var scoreText = new GameText($"Score: {Player.score}");
			scoreText.position = new Vector2(200, 50);
			addEntity(scoreText);

			var storage = GameDataStorage.getInstance();
			storage.Load();
			var bestScoreText = new GameText($"Best score: {storage.BestScore}");
			bestScoreText.position = new Vector2(200, 100);
			addEntity(bestScoreText);

			var mainMenuButton = new Button("UI/menu_button_normal", "UI/menu_button_hover");
			mainMenuButton.position = new Vector2(32, 32);
			mainMenuButton.Click += MainMenuButtonOnClick;
			addEntity(mainMenuButton);
		}

		private void MainMenuButtonOnClick() {
			TransitionManager.StartDefault<MainMenuScene>(clearColor);
		}

		private void RestartButtonOnClick() {
			TransitionManager.StartDefault<GameScene>(clearColor);
		}
	}
}