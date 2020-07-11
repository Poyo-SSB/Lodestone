using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagByte : Tag
    {
        public override TagType Type => TagType.TAG_Byte;
        public sbyte Value { get; private set; }

        public TagByte(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

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