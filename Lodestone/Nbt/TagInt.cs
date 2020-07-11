using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagInt : Tag
    {
        public int Value { get; private set; }
        public override TagType Type => TagType.TAG_Int;

        public TagInt(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            this.Value = reader.ReadInt32();
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write(this.Value);
        }
    }
}