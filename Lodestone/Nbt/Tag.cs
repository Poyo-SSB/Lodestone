using Lodestone.Utility;
using System.Text;

namespace Lodestone.Nbt
{
    public abstract class Tag
    {
        public abstract TagType Type { get; }

        public string Name { get; protected set; } = null;

        public virtual void Read(EndiannessAwareBinaryReader reader, bool readName)
        {
            if (readName)
            {
                ushort nameLength = reader.ReadUInt16();
                this.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            }
        }

        public virtual void Write(EndiannessAwareBinaryWriter writer, bool writeName)
        {
            if (writeName)
            {
                writer.Write((byte)this.Type);
                writer.Write((ushort)this.Name.Length);
                writer.Write(Encoding.UTF8.GetBytes(this.Name));
            }
        }
    }
}