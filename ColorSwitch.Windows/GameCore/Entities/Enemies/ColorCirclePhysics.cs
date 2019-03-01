using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

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

			var storage = XmlHelper.FromXml<PolygonStorage>(Properties.Resources.PolygonStorage);

			var sectorPoints = storage.SectorStorage;
			for (int i = 0; i < sectorPoints.Count; i++) {
				var spriteSize = entity.getComponent<Sprite>().bounds;
				applyOffset(
					new Vector2(entity.transform.position.X - spriteSize.width / 2,
						entity.transform.position.Y - spriteSize.height / 2), sectorPoints[i]);

				var collider = new PolygonCollider(sectorPoints[i].ToArray());
				entity.addComponent(collider);

				Color color = GameColor.GetColorById((uint)i);
				colorInfo.Add(new ColorInfo(color, collider));
			}
		}

		private void applyOffset(Vector2 offset, List<Vector2> array) {
			for (int i = 0; i < array.Count; i++) {
				array[i] += offset;
			}
		}
	}
}