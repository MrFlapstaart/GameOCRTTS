using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace GameOCRTTS
{
	public class OCRDimBase
    {
		[XmlAttribute(AttributeName = "ID")]
		public string Id { get; set; }

		[XmlAttribute(AttributeName = "HPOS")]
		public int HPos { get; set; }

		[XmlAttribute(AttributeName = "VPOS")]
		public int VPos { get; set; }

		[XmlAttribute(AttributeName = "WIDTH")]
		public int Width { get; set; } = 1;

		[XmlAttribute(AttributeName = "HEIGHT")]
		public int Height { get; set; } = 1;

	}

	[XmlRoot(ElementName = "String")]
	public class TextString : OCRDimBase
	{		
		[XmlAttribute(AttributeName = "WC")]
		public string WC { get; set; }

		private string _content;
		[XmlAttribute(AttributeName = "CONTENT")]
		public string Content
		{
			get { return _content; }
			set { _content = value?.Replace("|", "I")?.Replace("[","I"); }
		}
	}

	[XmlRoot(ElementName = "TextLine")]
	public class TextLine : OCRDimBase
	{
		[XmlElement(ElementName = "String")]
		public List<TextString> Words { get; set; }

		[XmlElement(ElementName = "SP")]
		public List<SP> SP { get; set; }

		[XmlIgnore]
		public int WordsInLine
        {
			get { return Words?.Count ?? 0; }
			set { }
        }

		[XmlIgnore]
		public string Text
        {
			get 
			{
				var result = string.Join(" ", Words.Select(x => x.Content).ToList());
				return result;
			}
            set { }
        }

        public override string ToString()
        {
			return $"{HPos},{VPos},{Width},{Height} : {Text}";
        }

    }

	[XmlRoot(ElementName = "TextBlock")]
	public class TextBlock : OCRDimBase
	{
		[XmlElement(ElementName = "TextLine")]
		public List<TextLine> Lines { get; set; } = new List<TextLine>();

		[XmlIgnore]
		public int WordsInBlock
        {
			get { return Lines.Sum(x => x.WordsInLine); }
			set { }
        }

		private string _Text;
		[XmlIgnore]
		public string Text
		{
			get
			{
				var result = string.Join(" ", Lines.Select(x => x.Text).ToList());
				return result + _Text;
			}
			set { _Text = value; }
		}

        public override string ToString()
        {
			return $"{HPos},{VPos},{Width},{Height} : {Text}";
        }

    }

	[XmlRoot(ElementName = "ComposedBlock")]
	public class ComposedBlock : OCRDimBase
	{
		[XmlElement(ElementName = "TextBlock")]
		public List<TextBlock> Blocks { get; set; } = new List<TextBlock>();

		[XmlIgnore]
		public int WordsInComposedBlock
        {
			get { return Blocks.Sum(x => x.WordsInBlock); }
			set { }
        }
	}

	[XmlRoot(ElementName = "SP")]
	public class SP : OCRDimBase
	{
	}

	[XmlRoot(ElementName = "PrintSpace")]
	public class PrintSpace : OCRDimBase
	{
		[XmlElement(ElementName = "ComposedBlock")]
		public List<ComposedBlock> ComposedBlock { get; set; } = new List<ComposedBlock>();
	}

	[XmlRoot(ElementName = "Page")]
	public class OCRResult
	{
		[XmlElement(ElementName = "PrintSpace")]
		public PrintSpace PrintSpace { get; set; } = new PrintSpace();

		[XmlAttribute(AttributeName = "WIDTH")]
		public string Width { get; set; }

		[XmlAttribute(AttributeName = "HEIGHT")]
		public string Height { get; set; }

		[XmlAttribute(AttributeName = "PHYSICAL_IMG_NR")]
		public string PhysicalImageNumber { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public string Id { get; set; }

		[XmlIgnore]
		public string Result { get; set; }
	}
}
