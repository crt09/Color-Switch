using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Helpers {
	public static class TransitionManager {

		public static float delay => 0.3f;
		private static bool transitionBusy;

#pragma warning disable 0618
		public static void StartDefault<TScene>(Color clearColor) where TScene : Scene, new() {
			if (transitionBusy) return;
			var transition = new FadeTransition(() => Scene.createWithDefaultRenderer<TScene>(clearColor)) {
				delayBeforeFadeInDuration = 0, fadeOutDuration = delay, fadeInDuration = delay, fadeToColor = clearColor
			};			
			Core.startSceneTransition(transition);

			transitionBusy = true;
			var totalTransitionTime = transition.fadeInDuration + transition.fadeOutDuration + transition.delayBeforeFadeInDuration;
			Task.Delay((int)(totalTransitionTime * 1000)).ContinueWith((t) => {
				transitionBusy = false;
			});
		}
#pragma warning restore 0618
	}
}