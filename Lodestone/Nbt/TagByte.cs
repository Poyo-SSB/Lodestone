using Lodestone.Utility;

namespace Lodestone.Nbt
{
    public class TagByte : Tag
    {
        public override TagType Type => TagType.TAG_Byte;
        public sbyte Value { get; set; }

        public TagByte(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);
        public TagByte(string name, sbyte value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            this.Value = reader.ReadSByte();
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write(this.Value);
        }
    }
}