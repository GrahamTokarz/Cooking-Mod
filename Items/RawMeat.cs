using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.Items
{
	public class RawMeat : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Raw Meat");
			Tooltip.SetDefault("This looks disgusting... and a bit unhealthy.");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 100;
			item.rare = 1;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.potion = false;
			item.value = Item.buyPrice(silver: 1);
			item.buffType = mod.BuffType("Poisoned");
		}

		public void GetHealLife(Player player, ref int healValue){
			healValue = player.statLifeMax2 / 4;
		}

		public override void AddRecipes() {
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer) {
                item.consumable = true;
				player.AddBuff(20, 900, true);
			}
		}

	}
}
