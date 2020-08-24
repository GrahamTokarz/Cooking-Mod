using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.Items
{
	public class CookedMeat : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cooked Meat");
			Tooltip.SetDefault("");
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
			item.healLife = 75;
			item.potion = true;
			item.value = Item.buyPrice(silver: 5);
			}

		/**
		public void GetHealLife(Player player, ref int healValue){
			healValue = player.statLifeMax2 / 4;
		}
		**/

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "RawMeat", 2);
			recipe.AddTile(TileID.Campfire);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}


	}
}
