using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

using ColorSwitch.Windows.GameCore.Scenes;

namespace ColorSwitch.Windows {
    public class MainGame : Core {       
        public MainGame() : base(width: 800, height: 800, isFullScreen: false, enableEntitySystems: false) { }

        protected override void Initialize() {
			base.Initialize();
			Window.AllowUserResizing = true;						

			defaultSamplerState = SamplerState.PointClamp;
#pragma warning disable 0618 // disable obsolete warning
            scene = Scene.createWithDefaultRenderer<GameScene>(Color.Black);
#pragma warning restore 0618
			Core.debugRenderEnabled = true;
        }
    }
}
