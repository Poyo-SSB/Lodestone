using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagFloat : Tag
    {
        public float Value { get; private set; }
        public override TagType Type => TagType.TAG_Float;

        public TagFloat(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            this.Value = reader.ReadSingle();
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write(this.Value);
        }
    }
}