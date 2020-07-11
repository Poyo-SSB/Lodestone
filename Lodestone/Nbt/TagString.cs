using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagString : Tag
    {
        public string Value { get; private set; }
        public override TagType Type => TagType.TAG_String;

        public TagString(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            short valueLength = reader.ReadInt16();
            this.Value = Encoding.UTF8.GetString(reader.ReadBytes(valueLength));
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write((short)this.Value.Length);
            writer.Write(Encoding.UTF8.GetBytes(this.Value));
        }
    }
}