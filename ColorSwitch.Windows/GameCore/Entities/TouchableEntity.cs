using Nez;

namespace ColorSwitch.Windows.GameCore.Entities {
	public abstract class TouchableEntity : Entity {
		public TouchableEntity(string name) : base(name) { }

		public abstract void SendState(Entity sender);
	}
}