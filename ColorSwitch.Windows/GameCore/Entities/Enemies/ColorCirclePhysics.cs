using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Entities.Enemies {
	public class ColorCirclePhysics : Component {

		public struct ColorInfo {
			public Color color;
			public Collider collider;		
			public ColorInfo(Color color, Collider collider) {
				this.color = color;
				this.collider = collider;
			}
		}
		public List<ColorInfo> colorInfo;

		public ColorCirclePhysics() : base() { }

		public override void initialize() {
			colorInfo = new List<ColorInfo>();
		}
	}
}