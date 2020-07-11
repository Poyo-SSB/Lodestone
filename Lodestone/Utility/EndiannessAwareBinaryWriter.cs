using System;
using System.IO;
using System.Text;

namespace Lodestone.Utility
{
    public class EndiannessAwareBinaryWriter : BinaryWriter
    {
        private readonly Endianness endianness = Endianness.Little;

        public EndiannessAwareBinaryWriter(Stream output) : base(output) { }
        public EndiannessAwareBinaryWriter(Stream output, Encoding encoding) : base(output, encoding) { }
        public EndiannessAwareBinaryWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen) { }
        public EndiannessAwareBinaryWriter(Stream output, Endianness endianness) : base(output) => this.endianness = endianness;
        public EndiannessAwareBinaryWriter(Stream output, Encoding encoding, Endianness endianness) : base(output, encoding) => this.endianness = endianness;
        public EndiannessAwareBinaryWriter(Stream output, Encoding encoding, bool leaveOpen, Endianness endianness) : base(output, encoding, leaveOpen) => this.endianness = endianness;

        public override void Write(short value) => this.WriteWithEndianness(BitConverter.GetBytes(value), this.endianness);
        public override void Write(int value) => this.WriteWithEndianness(BitConverter.GetBytes(value), this.endianness);
        public override void Write(long value) => this.WriteWithEndianness(BitConverter.GetBytes(value), this.endianness);
        public override void Write(ushort value) => this.WriteWithEndianness(BitConverter.GetBytes(value), this.endianness);
        public override void Write(uint value) => this.WriteWithEndianness(BitConverter.GetBytes(value), this.endianness);
        public override void Write(ulong value) => this.WriteWithEndianness(BitConverter.GetBytes(value), this.endianness);
        public override void Write(float value) => this.WriteWithEndianness(BitConverter.GetBytes(value), this.endianness);
        public override void Write(double value) => this.WriteWithEndianness(BitConverter.GetBytes(value), this.endianness);

        private void WriteWithEndianness(byte[] bytes, Endianness endianness)
        {
            if ((endianness == Endianness.Little && !BitConverter.IsLittleEndian)
                || (endianness == Endianness.Big && BitConverter.IsLittleEndian))
            {
                Array.Reverse(bytes);
            }

            this.Write(bytes);
        }
    }
}
