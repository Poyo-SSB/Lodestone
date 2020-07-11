﻿namespace Lodestone
{
    public class Chunk
    {
        public const int X_SIZE = 16;
        public const int Y_SIZE = 256;
        public const int Z_SIZE = 16;

        public int X { get; }
        public int Z { get; }

        internal Chunk(int x, int z)
        {
            this.X = x;
            this.Z = z;
        }
    }
}