namespace Lodestone.Nbt
{
    public enum TagType : byte
    {
        /// <summary>
        /// Used to mark the end of compound tags. This tag does not have a name, so it is only ever a single byte 0. It may also be the type of empty List tags.
        /// </summary>
        TAG_End = 0,

        /// <summary>
        /// A signed integral type. Sometimes used for booleans.
        /// </summary>
        TAG_Byte = 1,

        /// <summary>
        /// A signed integral type.
        /// </summary>
        TAG_Short = 2,

        /// <summary>
        /// A signed integral type.
        /// </summary>
        TAG_Int = 3,

        /// <summary>
        /// A signed integral type.
        /// </summary>
        TAG_Long = 4,

        /// <summary>
        /// A signed floating point type.
        /// </summary>
        TAG_Float = 5,

        /// <summary>
        /// A signed floating point type.
        /// </summary>
        TAG_Double = 6,

        /// <summary>
        /// An array of bytes.
        /// </summary>
        TAG_Byte_Array = 7,

        /// <summary>
        /// A UTF-8 string. It has a size, rather than being null terminated.
        /// </summary>
        TAG_String = 8,

        /// <summary>
        /// A list of tag payloads, without repeated tag IDs or any tag names.
        /// </summary>
        TAG_List = 9,

        /// <summary>
        /// A list of fully formed tags, including their IDs, names, and payloads. No two tags may have the same name.
        /// </summary>
        TAG_Compound = 10,

        /// <summary>
        /// An array of TAG_Int's payloads.
        /// </summary>
        TAG_Int_Array = 11,

        /// <summary>
        /// An array of TAG_Long's payloads.
        /// </summary>
        TAG_Long_Array = 12
    }
}
