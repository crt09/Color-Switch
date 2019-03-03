using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace ColorSwitch.Windows.GameCore.UiLib.Entities {
	public class GameText : Entity {

		private string defaultText;
		private Text gameText;
		private HorizontalAlign horizontalAlign;

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
			if(gameText != null) this.gameText.text = newText;
		}
	}
}