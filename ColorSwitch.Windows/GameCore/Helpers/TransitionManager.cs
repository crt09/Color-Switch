using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Helpers {
	public static class TransitionManager {
#pragma warning disable 0618
		public static void StartDefault<TScene>(Color clearColor) where TScene : Scene, new() {
			var transition = new FadeTransition(() => Scene.createWithDefaultRenderer<TScene>(clearColor)) {
				delayBeforeFadeInDuration = 0, fadeOutDuration = 0.3f, fadeInDuration = 0.3f
			};
			Core.startSceneTransition(transition);
		}
#pragma warning restore 0618
	}
}