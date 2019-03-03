using ColorSwitch.Windows.GameCore.Helpers;
using ColorSwitch.Windows.GameCore.Serialization;
using ColorSwitch.Windows.GameCore.UiLib.Entities;
using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class MainMenuScene : Scene {

		public MainMenuScene() : base() {
			setDesignResolution(400, 700, SceneResolutionPolicy.BestFit);
		}

		public override void initialize() {
			var halfScreen = camera.bounds.size * 0.5f;

			var background = Background.Create("UI/menu_background");
			addEntity(background);

			var playButton = new Button("UI/play_button_normal", "UI/play_button_hover");
			playButton.position = new Vector2(halfScreen.X, 380);
			playButton.Click += PlayButtonOnClick;
			addEntity(playButton);

			var storage = GameDataStorage.getInstance();
			storage.Load();
			var bestScoreText = new GameText($"{storage.BestScore.ToString()}");
			bestScoreText.position = new Vector2(halfScreen.X, 600);
			addEntity(bestScoreText);
		}

		private void PlayButtonOnClick() {
			TransitionManager.StartDefault<GameScene>(clearColor);
		}
	}
}