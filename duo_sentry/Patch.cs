using System.Timers;
using CG.Game;
using HarmonyLib;

namespace duo_sentry
{
    [HarmonyPatch(typeof(Gameplay.Utilities.SinglePlayerModRule), "ShouldApply")]
    internal class SinglePlayerModRulePatch
    {
        // Store GUID as static variable
        public static GUIDUnion destroyerShipGUID = new GUIDUnion("4bc2ff9e1d156c94a9c94286a7aaa79b");
        static void Postfix(ref bool __result)
        {
            // Check if the current ship is Destroyer and two players active
            if (ClientGame.Current.playerShip.assetGuid == destroyerShipGUID && ClientGame.Current.Players.Count == 2)
            {
                __result = true; // Apply the rule if there are 2 players
                BepinPlugin.Log.LogInfo("Patch executed: Found two players on the Destroyer.");
            }
            
        }
    }
}