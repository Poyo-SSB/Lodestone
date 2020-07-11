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

        public override short ReadInt16() => BitConverter.ToInt16(this.ReadWithEndianness(sizeof(short), this.endianness));
        public override int ReadInt32() => BitConverter.ToInt32(this.ReadWithEndianness(sizeof(int), this.endianness));
        public override long ReadInt64() => BitConverter.ToInt64(this.ReadWithEndianness(sizeof(long), this.endianness));
        public override ushort ReadUInt16() => BitConverter.ToUInt16(this.ReadWithEndianness(sizeof(ushort), this.endianness));
        public override uint ReadUInt32() => BitConverter.ToUInt32(this.ReadWithEndianness(sizeof(uint), this.endianness));
        public override ulong ReadUInt64() => BitConverter.ToUInt64(this.ReadWithEndianness(sizeof(ulong), this.endianness));
        public override float ReadSingle() => BitConverter.ToSingle(this.ReadWithEndianness(sizeof(float), this.endianness));
        public override double ReadDouble() => BitConverter.ToDouble(this.ReadWithEndianness(sizeof(double), this.endianness));

        private byte[] ReadWithEndianness(int bytesToRead, Endianness endianness)
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
