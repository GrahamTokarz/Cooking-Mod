using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.Items
{
	public class Egg : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Best kept cold.'");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 26;
			item.maxStack = 100;
			item.rare = 1;
			item.consumable = false;
			item.potion = false;
			item.value = Item.buyPrice(silver: 1);
		}

		/**
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle, 2);
			recipe.AddTile(mod, "Farm");
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
		**/
	}
}
