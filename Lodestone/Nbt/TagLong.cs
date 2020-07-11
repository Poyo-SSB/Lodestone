using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagLong : Tag
    {
        public long Value { get; private set; }
        public override TagType Type => TagType.TAG_Long;

        public TagLong(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            this.Value = reader.ReadInt64();
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write(this.Value);
        }
    }
}