using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagString : Tag
    {
        public TagString(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public string Value { get; private set; }

        protected override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }

            short valueLength = reader.ReadInt16();
            this.Value = Encoding.UTF8.GetString(reader.ReadBytes(valueLength));
        }
    }
}