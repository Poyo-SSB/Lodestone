using Lodestone.Utility;

namespace Lodestone.Nbt
{
    public class TagByteArray : Tag
    {
        public override TagType Type => TagType.TAG_Byte_Array;
        public sbyte[] Value { get; set; }

        public TagByteArray(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);
        public TagByteArray(string name, sbyte[] value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            int length = reader.ReadInt32();
            this.Value = new sbyte[length];

            for (int i = 0; i < length; i++)
            {
                this.Value[i] = reader.ReadSByte();
            }
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write(this.Value.Length);

            for (int i = 0; i < this.Value.Length; i++)
            {
                writer.Write(this.Value[i]);
            }
        }
    }
}