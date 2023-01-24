using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace admintrader.src {
    public class Command : ModSystem {

        // Load mod on server start
        public override bool ShouldLoad(EnumAppSide side) {
            return side == EnumAppSide.Server;
        }
        
        // Register command
        public override void StartServerSide(ICoreServerAPI api) {
            base.StartServerSide(api);
            AssetLocation sound = new AssetLocation("here", "sounds/partyhorn"); // Create sound location
            api.RegisterCommand("here", "spawns particles around the player", "",
                (IServerPlayer player, int groupId, CmdArgs args) => {
                    EntityPlayer byEntity = player.Entity;
                    byEntity.World.PlaySoundAt(sound, byEntity); // Play sound

                    Vec3d pos = byEntity.Pos.XYZ.Add(0, byEntity.LocalEyePos.Y, 0); // Setting up position to spawn particles
                    Random rand = new Random();
                    for(int i = 0; i < 100; i++) { // Spawn 100 particles 
                        Vec3d realPos = pos.AddCopy(-0.1 + (rand.NextDouble() * 0.2), 0, -0.1 + (rand.NextDouble() * 0.2));
                        Vec3f velocity = new Vec3f(-0.2F + ((float)rand.NextDouble() * 0.4F), 0.4F + ((float)rand.NextDouble() * 2F), -0.2F + ((float)rand.NextDouble() * 0.4F));
                        byEntity.World.SpawnParticles(1, ColorUtil.ColorFromRgba(255, rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)),
                        realPos, realPos,
                        velocity, velocity, ((float)rand.NextDouble() * 1) + 1, 0.01F,
                        1, EnumParticleModel.Cube);
                    }
                }, Privilege.chat);
        }
        
    }
}
