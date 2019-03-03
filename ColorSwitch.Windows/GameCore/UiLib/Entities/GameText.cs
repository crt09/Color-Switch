using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Tweens;

namespace ColorSwitch.Windows.GameCore.UiLib.Entities {
	public class GameText : Entity, ITweenTarget<float> {

		private Text gameText;
		private string defaultText;
		private HorizontalAlign horizontalAlign;

		private float _opacity = 1.0f;
		private float opacity {
			get => _opacity;
			set {
				if(gameText != null)
					gameText.color = Color.White * value;
				_opacity = value;
			}
		}

		public GameText(string defaultText = "", HorizontalAlign horizontalAlign = HorizontalAlign.Center) : base("text") {
			this.defaultText = defaultText;
			this.horizontalAlign = horizontalAlign;
		}

		public override void onAddedToScene() {
			var spriteFont = scene.content.Load<SpriteFont>("font");
			var nezFont = new NezSpriteFont(spriteFont);
			gameText = new Text(nezFont, defaultText, Vector2.Zero, Color.White);
			gameText.setHorizontalAlign(horizontalAlign);
			addComponent(gameText);
		}

		public void setText(string newText) {
			if (gameText != null) this.gameText.text = newText;
		}

		public object getTargetObject() {
			return this;
		}

		public float getTweenedValue() {
			return opacity;
		}

		public void setTweenedValue(float value) {
			opacity = value;
		}
	}
}