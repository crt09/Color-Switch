using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Nez;

#pragma warning disable 0618

namespace ColorSwitch.Windows.GameCore.Helpers {
	public class TransitionManager {

		public static float duration = 0.3f;

		private static TransitionManager _instance;
		private static TransitionManager instance => 
			_instance ?? (_instance = new TransitionManager());

		public static void StartDefault<TScene>(Color clearColor) where TScene : Scene, new() {
			TransitionManager.instance.start<TScene>(clearColor);
		}

		private bool handlerIsBusy;
		private Queue transitions;

		private TransitionManager() {
			transitions = new Queue();
		}

		private class TransitionInfo {
			public SceneTransition transition;
			public Type sceneType;
			public TransitionInfo(SceneTransition transition, Type sceneType) {
				this.transition = transition;
				this.sceneType = sceneType;
			}
		}

		private void start<TScene>(Color clearColor) where TScene : Scene, new() {
			var transition = new FadeTransition(() => Scene.createWithDefaultRenderer<TScene>(clearColor)) {
				delayBeforeFadeInDuration = 0, fadeOutDuration = duration,
				fadeInDuration = duration, fadeToColor = clearColor
			};
			var next = new TransitionInfo(transition, typeof(TScene));
			this.enqueue(next);
		}

		private void enqueue(TransitionInfo transition) {
			var lastSceneType = (transitions.Count > 0) ? (transitions.ToArray().Last() as TransitionInfo).sceneType : null;
			if (transition.sceneType != lastSceneType) {
				transitions.Enqueue(transition);
			}

			if (handlerIsBusy) return;
			handlerIsBusy = true;
			this.peekAndStart();			
		}

		private void peekAndStart() {
			var transition = (transitions.Peek() as TransitionInfo).transition;
			transition.onTransitionCompleted += onTransitionCompleted;
			Core.startSceneTransition(transition);
		}

		private void onTransitionCompleted() {
			handlerIsBusy = false;
			transitions.Dequeue();
			if (transitions.Count > 0) {
				this.enqueue(transitions.Peek() as TransitionInfo);
			}
		}
	}
}
#pragma warning restore 0618