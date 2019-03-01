using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using ColorSwitch.Windows.GameCore.Entities.Enemies;
using ColorSwitch.Windows.GameCore.Entities.Special;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace ColorSwitch.Windows.GameCore.Entities {
	public class EntityBuilder : Entity {

		private const int ENTITY_INDENT = 50;

		private List<TouchableEntity> touchableEntities;
		public EntityBuilder(List<TouchableEntity> touchableEntities) : base("entity-builder") {
			this.touchableEntities = touchableEntities;
		}

		public override void update() {		
			var halfScreen = scene.camera.bounds.size * 0.5f;

			if (touchableEntities.Count == 0) {

				var entityPosition = new Vector2(halfScreen.X, halfScreen.Y);
				spawnEntity<Star>(entityPosition);
				spawnEntity<ColorCircle>(entityPosition);

			} else if (touchableEntities.Last().position.Y - touchableEntities.Last().getComponent<Sprite>().height * 0.5f >= ENTITY_INDENT) {

				var entityPosition = new Vector2(halfScreen.X, touchableEntities.Last().position.Y - 152 /** magic number **/ - ENTITY_INDENT);
				var a = touchableEntities.Last().position.Y;
				if (touchableEntities.Last() is ColorSwitcher) {
					spawnEntity<Star>(entityPosition);
					spawnEntity<ColorCircle>(entityPosition);
				} else {
					spawnEntity<ColorSwitcher>(entityPosition);
				}
			}
		}

		private T spawnEntity<T>(Vector2? position = null) where T : TouchableEntity, new() {
			var ent = new T();
			if(position != null)
				ent.position = position.Value;
			scene.addEntity(ent);
			touchableEntities.Add(ent);
			return ent;
		}
	}
}