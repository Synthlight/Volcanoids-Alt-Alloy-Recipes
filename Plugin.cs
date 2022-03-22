using System.Linq;
using Base_Mod;
using JetBrains.Annotations;

namespace Alt_Alloy_Recipes {
    [UsedImplicitly]
    public class Plugin : BaseGameMod {
        public static readonly GUID   ALLOY_T1_INGOT_RECIPE = GUID.Parse("f987923c08634394eb5168b9ed24d11e");
        public static readonly GUID   ALLOY_T2_INGOT_RECIPE = GUID.Parse("028b727348fe8c04cbb0691e1351a62c");
        public static readonly GUID   ALLOY_T3_INGOT_RECIPE = GUID.Parse("ae753dbb75885b649be7f3590520bf2c");
        public static readonly GUID   COPPER_INGOT          = GUID.Parse("9386d447191c7aa4fa913943abd75481");
        public static readonly GUID   IRON_ORE              = GUID.Parse("8184e2f7fbec373469f650ff3febcf99");
        public static readonly GUID   IRON_INGOT            = GUID.Parse("f74e4356dcd38b7418a666b63c0304b1");
        public static readonly GUID   TITANIUM_ORE          = GUID.Parse("3d4fce1d9e298384ea12a6e66fa92ba2");
        public static readonly GUID   TITANIUM_INGOT        = GUID.Parse("c3d1b45a69512824fbade5378c5a4a52");
        public static readonly GUID   ALLOY_T1_ALT_1        = GUID.Parse("4a11d8231955459ca68f889443ee1f57");
        private const          string ALLOY_T1_ALT_1_NAME   = "AlloyT1Alt1";
        public static readonly GUID   ALLOY_T1_ALT_2        = GUID.Parse("72160044f2f54e20ab17527b64c6fe33");
        private const          string ALLOY_T1_ALT_2_NAME   = "AlloyT1Alt2";
        public static readonly GUID   ALLOY_T2_ALT_1        = GUID.Parse("9d5f193478c547b9a38f5d26e28ce5a1");
        private const          string ALLOY_T2_ALT_1_NAME   = "AlloyT2Alt1";
        public static readonly GUID   ALLOY_T2_ALT_2        = GUID.Parse("1c33dd100b464839a27a0a3557d86081");
        private const          string ALLOY_T2_ALT_2_NAME   = "AlloyT2Alt2";
        public static readonly GUID   ALLOY_T3_ALT_1        = GUID.Parse("793a5863cdb44f8abd6c81c6073019c1");
        private const          string ALLOY_T3_ALT_1_NAME   = "AlloyT3Alt1";

        public override void OnInitData() {
            var alloyT1       = RuntimeAssetDatabase.Get<Recipe>().First(def => def.AssetId == ALLOY_T1_INGOT_RECIPE);
            var alloyT2       = RuntimeAssetDatabase.Get<Recipe>().First(def => def.AssetId == ALLOY_T2_INGOT_RECIPE);
            var alloyT3       = RuntimeAssetDatabase.Get<Recipe>().First(def => def.AssetId == ALLOY_T3_INGOT_RECIPE);
            var copperIngot   = RuntimeAssetDatabase.Get<ItemDefinition>().First(def => def.AssetId == COPPER_INGOT);
            var ironOre       = RuntimeAssetDatabase.Get<ItemDefinition>().First(def => def.AssetId == IRON_ORE);
            var ironIngot     = RuntimeAssetDatabase.Get<ItemDefinition>().First(def => def.AssetId == IRON_INGOT);
            var titaniumOre   = RuntimeAssetDatabase.Get<ItemDefinition>().First(def => def.AssetId == TITANIUM_ORE);
            var titaniumIngot = RuntimeAssetDatabase.Get<ItemDefinition>().First(def => def.AssetId == TITANIUM_INGOT);

            var builder = RecipeBuilder.FromRecipe(alloyT1);
            builder.SetGuid(ALLOY_T1_ALT_1)
                   .SetName(ALLOY_T1_ALT_1_NAME)
                   .UpdateInputItems(copperIngot, ironOre)
                   .Build()
                   .AddToAssetDatabase();
            builder.SetGuid(ALLOY_T1_ALT_2)
                   .SetName(ALLOY_T1_ALT_2_NAME)
                   .UpdateInputItems(copperIngot, ironIngot)
                   .Build()
                   .AddToAssetDatabase();

            builder = RecipeBuilder.FromRecipe(alloyT2);
            builder.SetGuid(ALLOY_T2_ALT_1)
                   .SetName(ALLOY_T2_ALT_1_NAME)
                   .UpdateInputItems(ironIngot, titaniumOre)
                   .Build()
                   .AddToAssetDatabase();
            builder.SetGuid(ALLOY_T2_ALT_2)
                   .SetName(ALLOY_T2_ALT_2_NAME)
                   .UpdateInputItems(ironIngot, titaniumIngot)
                   .Build()
                   .AddToAssetDatabase();

            // T3 doesn't have a secondary resource.
            builder = RecipeBuilder.FromRecipe(alloyT3);
            builder.SetGuid(ALLOY_T3_ALT_1)
                   .SetName(ALLOY_T3_ALT_1_NAME)
                   .UpdateInputItems(titaniumIngot)
                   .Build()
                   .AddToAssetDatabase();

            base.OnInitData();
        }
    }
}