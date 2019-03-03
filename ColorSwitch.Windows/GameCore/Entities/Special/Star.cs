using ColorSwitch.Windows.GameCore.UiLib.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Particles;
using Nez.Sprites;
using Nez.Tweens;

namespace ColorSwitch.Windows.GameCore.Entities.Special {
	public class Star : TouchableEntity {
		
		private Texture2D starTexture;
		private Sprite starSprite;
		private ParticleEmitterConfig particleConfig;
		private float deathDuration = 0.7f;

		public override Vector2 realSize => starTexture.Bounds.Size.ToVector2();

		public Star() : base("star") { }

		public override void onAddedToScene() {
			starTexture = scene.content.Load<Texture2D>("ColorEntities/star");
			starSprite = new Sprite(starTexture);
			addComponent(starSprite);

			var collider = new CircleCollider(starTexture.Height / 2);
			addComponent(collider);

			particleConfig = scene.content.Load<ParticleEmitterConfig>("Particles/star_death");
			particleConfig.duration = deathDuration;
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
			showScore();
			spawnParticles();			
			base.destroy();		
		}

		private void showScore() {
			var scoreText = new GameText("+1");
			scoreText.position = position;
			scene.addEntity(scoreText);

			var moveTween = scoreText.tweenPositionTo(position + new Vector2(0, -40), deathDuration);
			moveTween.setEaseType(EaseType.QuadOut);
			moveTween.start();

			var opacityTween = new FloatTween(scoreText, 0f, deathDuration - 0.3f);
			opacityTween.setEaseType(EaseType.QuadOut);
			opacityTween.setDelay(0.3f);
			opacityTween.start();

			Core.schedule(deathDuration, t => {
				if (scene != null) scoreText?.destroy();
			});
		}

		private void spawnParticles() {
			var index = Player.touchableEntities.IndexOf(this) + 1;
			var particles = Player.touchableEntities[index];

			particleConfig.sourcePosition = position;
			var particleEmitter = particles.addComponent(new ParticleEmitter(particleConfig));
			particleEmitter.play();
		}
	}
}