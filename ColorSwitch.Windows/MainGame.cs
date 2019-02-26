using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ColorSwitch.Windows {
	public class MainGame : Game {
		GraphicsDeviceManager graphics;

		public MainGame() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			graphics.PreferredBackBufferWidth = 500;
			graphics.PreferredBackBufferHeight = 800;
			graphics.PreferMultiSampling = true;
			graphics.ApplyChanges();

			IsMouseVisible = true;			
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Black);
			base.Draw(gameTime);
		}
	}
}