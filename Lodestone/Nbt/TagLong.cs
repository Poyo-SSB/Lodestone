using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagLong : Tag
    {
        public TagLong(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public long Value { get; private set; }

        protected override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }

            this.Value = reader.ReadInt64();
        }
    }
}