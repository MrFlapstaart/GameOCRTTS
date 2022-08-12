using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameOCRTTS
{
	public class OCRDimBase
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

	}

	[XmlRoot(ElementName = "String")]
	public class TextString : OCRDimBase
	{		
		[XmlAttribute(AttributeName = "WC")]
		public string WC { get; set; }

		[XmlAttribute(AttributeName = "CONTENT")]
		public string Content { get; set; }
	}

	[XmlRoot(ElementName = "TextLine")]
	public class TextLine : OCRDimBase
	{
		[XmlElement(ElementName = "String")]
		public List<TextString> TextString { get; set; }

		[XmlElement(ElementName = "SP")]
		public List<SP> SP { get; set; }
	}

	[XmlRoot(ElementName = "TextBlock")]
	public class TextBlock : OCRDimBase
	{
		[XmlElement(ElementName = "TextLine")]
		public List<TextLine> TextLine { get; set; }		
	}

	[XmlRoot(ElementName = "ComposedBlock")]
	public class ComposedBlock : OCRDimBase
	{
		[XmlElement(ElementName = "TextBlock")]
		public TextBlock TextBlock { get; set; }		
	}

	[XmlRoot(ElementName = "SP")]
	public class SP : OCRDimBase
	{
	}

	[XmlRoot(ElementName = "PrintSpace")]
	public class PrintSpace : OCRDimBase
	{
		[XmlElement(ElementName = "ComposedBlock")]
		public List<ComposedBlock> ComposedBlock { get; set; }		
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
