using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.Items
{
  public class CowCoin : ModItem
  {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Cow coin");
      Tooltip.SetDefault("Trade it to the farmer for a cow!");
    }

    public override void SetDefaults(){
      item.width = 14;
	  item.height = 14;
      item.value = 0;
      item.rare = 1;
      item.maxStack = 1;
    }

    // public override void AddRecipes() {
    //   ModRecipe recipe = new ModRecipe(mod);
    //   recipe.AddIngredient(this, 5);
    //   recipe.SetResult(mod, "CowItem");
    // }
  }
}
