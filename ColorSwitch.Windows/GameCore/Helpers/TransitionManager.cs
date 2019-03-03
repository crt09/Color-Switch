using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Nez;

namespace ColorSwitch.Windows.GameCore.Helpers {
	public static class TransitionManager {
#pragma warning disable 0618
		public const float DURATION = 0.3f;

		private static bool handlerIsBusy;
		private static Queue transitions = new Queue();

		private class TransitionInfo {
			public SceneTransition transition;
			public Type sceneType;
			public TransitionInfo(SceneTransition transition, Type sceneType) {
				this.transition = transition;
				this.sceneType = sceneType;
			}
		}

		public static void StartDefault<TScene>(Color clearColor) where TScene : Scene, new() {
			var transition = new FadeTransition(() => Scene.createWithDefaultRenderer<TScene>(clearColor)) {
				delayBeforeFadeInDuration = 0, fadeOutDuration = DURATION,
				fadeInDuration = DURATION, fadeToColor = clearColor
			};
			var next = new TransitionInfo(transition, typeof(TScene));
			TransitionManager.enqueue(next);
		}

		private static void enqueue(TransitionInfo transition) {
			if (transitions.Count == 0 
				|| transition.sceneType != (transitions.ToArray().Last() as TransitionInfo).sceneType) {
				transitions.Enqueue(transition);
			}

			if (handlerIsBusy) return;
			handlerIsBusy = true;
			TransitionManager.peekAndStart();			
		}

		private static void peekAndStart() {
			var currentTransition = (transitions.Peek() as TransitionInfo).transition;
			currentTransition.onTransitionCompleted += onTransitionCompleted;
			Core.startSceneTransition(currentTransition);
		}

		private static void onTransitionCompleted() {
			handlerIsBusy = false;
			transitions.Dequeue();
			if (transitions.Count > 0) {
				TransitionManager.enqueue(transitions.Peek() as TransitionInfo);
			}
		}
#pragma warning restore 0618
	}
}