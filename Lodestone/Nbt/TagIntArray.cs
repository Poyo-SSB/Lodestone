using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagIntArray : Tag
    {
        public int[] Value { get; private set; }
        public override TagType Type => TagType.TAG_Int_Array;
        
        public TagIntArray(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            int length = reader.ReadInt32();
            this.Value = new int[length];

            for (int i = 0; i < length; i++)
            {
                this.Value[i] = reader.ReadInt32();
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