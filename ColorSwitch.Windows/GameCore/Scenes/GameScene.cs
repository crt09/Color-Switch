using Nez;

using ColorSwitch.Windows.GameCore.Entities;
using ColorSwitch.Windows.GameCore.Entities.Enemies;
using ColorSwitch.Windows.GameCore.Entities.Special;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class GameScene : Scene {
		public GameScene() : base() { }

		public override void initialize() {			
			var player = new Player();
			var colorSwitcher = new ColorSwitcher();
			var star = new Star();
			var circle = new ColorCircle();
			player.touchableEntities.Add(colorSwitcher);
			player.touchableEntities.Add(star);
			player.touchableEntities.Add(circle);

			addEntity(player);
			addEntity(colorSwitcher);
			addEntity(star);
			addEntity(circle);
		}
	}
}