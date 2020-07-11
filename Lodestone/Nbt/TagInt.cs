using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagInt : Tag
    {
        public TagInt(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public int Value { get; private set; }

        protected override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }

            this.Value = reader.ReadInt32();
        }
    }
}