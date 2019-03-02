using System;
using Microsoft.Xna.Framework;

namespace ColorSwitch.Windows.GameCore.Helpers {
	public static class GameColor {
		public static Color Violet => new Color(142, 17, 254);
		public static Color Red => new Color(255, 0, 131);
		public static Color Blue => new Color(50, 226, 245);
		public static Color Yellow => new Color(246, 223, 14);
		
		public static Color GetColorById(uint id) {
			switch (id) {
				case 0: return Violet;
				case 1: return Red;
				case 2: return Blue;
				case 3: return Yellow;
				default: throw new IndexOutOfRangeException("'id' is out of range of possible game colors");
			}
		}
	}
}