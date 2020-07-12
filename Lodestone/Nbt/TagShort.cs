using Lodestone.Utility;

namespace Lodestone.Nbt
{
    public class TagShort : Tag
    {
        public short Value { get; set; }
        public override TagType Type => TagType.TAG_Short;

        public TagShort(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);
        public TagShort(string name, short value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            this.Value = reader.ReadInt16();
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write(this.Value);
        }
    }
}