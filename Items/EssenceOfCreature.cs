using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.Items
{
  public class EssenceOfCreature : ModItem
  {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Essence of Creature");
      Tooltip.SetDefault("Used to craft animal coins \nHas a 1/15 drop chance from everything");
    }

    public override void SetDefaults(){
      item.value = Item.buyPrice(silver: 1);
      item.rare = 1;
      item.maxStack = 100;
    }

    public override void AddRecipes() {
      ModRecipe recipe = new ModRecipe(mod);
      recipe.AddIngredient(this, 5);
      recipe.SetResult(mod, "CowCoin");
	  recipe.AddRecipe();
    }
  }
}
