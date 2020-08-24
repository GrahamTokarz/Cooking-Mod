using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.Items
{
  public class CocoaBean : ModItem
  {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Fresh Cocoa Bean");
      Tooltip.SetDefault("Can be used to make chocolate items.");
    }

    public override void SetDefaults(){
      item.value = Item.buyPrice(silver: 3);
      item.rare = 2;
      item.maxStack = 999;
    }

    public override void AddRecipes() {
      ModRecipe recipe = new ModRecipe(mod);
      recipe.AddIngredient(this, 2);
      recipe.AddIngredient(mod, "Milk");
      recipe.SetResult(mod, "ChocolateMilk");
      recipe.AddRecipe();
    }
  }
}
