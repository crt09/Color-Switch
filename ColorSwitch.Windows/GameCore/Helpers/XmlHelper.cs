using System;
using System.IO;
using System.Xml.Serialization;

namespace ColorSwitch.Windows.GameCore.Helpers {
	public static class XmlHelper {
		public static T FromXml<T>(string xml) {
			XmlSerializer xs = new XmlSerializer(typeof(T));
			using (StringReader sr = new StringReader(xml)) {
				return (T) xs.Deserialize(sr);
			}
		}
		public static object FromXml(string xml, string typeName) {
			Type T = Type.GetType(typeName);
			XmlSerializer xs = new XmlSerializer(T);
			using (StringReader sr = new StringReader(xml)) {
				return xs.Deserialize(sr);
			}
		}
	}
}