using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

using ColorSwitch.Windows.GameCore.Scenes;

namespace ColorSwitch.Windows {
	public class MainGame : Core {       
		public MainGame() : base(width: 400, height: 700, isFullScreen: false, enableEntitySystems: false) { }

		protected override void Initialize() {
			base.Initialize();
			exitOnEscapeKeypress = false;
			defaultSamplerState = SamplerState.LinearClamp;

#pragma warning disable 0618 // disable obsolete warning
			scene = Scene.createWithDefaultRenderer<MainMenuScene>(new Color(42, 40, 43));
#pragma warning restore 0618
		}
	}
}
