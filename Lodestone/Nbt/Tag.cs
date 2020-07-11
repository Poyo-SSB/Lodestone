using Lodestone.Utility;

namespace Lodestone.Nbt
{
    public abstract class Tag
    {
        public string Name { get; protected set; } = null;

        protected abstract void Read(EndiannessAwareBinaryReader reader, bool readName);
    }
}