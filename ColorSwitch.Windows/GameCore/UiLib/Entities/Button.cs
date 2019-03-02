using System;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace ColorSwitch.Windows.GameCore.UiLib.Entities {
	public class Button : Entity {

		public event Action OnClick;

		private Subtexture normalButtonSubtexture;
		private Subtexture hoverButtonSubtexture;
		private Sprite buttonSprite;

		private string normalButtonContent;
		private string hoverButtonContent;

		public Button(string normalButtonContent, string hoverButtonContent) : base("button") {
			this.normalButtonContent = normalButtonContent;
			this.hoverButtonContent = hoverButtonContent;
		}

		public override void onAddedToScene() {
			normalButtonSubtexture = new Subtexture(scene.content.Load<Texture2D>(normalButtonContent));
			hoverButtonSubtexture = new Subtexture(scene.content.Load<Texture2D>(hoverButtonContent));
			buttonSprite = new Sprite(normalButtonSubtexture);
			addComponent(buttonSprite);
		}

		public override void update() {
			base.update();
			buttonSprite.subtexture = isHovering() ? hoverButtonSubtexture : normalButtonSubtexture;
			if (Input.leftMouseButtonReleased && isHovering()) {
				OnClick?.Invoke();
			}
		}

		private bool isHovering() =>
			buttonSprite != null && buttonSprite.bounds.contains(Input.mousePosition);
	}
}