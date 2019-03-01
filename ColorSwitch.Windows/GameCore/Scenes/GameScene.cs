using Nez;

using ColorSwitch.Windows.GameCore.Entities;
using ColorSwitch.Windows.GameCore.Entities.Enemies;
using ColorSwitch.Windows.GameCore.Entities.Special;

namespace ColorSwitch.Windows.GameCore.Scenes {
	public class GameScene : Scene {
		public GameScene() : base() { }

		public override void initialize() {			
			var player = new Player();
			addEntity(player);

			var builder = new EntityBuilder(player.touchableEntities);			
			addEntity(builder);
		}
	}
}