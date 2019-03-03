using System.IO;
using System.Xml.Serialization;

namespace ColorSwitch.Windows.GameCore.Helpers {
	public static class XmlHelper {
		public static T FromXml<T>(string xml) {
			var formatter = new XmlSerializer(typeof(T));
			using (var reader = new StringReader(xml)) {
				return (T)formatter.Deserialize(reader);
			}
		}
	}
}