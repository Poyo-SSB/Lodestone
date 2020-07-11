using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagFloat : Tag
    {
        public TagFloat(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public float Value { get; private set; }

        protected override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }

            this.Value = reader.ReadSingle();
        }
    }
}