using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagIntArray : Tag
    {
        public TagIntArray(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public int[] Value { get; private set; }

        protected override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }

            int length = reader.ReadInt32();
            this.Value = new int[length];

            for (int i = 0; i < length; i++)
            {
                this.Value[i] = reader.ReadInt32();
            }
        }
    }
}