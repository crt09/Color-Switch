using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Helpers {
	public static class TransitionManager {

		public static float delay => 0.3f;

#pragma warning disable 0618
		public static void StartDefault<TScene>(Color clearColor) where TScene : Scene, new() {
			var transition = new FadeTransition(() => Scene.createWithDefaultRenderer<TScene>(clearColor)) {
				delayBeforeFadeInDuration = 0, fadeOutDuration = delay, fadeInDuration = delay
			};			
			Core.startSceneTransition(transition);
		}
#pragma warning restore 0618
	}
}