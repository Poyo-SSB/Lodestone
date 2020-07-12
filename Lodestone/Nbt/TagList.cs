using Lodestone.Utility;

namespace Lodestone.Nbt
{
    public class TagList : Tag
    {
        public override TagType Type => TagType.TAG_List;

        public TagType ListType { get; set; }
        public Tag[] Value { get; set; }

        public TagList(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);
        public TagList(string name, TagType type, Tag[] value)
        {
            this.Name = name;
            this.ListType = type;
            this.Value = value;
        }

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

            this.ListType = (TagType)reader.ReadByte();
            int length = reader.ReadInt32();

            this.Value = new Tag[length];

            for (int i = 0; i < length; i++)
            {
                switch (this.ListType)
                {
                    case TagType.TAG_Byte:
                        this.Value[i] = new TagByte(reader, false);
                        break;
                    case TagType.TAG_Short:
                        this.Value[i] = new TagShort(reader, false);
                        break;
                    case TagType.TAG_Int:
                        this.Value[i] = new TagInt(reader, false);
                        break;
                    case TagType.TAG_Long:
                        this.Value[i] = new TagLong(reader, false);
                        break;
                    case TagType.TAG_Float:
                        this.Value[i] = new TagFloat(reader, false);
                        break;
                    case TagType.TAG_Double:
                        this.Value[i] = new TagDouble(reader, false);
                        break;
                    case TagType.TAG_Byte_Array:
                        this.Value[i] = new TagByteArray(reader, false);
                        break;
                    case TagType.TAG_String:
                        this.Value[i] = new TagString(reader, false);
                        break;
                    case TagType.TAG_List:
                        this.Value[i] = new TagList(reader, false);
                        break;
                    case TagType.TAG_Compound:
                        this.Value[i] = new TagCompound(reader, false);
                        break;
                    case TagType.TAG_Int_Array:
                        this.Value[i] = new TagIntArray(reader, false);
                        break;
                    case TagType.TAG_Long_Array:
                        this.Value[i] = new TagLongArray(reader, false);
                        break;
                }
            }
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);
            writer.Write((byte)this.ListType);
            writer.Write(this.Value.Length);

            for (int i = 0; i < this.Value.Length; i++)
            {
                this.Value[i].Write(writer, false);
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
            T[] returnedValue = new T[this.Value.Length];
            for (int i = 0; i < returnedValue.Length; i++)
            {
                returnedValue[i] = (T)this.Value[i];
            }
            return returnedValue;
        }
    }
}