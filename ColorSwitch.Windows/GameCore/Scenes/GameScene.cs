using Nez;

using ColorSwitch.Windows.GameCore.Entities;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class GameScene : Scene {
		public GameScene() : base() { }

		public override void initialize() {			
			var player = new Player();
			var colorSwitcher = new ColorSwitcher();
			player.colorEntities.Add(colorSwitcher);

			addEntity(colorSwitcher);
			addEntity(player);
        }
	}
}