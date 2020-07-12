using Lodestone.Nbt;
using NUnit.Framework;
using System.IO;

namespace Lodestone.Tests
{
    [TestFixture]
    public class NbtTests
    {
        [Test]
        public void NbtReadTest()
        {
            this.TestNbt(new TagCompound(@"./Resources/test.dat"));
            this.TestNbt(new TagCompound(@"./Resources/test_gzip.dat"));
        }

        [Test]
        public void NbtWriteTest()
        {
            using (var stream = File.Open(@"./Resources/test_write.dat", FileMode.Create))
            {
                new TagCompound(@"./Resources/test.dat").Write(stream);
            }
            this.TestNbt(new TagCompound(@"./Resources/test_write.dat"));
        }

        private void TestNbt(TagCompound compoundTag)
        {
            var byteMin = compoundTag.GetByte("byte_min");
            Assert.AreEqual(-128, byteMin.Value);
            var byteMax = compoundTag.GetByte("byte_max");
            Assert.AreEqual(127, byteMax.Value);

            var shortMin = compoundTag.GetShort("short_min");
            Assert.AreEqual(-32768, shortMin.Value);
            var shortMax = compoundTag.GetShort("short_max");
            Assert.AreEqual(32767, shortMax.Value);

            var intMin = compoundTag.GetInt("int_min");
            Assert.AreEqual(-2147483648, intMin.Value);
            var intMax = compoundTag.GetInt("int_max");
            Assert.AreEqual(2147483647, intMax.Value);

            var longMin = compoundTag.GetLong("long_min");
            Assert.AreEqual(-9223372036854775808, longMin.Value);
            var longMax = compoundTag.GetLong("long_max");
            Assert.AreEqual(9223372036854775807, longMax.Value);

            var floatTag = compoundTag.GetFloat("float");
            Assert.AreEqual(12345.6f, floatTag.Value);

            var doubleTag = compoundTag.GetDouble("double");
            Assert.AreEqual(12345.6, doubleTag.Value);

            var byteArray = compoundTag.GetByteArray("byte_array");
            Assert.AreEqual(3, byteArray.Value.Length);
            Assert.AreEqual(0x12, byteArray.Value[0]);
            Assert.AreEqual(0x34, byteArray.Value[1]);
            Assert.AreEqual(0x56, byteArray.Value[2]);

            var stringTag = compoundTag.GetString("string");
            Assert.AreEqual("hello!", stringTag.Value);

            var list = compoundTag.GetList("string_list");
            var listValue = list.GetArrayString();
            Assert.AreEqual(3, listValue.Length);
            Assert.AreEqual("i'm in an array!", listValue[0].Value);
            Assert.AreEqual("i am also in an array!", listValue[1].Value);
            Assert.AreEqual("walter", listValue[2].Value);

            var emptyList = compoundTag.GetList("empty_list");
            var emptyListValue = emptyList.GetArrayByte();
            Assert.AreEqual(0, emptyListValue.Length);

            var listList = compoundTag.GetList("list_list");
            var listListValue = listList.GetArrayList();
            Assert.AreEqual(3, listListValue.Length);
            var listListValue0 = listListValue[0].GetArrayFloat();
            Assert.AreEqual(3, listListValue0.Length);
            Assert.AreEqual(1.1f, listListValue0[0].Value);
            Assert.AreEqual(2.2f, listListValue0[1].Value);
            Assert.AreEqual(3.3f, listListValue0[2].Value);
            var listListValue1 = listListValue[1].GetArrayDouble();
            Assert.AreEqual(3, listListValue1.Length);
            Assert.AreEqual(4.4, listListValue1[0].Value);
            Assert.AreEqual(5.5, listListValue1[1].Value);
            Assert.AreEqual(6.6, listListValue1[2].Value);
            var listListValue2 = listListValue[2].GetArrayString();
            Assert.AreEqual(3, listListValue2.Length);
            Assert.AreEqual("wa", listListValue2[0].Value);
            Assert.AreEqual("ta", listListValue2[1].Value);
            Assert.AreEqual("shi", listListValue2[2].Value);

            var compound = compoundTag.GetCompound("compound");
            Assert.AreEqual(3, compound.Count);
            Assert.AreEqual(123, compound.GetByte("compound_byte").Value);
            Assert.AreEqual(694201337, compound.GetInt("compound_int").Value);
            Assert.AreEqual("*holds a gun to your temple*", compound.GetString("compound_string").Value);

            var emptyCompound = compoundTag.GetCompound("empty_compound");
            Assert.AreEqual(0, emptyCompound.Count);

            var intArray = compoundTag.GetIntArray("int_array");
            Assert.AreEqual(4, intArray.Value.Length);
            Assert.AreEqual(69, intArray.Value[0]);
            Assert.AreEqual(420, intArray.Value[1]);
            Assert.AreEqual(1337, intArray.Value[2]);
            Assert.AreEqual(117, intArray.Value[3]);

            var longArray = compoundTag.GetLongArray("long_array");
            Assert.AreEqual(4, longArray.Value.Length);
            Assert.AreEqual(69, longArray.Value[0]);
            Assert.AreEqual(420, longArray.Value[1]);
            Assert.AreEqual(1337, longArray.Value[2]);
            Assert.AreEqual(117, longArray.Value[3]);
        }
    }
}