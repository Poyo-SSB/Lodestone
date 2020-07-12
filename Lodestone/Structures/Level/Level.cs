using Lodestone.Nbt;
using System.IO;
using System.IO.Compression;

namespace Lodestone.Structures.Level
{
    public class Level
    {
        private const string level_dat_path = "level.dat";

        private const string allow_commands_string = "allowCommands";
        private const string clear_weather_time_string = "clearWeatherTime";
        private const string time_string = "DayTime";
        private const string data_version_string = "DataVersion";
        private const string difficulty_string = "Difficulty";
        private const string difficulty_locked_string = "DifficultyLocked";

        private string path => Path.Combine(this.directory, level_dat_path);

        public readonly TagCompound LevelDat;
        private readonly string directory;

        public readonly GameRules GameRules;
        public readonly WorldBorder WorldBorder;

        public bool AllowCommands
        {
            get => this.LevelDat.GetByte(allow_commands_string).Value == 1;
            set => this.LevelDat.SetByte(allow_commands_string, value ? (sbyte)1 : (sbyte)0);
        }

        public int ClearWeatherTime
        {
            get => this.LevelDat.GetInt(clear_weather_time_string).Value;
            set => this.LevelDat.SetInt(clear_weather_time_string, value);
        }

        public int Time
        {
            get => this.LevelDat.GetInt(time_string).Value;
            set => this.LevelDat.SetInt(time_string, value);
        }

        public int DataVersion
        {
            get => this.LevelDat.GetInt(data_version_string).Value;
            set => this.LevelDat.SetInt(data_version_string, value);
        }

        public Difficulty Difficulty
        {
            get => (Difficulty)this.LevelDat.GetByte(difficulty_string).Value;
            set => this.LevelDat.SetByte(difficulty_string, (sbyte)value);
        }

        public bool DifficultyLocked
        {
            get => this.LevelDat.GetByte(difficulty_locked_string).Value == 1;
            set => this.LevelDat.SetByte(difficulty_locked_string, value ? (sbyte)1 : (sbyte)0);
        }

        public Level(string directory)
        {
            this.directory = directory;
            this.LevelDat = new TagCompound(this.path);
            this.GameRules = new GameRules(this.LevelDat.GetCompound("Data").GetCompound("GameRules"));
            this.WorldBorder = new WorldBorder(this.LevelDat.GetCompound("Data"));
        }

        public void Save()
        {
            using var fileStream = File.Open(this.path, FileMode.Create);
            using var gzipStream = new GZipStream(fileStream, CompressionMode.Compress);
            this.LevelDat.Write(gzipStream);
        }
    }
}
