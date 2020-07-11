using Lodestone.Utility;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Lodestone.Nbt
{
    public class TagCompound : Tag
    {
        private readonly Dictionary<string, Tag> children = new Dictionary<string, Tag>();

        public int Count => this.children.Count;

        public TagCompound(string file)
        {
            byte[] bytes = File.ReadAllBytes(file);

            if (bytes[0] == 0x1f && bytes[1] == 0x8b)
            {
                bytes = DecompressGzip(bytes);
            }

            var reader = new EndiannessAwareBinaryReader(new MemoryStream(bytes), Endianness.Big);

            var type = (TagType)reader.ReadByte();
            if (type != TagType.TAG_Compound)
            {
                throw new InvalidDataException("Data does not represent a compound tag.");
            }

            this.Read(reader, true);
        }

        public TagCompound(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        protected override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }

            TagType nextType;
            while ((nextType = (TagType)reader.ReadByte()) != TagType.TAG_End)
            {
                Tag nextTag = null;
                switch (nextType)
                {
                    case TagType.TAG_Byte:
                        nextTag = new TagByte(reader, true);
                        break;
                    case TagType.TAG_Short:
                        nextTag = new TagShort(reader, true);
                        break;
                    case TagType.TAG_Int:
                        nextTag = new TagInt(reader, true);
                        break;
                    case TagType.TAG_Long:
                        nextTag = new TagLong(reader, true);
                        break;
                    case TagType.TAG_Float:
                        nextTag = new TagFloat(reader, true);
                        break;
                    case TagType.TAG_Double:
                        nextTag = new TagDouble(reader, true);
                        break;
                    case TagType.TAG_Byte_Array:
                        nextTag = new TagByteArray(reader, true);
                        break;
                    case TagType.TAG_String:
                        nextTag = new TagString(reader, true);
                        break;
                    case TagType.TAG_List:
                        nextTag = new TagList(reader, true);
                        break;
                    case TagType.TAG_Compound:
                        nextTag = new TagCompound(reader, true);
                        break;
                    case TagType.TAG_Int_Array:
                        nextTag = new TagIntArray(reader, true);
                        break;
                    case TagType.TAG_Long_Array:
                        nextTag = new TagLongArray(reader, true);
                        break;
                }

                this.children.Add(nextTag.Name, nextTag);
            }
        }

        public TagByte GetByte(string name) => (TagByte)this.children[name];
        public TagShort GetShort(string name) => (TagShort)this.children[name];
        public TagInt GetInt(string name) => (TagInt)this.children[name];
        public TagLong GetLong(string name) => (TagLong)this.children[name];
        public TagFloat GetFloat(string name) => (TagFloat)this.children[name];
        public TagDouble GetDouble(string name) => (TagDouble)this.children[name];
        public TagByteArray GetByteArray(string name) => (TagByteArray)this.children[name];
        public TagString GetString(string name) => (TagString)this.children[name];
        public TagList GetList(string name) => (TagList)this.children[name];
        public TagCompound GetCompound(string name) => (TagCompound)this.children[name];
        public TagIntArray GetIntArray(string name) => (TagIntArray)this.children[name];
        public TagLongArray GetLongArray(string name) => (TagLongArray)this.children[name];

        private static byte[] DecompressGzip(byte[] data)
        {
            using var compressedStream = new MemoryStream(data);
            using var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress);
            using var resultStream = new MemoryStream();
            zipStream.CopyTo(resultStream);
            return resultStream.ToArray();
        }
    }
}
