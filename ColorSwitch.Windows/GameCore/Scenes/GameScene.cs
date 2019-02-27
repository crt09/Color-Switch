using Nez;

using ColorSwitch.Windows.GameCore.Entities;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class GameScene : Scene {
		public GameScene() : base() {
			
		}

		public override void initialize() {			
			addEntity(new Player());
		}
	}
}