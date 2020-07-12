using Lodestone.Utility;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Lodestone.Nbt
{
    public class TagCompound : Tag
    {
        private readonly Dictionary<string, Tag> entries = new Dictionary<string, Tag>();

        public override TagType Type => TagType.TAG_Compound;
        public int Count => this.entries.Count;

        public TagCompound(string file)
        {
            byte[] bytes = File.ReadAllBytes(file);

            if (bytes[0] == 0x1f && bytes[1] == 0x8b)
            {
                bytes = DecompressGzip(bytes);
            }

            using var reader = new EndiannessAwareBinaryReader(new MemoryStream(bytes), Endianness.Big);

            var type = (TagType)reader.ReadByte();
            if (type != TagType.TAG_Compound)
            {
                throw new InvalidDataException("Data does not represent a compound tag.");
            }

            this.Read(reader, true);
        }

        public TagCompound(EndiannessAwareBinaryReader reader, bool readNames) => this.Read(reader, readNames);

        public override void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            base.Read(reader, readName);

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

                this.entries.Add(nextTag.Name, nextTag);
            }
        }

        public override void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            base.Write(writer, writeName);

            foreach (var child in this.entries)
            {
                child.Value.Write(writer, true);
            }

            writer.Write((byte)TagType.TAG_End);
        }

        public void Write(Stream stream)
        {
            using var writer = new EndiannessAwareBinaryWriter(stream, Endianness.Big);
            this.Write(writer, true);
        }

        public TagByte GetByte(string name) => (TagByte)this.entries[name];
        public TagShort GetShort(string name) => (TagShort)this.entries[name];
        public TagInt GetInt(string name) => (TagInt)this.entries[name];
        public TagLong GetLong(string name) => (TagLong)this.entries[name];
        public TagFloat GetFloat(string name) => (TagFloat)this.entries[name];
        public TagDouble GetDouble(string name) => (TagDouble)this.entries[name];
        public TagByteArray GetByteArray(string name) => (TagByteArray)this.entries[name];
        public TagString GetString(string name) => (TagString)this.entries[name];
        public TagList GetList(string name) => (TagList)this.entries[name];
        public TagCompound GetCompound(string name) => (TagCompound)this.entries[name];
        public TagIntArray GetIntArray(string name) => (TagIntArray)this.entries[name];
        public TagLongArray GetLongArray(string name) => (TagLongArray)this.entries[name];

        public TagByte SetByte(string name, sbyte value)
        {
            TagByte tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagByte(name, value);
            }
            else
            {
                tag = this.GetByte(name);
                tag.Value = value;
            }

            return tag;
        }

        public TagShort SetShort(string name, short value)
        {
            TagShort tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagShort(name, value);
            }
            else
            {
                tag = this.GetShort(name);
                tag.Value = value;
            }

            return tag;
        }

        public TagInt SetInt(string name, int value)
        {
            TagInt tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagInt(name, value);
            }
            else
            {
                tag = this.GetInt(name);
                tag.Value = value;
            }

            return tag;
        }

        public TagLong SetLong(string name, long value)
        {
            TagLong tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagLong(name, value);
            }
            else
            {
                tag = this.GetLong(name);
                tag.Value = value;
            }

            return tag;
        }

        public TagFloat SetFloat(string name, float value)
        {
            TagFloat tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagFloat(name, value);
            }
            else
            {
                tag = this.GetFloat(name);
                tag.Value = value;
            }

            return tag;
        }

        public TagDouble SetDouble(string name, double value)
        {
            TagDouble tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagDouble(name, value);
            }
            else
            {
                tag = this.GetDouble(name);
                tag.Value = value;
            }

            return tag;
        }

        public TagByteArray SetByteArray(string name, sbyte[] value)
        {
            TagByteArray tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagByteArray(name, value);
            }
            else
            {
                tag = this.GetByteArray(name);
                tag.Value = value;
            }

            return tag;
        }

        public TagString SetString(string name, string value)
        {
            TagString tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagString(name, value);
            }
            else
            {
                tag = this.GetString(name);
                tag.Value = value;
            }

            return tag;
        }

        public TagList SetList(string name, TagType type, Tag[] value)
        {
            TagList tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagList(name, type, value);
            }
            else
            {
                tag = this.GetList(name);
                tag.ListType = type;
                tag.Value = value;
            }

            return tag;
        }

        public TagCompound SetCompound(string name, TagCompound value)
        {
            this.entries[name] = value;
            return this.GetCompound(name);
        }

        public TagIntArray SetIntArray(string name, int[] value)
        {
            TagIntArray tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagIntArray(name, value);
            }
            else
            {
                tag = this.GetIntArray(name);
                tag.Value = value;
            }

            return tag;
        }

        public TagLongArray SetLongArray(string name, long[] value)
        {
            TagLongArray tag;
            if (!this.entries.ContainsKey(name))
            {
                this.entries[name] = tag = new TagLongArray(name, value);
            }
            else
            {
                tag = this.GetLongArray(name);
                tag.Value = value;
            }

            return tag;
        }

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
