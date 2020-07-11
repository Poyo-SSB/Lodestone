using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagByteArray : Tag
    {
        public TagByteArray(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public sbyte[] Value { get; private set; }

        protected override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }

            int length = reader.ReadInt32();
            this.Value = new sbyte[length];

            for (int i = 0; i < length; i++)
            {
                this.Value[i] = reader.ReadSByte();
            }
        }
    }
}