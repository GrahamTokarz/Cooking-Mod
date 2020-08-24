using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.Buffs
{
	public class Milked : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Milked");
			Description.SetDefault("You cannot drink any milk");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;
			canBeCleared = false;
            
        }


        public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<CModPlayer>().milked = true;
        }
    }
}
