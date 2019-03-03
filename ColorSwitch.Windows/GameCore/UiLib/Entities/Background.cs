using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace ColorSwitch.Windows.GameCore.UiLib.Entities {
	public class Background : Entity {

		public static Background Create(string content) {
			return new Background(content);
		}

		private Texture2D backgroundTexture;
		private Sprite backgroundSprite;
		private string contentName;

		private Background(string content) : base("background") {
			contentName = content;
		}

		public override void onAddedToScene() {
			backgroundTexture = scene.content.Load<Texture2D>(contentName);
			backgroundSprite = new Sprite(backgroundTexture);
			addComponent(backgroundSprite);

			transform.position = scene.camera.bounds.size * 0.5f;
		}
	}
}