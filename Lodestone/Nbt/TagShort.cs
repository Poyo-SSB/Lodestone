using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagShort : Tag
    {
        public TagShort(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public short Value { get; private set; }

        protected override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }

            this.Value = reader.ReadInt16();
        }
    }
}