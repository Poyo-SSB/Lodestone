using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagDouble : Tag
    {
        public TagDouble(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public double Value { get; private set; }

        protected override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }

            this.Value = reader.ReadDouble();
        }
    }
}