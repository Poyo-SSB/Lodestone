using Lodestone.Nbt;

namespace Lodestone.Structures.Level
{
    public class WorldBorder
    {
        private const string center_x_string = "BorderCenterX";
        private const string center_z_string = "BorderCenterZ";
        private const string damage_per_block_string = "BorderDamagePerBlock";
        private const string size_string = "BorderSize";
        private const string safe_zone_string = "BorderSafeZone";
        private const string size_lerp_target_string = "BorderSizeLerpTarget";
        private const string size_lerp_time_string = "BorderSizeLerpTime";
        private const string warning_blocks_string = "BorderWarningBlocks";
        private const string warning_time_string = "BorderWarningTime";

        private readonly TagCompound data;
        public WorldBorder(TagCompound data) => this.data = data;

        public double CenterX
        {
            get => this.data.GetDouble(center_x_string).Value;
            set => this.data.SetDouble(center_x_string, value);
        }

        public double CenterZ
        {
            get => this.data.GetDouble(center_z_string).Value;
            set => this.data.SetDouble(center_z_string, value);
        }

        public double DamagePerBlock
        {
            get => this.data.GetDouble(damage_per_block_string).Value;
            set => this.data.SetDouble(damage_per_block_string, value);
        }

        public double Size
        {
            get => this.data.GetDouble(size_string).Value;
            set => this.data.SetDouble(size_string, value);
        }

        public double SafeZone
        {
            get => this.data.GetDouble(safe_zone_string).Value;
            set => this.data.SetDouble(safe_zone_string, value);
        }

        public double SizeLerpTarget
        {
            get => this.data.GetDouble(size_lerp_target_string).Value;
            set => this.data.SetDouble(size_lerp_target_string, value);
        }

        public long SizeLerpTime
        {
            get => this.data.GetLong(size_lerp_time_string).Value;
            set => this.data.SetLong(size_lerp_time_string, value);
        }

        public double WarningBlocks
        {
            get => this.data.GetDouble(warning_blocks_string).Value;
            set => this.data.SetDouble(warning_blocks_string, value);
        }

        public double WarningTime
        {
            get => this.data.GetDouble(warning_time_string).Value;
            set => this.data.SetDouble(warning_time_string, value);
        }
    }
}