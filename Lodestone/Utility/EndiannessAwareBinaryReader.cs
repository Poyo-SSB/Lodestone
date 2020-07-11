using System;
using System.IO;
using System.Text;

namespace Lodestone.Utility
{
    public class EndiannessAwareBinaryReader : BinaryReader
    {
        private readonly Endianness endianness = Endianness.Little;

        public EndiannessAwareBinaryReader(Stream input) : base(input) { }
        public EndiannessAwareBinaryReader(Stream input, Encoding encoding) : base(input, encoding) { }
        public EndiannessAwareBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen) { }
        public EndiannessAwareBinaryReader(Stream input, Endianness endianness) : base(input) => this.endianness = endianness;
        public EndiannessAwareBinaryReader(Stream input, Encoding encoding, Endianness endianness) : base(input, encoding) => this.endianness = endianness;
        public EndiannessAwareBinaryReader(Stream input, Encoding encoding, bool leaveOpen, Endianness endianness) : base(input, encoding, leaveOpen) => this.endianness = endianness;

        public override short ReadInt16() => this.ReadInt16(this.endianness);
        public override int ReadInt32() => this.ReadInt32(this.endianness);
        public override long ReadInt64() => this.ReadInt64(this.endianness);
        public override ushort ReadUInt16() => this.ReadUInt16(this.endianness);
        public override uint ReadUInt32() => this.ReadUInt32(this.endianness);
        public override ulong ReadUInt64() => this.ReadUInt64(this.endianness);
        public override float ReadSingle() => this.ReadSingle(this.endianness);
        public override double ReadDouble() => this.ReadDouble(this.endianness);

        public short ReadInt16(Endianness endianness) => BitConverter.ToInt16(this.ReadForEndianness(sizeof(short), endianness));
        public int ReadInt32(Endianness endianness) => BitConverter.ToInt32(this.ReadForEndianness(sizeof(int), endianness));
        public long ReadInt64(Endianness endianness) => BitConverter.ToInt64(this.ReadForEndianness(sizeof(long), endianness));
        public ushort ReadUInt16(Endianness endianness) => BitConverter.ToUInt16(this.ReadForEndianness(sizeof(ushort), endianness));
        public uint ReadUInt32(Endianness endianness) => BitConverter.ToUInt32(this.ReadForEndianness(sizeof(uint), endianness));
        public ulong ReadUInt64(Endianness endianness) => BitConverter.ToUInt64(this.ReadForEndianness(sizeof(ulong), endianness));
        public float ReadSingle(Endianness endianness) => BitConverter.ToSingle(this.ReadForEndianness(sizeof(float), endianness));
        public double ReadDouble(Endianness endianness) => BitConverter.ToDouble(this.ReadForEndianness(sizeof(double), endianness));

        private byte[] ReadForEndianness(int bytesToRead, Endianness endianness)
        {
            byte[] bytesRead = this.ReadBytes(bytesToRead);

            if ((endianness == Endianness.Little && !BitConverter.IsLittleEndian)
                || (endianness == Endianness.Big && BitConverter.IsLittleEndian))
            {
                Array.Reverse(bytesRead);
            }

            return bytesRead;
        }
    }
}
