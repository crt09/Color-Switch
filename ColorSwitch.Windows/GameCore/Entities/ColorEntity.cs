using Nez;

namespace ColorSwitch.Windows.GameCore.Entities {
	public abstract class ColorEntity : Entity {
		public ColorEntity(string name) : base(name) { }

		public abstract void OnTouch(Entity sender);
	}
}