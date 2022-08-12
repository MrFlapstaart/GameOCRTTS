using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameOCRTTS
{
	[XmlRoot(ElementName = "String")]
	public class String
	{
		[XmlAttribute(AttributeName = "ID")]
		public string Id { get; set; }

		[XmlAttribute(AttributeName = "HPOS")]
		public string HPos { get; set; }

		[XmlAttribute(AttributeName = "VPOS")]
		public string VPos { get; set; }

		[XmlAttribute(AttributeName = "WIDTH")]
		public string Width { get; set; }

		[XmlAttribute(AttributeName = "HEIGHT")]
		public string Height { get; set; }

		[XmlAttribute(AttributeName = "WC")]
		public string WC { get; set; }

		[XmlAttribute(AttributeName = "CONTENT")]
		public string Content { get; set; }
	}

	[XmlRoot(ElementName = "TextLine")]
	public class TextLine
	{
		[XmlElement(ElementName = "String")]
		public List<String> String { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public string Id { get; set; }

		[XmlAttribute(AttributeName = "HPOS")]
		public string HPos { get; set; }

		[XmlAttribute(AttributeName = "VPOS")]
		public string VPos { get; set; }

		[XmlAttribute(AttributeName = "WIDTH")]
		public string Width { get; set; }

		[XmlAttribute(AttributeName = "HEIGHT")]
		public string Height { get; set; }

		[XmlElement(ElementName = "SP")]
		public List<SP> SP { get; set; }
	}

	[XmlRoot(ElementName = "TextBlock")]
	public class TextBlock
	{
		[XmlElement(ElementName = "TextLine")]
		public List<TextLine> TextLine { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public string Id { get; set; }

		[XmlAttribute(AttributeName = "HPOS")]
		public string HPos { get; set; }

		[XmlAttribute(AttributeName = "VPOS")]
		public string VPos { get; set; }

		[XmlAttribute(AttributeName = "WIDTH")]
		public string Width { get; set; }

		[XmlAttribute(AttributeName = "HEIGHT")]
		public string Height { get; set; }
	}

	[XmlRoot(ElementName = "ComposedBlock")]
	public class ComposedBlock
	{
		[XmlElement(ElementName = "TextBlock")]
		public TextBlock TextBlock { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public string Id { get; set; }

		[XmlAttribute(AttributeName = "HPOS")]
		public string HPos { get; set; }

		[XmlAttribute(AttributeName = "VPOS")]
		public string VPos { get; set; }

		[XmlAttribute(AttributeName = "WIDTH")]
		public string Width { get; set; }

		[XmlAttribute(AttributeName = "HEIGHT")]
		public string Height { get; set; }
	}

	[XmlRoot(ElementName = "SP")]
	public class SP
	{
		[XmlAttribute(AttributeName = "WIDTH")]
		public string Width { get; set; }

		[XmlAttribute(AttributeName = "VPOS")]
		public string VPos { get; set; }

		[XmlAttribute(AttributeName = "HPOS")]
		public string HPos { get; set; }
	}

	[XmlRoot(ElementName = "PrintSpace")]
	public class PrintSpace
	{
		[XmlElement(ElementName = "ComposedBlock")]
		public List<ComposedBlock> ComposedBlock { get; set; }

		[XmlAttribute(AttributeName = "HPOS")]
		public string HPos { get; set; }

		[XmlAttribute(AttributeName = "VPOS")]
		public string VPos { get; set; }

		[XmlAttribute(AttributeName = "WIDTH")]
		public string Width { get; set; }

		[XmlAttribute(AttributeName = "HEIGHT")]
		public string Height { get; set; }
	}

	[XmlRoot(ElementName = "Page")]
	public class OCRResult
	{
		[XmlElement(ElementName = "PrintSpace")]
		public PrintSpace PrintSpace { get; set; }

		[XmlAttribute(AttributeName = "WIDTH")]
		public string Width { get; set; }

		[XmlAttribute(AttributeName = "HEIGHT")]
		public string Height { get; set; }

		[XmlAttribute(AttributeName = "PHYSICAL_IMG_NR")]
		public string PhysicalImageNumber { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public string Id { get; set; }
	}
}
