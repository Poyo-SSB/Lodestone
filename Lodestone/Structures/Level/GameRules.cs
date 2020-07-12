using Lodestone.Nbt;
using System;

namespace Lodestone.Structures.Level
{
    public class GameRules
    {
        private const string announce_advancements_string = "announceAdvancements";
        private const string command_block_output_string = "commandBlockOutput";
        private const string disable_elytra_movement_check_string = "disableElytraMovementCheck";
        private const string disable_raids_string = "disableRaids";
        private const string do_daylight_cycle_string = "doDaylightCycle";
        private const string do_entity_drops_string = "doEntityDrops";
        private const string do_fire_tick_string = "doFireTick";
        private const string do_insomnia_string = "doInsomnia";
        private const string do_immediate_respawn_string = "doImmediateRespawn";
        private const string do_limited_crafting_string = "doLimitedCrafting";
        private const string do_mob_loot_string = "doMobLoot";
        private const string do_mob_spawning_string = "doMobSpawning";
        private const string do_patrol_spawning_string = "doPatrolSpawning";
        private const string do_tile_drops_string = "doTileDrops";
        private const string do_trader_spawning_string = "doTraderSpawning";
        private const string do_weather_cycle_string = "doWeatherCycle";
        private const string drowning_damage_string = "drowningDamage";
        private const string fall_damage_string = "fallDamage";
        private const string fire_damage_string = "fireDamage";
        private const string forgive_dead_players_string = "forgiveDeadPlayers";
        private const string keep_inventory_string = "keepInventory";
        private const string log_admin_commands_string = "logAdminCommands";
        private const string max_command_chain_length_string = "maxCommandChainLength";
        private const string max_entity_cramming_string = "maxEntityCramming";
        private const string mob_griefing_string = "mobGriefing";
        private const string natural_regeneration_string = "naturalRegeneration";
        private const string random_tick_speed_string = "randomTickSpeed";
        private const string reduced_debug_info_string = "reducedDebugInfo";
        private const string send_command_feedback_string = "sendCommandFeedback";
        private const string show_death_messages_string = "showDeathMessages";
        private const string spawn_radius_string = "spawnRadius";
        private const string spectators_generate_chunks_string = "spectatorsGenerateChunks";
        private const string universal_anger_string = "universalAnger";

        private readonly TagCompound gameRules;
        public GameRules(TagCompound gameRules) => this.gameRules = gameRules;

        public bool AnnounceAdvancements
        {
            get => this.gameRules.GetString(announce_advancements_string).Value == "true";
            set => this.gameRules.SetString(announce_advancements_string, value.ToString());
        }

        public bool CommandBlockOutput
        {
            get => this.gameRules.GetString(command_block_output_string).Value == "true";
            set => this.gameRules.SetString(command_block_output_string, value.ToString());
        }

        public bool DisableElytraMovementCheck
        {
            get => this.gameRules.GetString(disable_elytra_movement_check_string).Value == "true";
            set => this.gameRules.SetString(disable_elytra_movement_check_string, value.ToString());
        }

        public bool DisableRaids
        {
            get => this.gameRules.GetString(disable_raids_string).Value == "true";
            set => this.gameRules.SetString(disable_raids_string, value.ToString());
        }

        public bool DoDaylightCycle
        {
            get => this.gameRules.GetString(do_daylight_cycle_string).Value == "true";
            set => this.gameRules.SetString(do_daylight_cycle_string, value.ToString());
        }

        public bool DoEntityDrops
        {
            get => this.gameRules.GetString(do_entity_drops_string).Value == "true";
            set => this.gameRules.SetString(do_entity_drops_string, value.ToString());
        }

        public bool DoFireTick
        {
            get => this.gameRules.GetString(do_fire_tick_string).Value == "true";
            set => this.gameRules.SetString(do_fire_tick_string, value.ToString());
        }

        public bool DoInsomnia
        {
            get => this.gameRules.GetString(do_insomnia_string).Value == "true";
            set => this.gameRules.SetString(do_insomnia_string, value.ToString());
        }

        public bool DoImmediateRespawn
        {
            get => this.gameRules.GetString(do_immediate_respawn_string).Value == "true";
            set => this.gameRules.SetString(do_immediate_respawn_string, value.ToString());
        }

        public bool DoLimitedCrafting
        {
            get => this.gameRules.GetString(do_limited_crafting_string).Value == "true";
            set => this.gameRules.SetString(do_limited_crafting_string, value.ToString());
        }

        public bool DoMobLoot
        {
            get => this.gameRules.GetString(do_mob_loot_string).Value == "true";
            set => this.gameRules.SetString(do_mob_loot_string, value.ToString());
        }

