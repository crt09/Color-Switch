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

			var background = Background.Create("UI/deathscreen_background");
			addEntity(background);

			var restartButton = new Button("UI/restart_button_normal", "UI/restart_button_hover");
			restartButton.position = new Vector2(halfScreen.X, 580);
			restartButton.Click += RestartButtonOnClick;
			addEntity(restartButton);

			var scoreText = new GameText($"{Player.score}");
			scoreText.position = new Vector2(halfScreen.X, 335);
			addEntity(scoreText);

			var storage = GameDataStorage.getInstance();
			storage.Load();
			var bestScoreText = new GameText($"{storage.BestScore}");
			bestScoreText.position = new Vector2(halfScreen.X, 435);
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