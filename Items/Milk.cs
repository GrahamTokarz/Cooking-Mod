using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.Items
{
	public class Milk : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fresh, delicious milk.");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 999;
			item.rare = 1;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.healLife = 50;
			item.potion = false;
			item.value = Item.buyPrice(silver: 1);
			item.buffType = mod.BuffType("Milked");
		}

		/**
		public void GetHealLife(Player player, ref int healValue){
			healValue = player.statLifeMax2 / 4;
		}
		**/

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle, 2);
			recipe.AddTile(mod, "Pasture");
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0 && player.FindBuffIndex(item.buffType) == -1) {
				item.consumable = true;
                item.healLife = 50;
				player.AddBuff(item.buffType, 1350, true);
			}
            else {
                item.consumable = false;
                item.healLife = 0;
            }
        }

	}
}
