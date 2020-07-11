using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagList : Tag
    {
        public override TagType Type => TagType.TAG_List;

        public TagType ListType { get; private set; }
        private Tag[] value;

        public TagList(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            this.ListType = (TagType)reader.ReadByte();
            int length = reader.ReadInt32();

            this.value = new Tag[length];

            for (int i = 0; i < length; i++)
            {
                switch (this.ListType)
                {
                    case TagType.TAG_Byte:
                        this.value[i] = new TagByte(reader, false);
                        break;
                    case TagType.TAG_Short:
                        this.value[i] = new TagShort(reader, false);
                        break;
                    case TagType.TAG_Int:
                        this.value[i] = new TagInt(reader, false);
                        break;
                    case TagType.TAG_Long:
                        this.value[i] = new TagLong(reader, false);
                        break;
                    case TagType.TAG_Float:
                        this.value[i] = new TagFloat(reader, false);
                        break;
                    case TagType.TAG_Double:
                        this.value[i] = new TagDouble(reader, false);
                        break;
                    case TagType.TAG_Byte_Array:
                        this.value[i] = new TagByteArray(reader, false);
                        break;
                    case TagType.TAG_String:
                        this.value[i] = new TagString(reader, false);
                        break;
                    case TagType.TAG_List:
                        this.value[i] = new TagList(reader, false);
                        break;
                    case TagType.TAG_Compound:
                        this.value[i] = new TagCompound(reader, false);
                        break;
                    case TagType.TAG_Int_Array:
                        this.value[i] = new TagIntArray(reader, false);
                        break;
                    case TagType.TAG_Long_Array:
                        this.value[i] = new TagLongArray(reader, false);
                        break;
                }
            }
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write((byte)this.ListType);
            writer.Write(this.value.Length);

            for (int i = 0; i < this.value.Length; i++)
            {
                this.value[i].Write(writer, false);
            }
        }

        public TagByte[] GetArrayByte() => this.GetArray<TagByte>();
        public TagShort[] GetArrayShort() => this.GetArray<TagShort>();
        public TagInt[] GetArrayInt() => this.GetArray<TagInt>();
        public TagLong[] GetArrayLong() => this.GetArray<TagLong>();
        public TagFloat[] GetArrayFloat() => this.GetArray<TagFloat>();
        public TagDouble[] GetArrayDouble() => this.GetArray<TagDouble>();
        public TagByteArray[] GetArrayByteArray() => this.GetArray<TagByteArray>();
        public TagString[] GetArrayString() => this.GetArray<TagString>();
        public TagList[] GetArrayList() => this.GetArray<TagList>();
        public TagCompound[] GetArrayCompound() => this.GetArray<TagCompound>();
        public TagIntArray[] GetArrayIntArray() => this.GetArray<TagIntArray>();
        public TagLongArray[] GetArrayLongArray() => this.GetArray<TagLongArray>();

        private T[] GetArray<T>() where T : Tag {
            T[] returnedValue = new T[this.value.Length];
            for (int i = 0; i < returnedValue.Length; i++)
            {
                returnedValue[i] = (T)this.value[i];
            }
            return returnedValue;
        }
    }
}