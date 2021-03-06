﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ColorSwitch.Windows.GameCore.Serialization {

	[Serializable]
	public class GameDataStorage {

		public uint BestScore { get; set; }

		[NonSerialized]
		private static GameDataStorage _instance;
		public static GameDataStorage getInstance() => 
			_instance ?? (_instance = new GameDataStorage());

		[NonSerialized]
		private BinaryFormatter formatter;

		[NonSerialized]
		private string path = "Content/storage.dat";

		public void Save() {
			formatter = formatter ?? new BinaryFormatter();
			using (var stream = new FileStream(path, FileMode.OpenOrCreate)) {
				formatter.Serialize(stream, this);
			}
		}

		public void Load() {
			if (!File.Exists(path))
				Save();

			formatter = formatter ?? new BinaryFormatter();
			using (var stream = new FileStream(path, FileMode.Open)) {
				var obj = (GameDataStorage)formatter.Deserialize(stream);
				
				this.BestScore = obj.BestScore;
			}
		}
	}
}