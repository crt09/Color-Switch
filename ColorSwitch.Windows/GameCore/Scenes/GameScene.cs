using Nez;

using ColorSwitch.Windows.GameCore.Entities;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class GameScene : Scene {
		public GameScene() : base() { }

		public override void initialize() {			
			var player = new Player();
			var colorSwitcher = new ColorSwitcher();
			var star = new Star();
			player.touchableEntities.Add(colorSwitcher);
			player.touchableEntities.Add(star);

			addEntity(player);
			addEntity(colorSwitcher);
			addEntity(star);
		}
	}
}