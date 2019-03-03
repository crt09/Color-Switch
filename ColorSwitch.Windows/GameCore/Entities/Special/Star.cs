using ColorSwitch.Windows.GameCore.UiLib.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Tweens;

namespace ColorSwitch.Windows.GameCore.Entities.Special {
	public class Star : TouchableEntity {
		
		private Texture2D starTexture;
		private Sprite starSprite;

		public override Vector2 realSize => starTexture.Bounds.Size.ToVector2();

		public Star() : base("star") { }

		public override void onAddedToScene() {
			starTexture = scene.content.Load<Texture2D>("ColorEntities/star");
			starSprite = new Sprite(starTexture);
			addComponent(starSprite);

			var collider = new CircleCollider(starTexture.Height / 2);
			addComponent(collider);			
		}

		public override void SendState(Entity sender) {
			if (sender is Player player) {
				var starCollider = getComponent<Collider>();
				var playerCollider = player.getComponent<Collider>();
				if (starCollider.collidesWith(playerCollider, out CollisionResult result)) {					
					Player.score++;
					this.destroy();
				}
			}
		}

		private new void destroy() {			
			float duration = 0.7f;

			var scoreText = new GameText("+1");
			scoreText.position = position;
			scene.addEntity(scoreText);

			var moveTween = scoreText.tweenPositionTo(position + new Vector2(0, -40), duration);
			moveTween.setEaseType(EaseType.QuadOut);
			moveTween.start();

			var opacityTween = new FloatTween(scoreText, 0f, duration - 0.3f);
			opacityTween.setEaseType(EaseType.QuadOut);
			opacityTween.setDelay(0.3f);
			opacityTween.start();	
		
			Core.schedule(duration, t => {
				if (scene != null) scoreText?.destroy();
			});
			base.destroy();		
		}
	}
}