        public bool DoMobSpawning
        {
            get => this.gameRules.GetString(do_mob_spawning_string).Value == "true";
            set => this.gameRules.SetString(do_mob_spawning_string, value.ToString());
        }

        public bool DoPatrolSpawning
        {
            get => this.gameRules.GetString(do_patrol_spawning_string).Value == "true";
            set => this.gameRules.SetString(do_patrol_spawning_string, value.ToString());
        }

        public bool DoTileDrops
        {
            get => this.gameRules.GetString(do_tile_drops_string).Value == "true";
            set => this.gameRules.SetString(do_tile_drops_string, value.ToString());
        }

        public bool DoTraderSpawning
        {
            get => this.gameRules.GetString(do_trader_spawning_string).Value == "true";
            set => this.gameRules.SetString(do_trader_spawning_string, value.ToString());
        }

        public bool DoWeatherCycle
        {
            get => this.gameRules.GetString(do_weather_cycle_string).Value == "true";
            set => this.gameRules.SetString(do_weather_cycle_string, value.ToString());
        }

        public bool DrowningDamage
        {
            get => this.gameRules.GetString(drowning_damage_string).Value == "true";
            set => this.gameRules.SetString(drowning_damage_string, value.ToString());
        }

        public bool FallDamage
        {
            get => this.gameRules.GetString(fall_damage_string).Value == "true";
            set => this.gameRules.SetString(fall_damage_string, value.ToString());
        }

        public bool FireDamage
        {
            get => this.gameRules.GetString(fire_damage_string).Value == "true";
            set => this.gameRules.SetString(fire_damage_string, value.ToString());
        }

        public bool ForgiveDeadPlayers
        {
            get => this.gameRules.GetString(forgive_dead_players_string).Value == "true";
            set => this.gameRules.SetString(forgive_dead_players_string, value.ToString());
        }

        public bool KeepInventory
        {
            get => this.gameRules.GetString(keep_inventory_string).Value == "true";
            set => this.gameRules.SetString(keep_inventory_string, value.ToString());
        }

        public bool LogAdminCommands
        {
            get => this.gameRules.GetString(log_admin_commands_string).Value == "true";
            set => this.gameRules.SetString(log_admin_commands_string, value.ToString());
        }

        public int MaxCommandChainLength
        {
            get => Int32.Parse(this.gameRules.GetString(max_command_chain_length_string).Value);
            set => this.gameRules.SetString(max_command_chain_length_string, value.ToString());
        }

        public int MaxEntityCramming
        {
            get => Int32.Parse(this.gameRules.GetString(max_entity_cramming_string).Value);
            set => this.gameRules.SetString(max_entity_cramming_string, value.ToString());
        }

        public bool MobGriefing
        {
            get => this.gameRules.GetString(mob_griefing_string).Value == "true";
            set => this.gameRules.SetString(mob_griefing_string, value.ToString());
        }

        public bool NaturalRegeneration
        {
            get => this.gameRules.GetString(natural_regeneration_string).Value == "true";
            set => this.gameRules.SetString(natural_regeneration_string, value.ToString());
        }

        public int RandomTickSpeed
        {
            get => Int32.Parse(this.gameRules.GetString(random_tick_speed_string).Value);
            set => this.gameRules.SetString(random_tick_speed_string, value.ToString());
        }

        public bool ReducedDebugInfo
        {
            get => this.gameRules.GetString(reduced_debug_info_string).Value == "true";
            set => this.gameRules.SetString(reduced_debug_info_string, value.ToString());
        }

        public bool SendCommandFeedback
        {
            get => this.gameRules.GetString(send_command_feedback_string).Value == "true";
            set => this.gameRules.SetString(send_command_feedback_string, value.ToString());
        }

        public bool ShowDeathMessages
        {
            get => this.gameRules.GetString(show_death_messages_string).Value == "true";
            set => this.gameRules.SetString(show_death_messages_string, value.ToString());
        }

        public int SpawnRadius
        {
            get => Int32.Parse(this.gameRules.GetString(spawn_radius_string).Value);
            set => this.gameRules.SetString(spawn_radius_string, value.ToString());
        }

        public bool SpectatorsGenerateChunks
        {
            get => this.gameRules.GetString(spectators_generate_chunks_string).Value == "true";
            set => this.gameRules.SetString(spectators_generate_chunks_string, value.ToString());
        }

        public bool UniversalAnger
        {
            get => this.gameRules.GetString(universal_anger_string).Value == "true";
            set => this.gameRules.SetString(universal_anger_string, value.ToString());
        }

    }
}