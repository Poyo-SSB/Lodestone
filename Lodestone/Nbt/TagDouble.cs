using Lodestone.Utility;

namespace Lodestone.Nbt
{
    public class TagDouble : Tag
    {
        public double Value { get; set; }
        public override TagType Type => TagType.TAG_Double;

        public TagDouble(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);
        public TagDouble(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            this.Value = reader.ReadDouble();
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write(this.Value);
        }
    }
}