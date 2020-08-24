using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace CookingMod
{
	class CookingMod : Mod
	{
        public static ModHotKey MilkHotkey;
		public CookingMod()
		{
		}

        public override void Load()
        {
            MilkHotkey = RegisterHotKey("Use Milk", "Q");
        }

        public override void Unload()
        {
            MilkHotkey = null;
        }
        public override void AddRecipeGroups()
	  {
	   RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Door", new int[]
	   {
	  	ItemID.WoodenDoor,
	    ItemID.EbonwoodDoor,
			ItemID.RichMahoganyDoor,
			ItemID.PearlwoodDoor,
			ItemID.CactusDoor,
			ItemID.FleshDoor,
			ItemID.MushroomDoor,
			ItemID.LivingWoodDoor,
			ItemID.BoneDoor,
			ItemID.SkywareDoor,
			ItemID.ShadewoodDoor,
			ItemID.LihzahrdDoor,
			ItemID.DungeonDoor,
			ItemID.LeadDoor,
			ItemID.IronDoor,
			ItemID.BlueDungeonDoor,
			ItemID.GreenDungeonDoor,
			ItemID.PinkDungeonDoor,
			ItemID.ObsidianDoor,
			ItemID.GlassDoor,
			ItemID.GoldenDoor,
			ItemID.HoneyDoor,
			ItemID.SteampunkDoor,
			ItemID.PumpkinDoor,
			ItemID.SpookyDoor,
			ItemID.PineDoor,
			ItemID.FrozenDoor,
			ItemID.DynastyDoor,
			ItemID.PalmWoodDoor,
			ItemID.BorealWoodDoor,
			ItemID.SlimeDoor,
			ItemID.MartianDoor,
			ItemID.MeteoriteDoor,
			ItemID.MarbleDoor,
			ItemID.GraniteDoor,
			ItemID.CrystalDoor
	  	});
	 	RecipeGroup.RegisterGroup("CookingMod:Doors", group);
		}
	}
}
