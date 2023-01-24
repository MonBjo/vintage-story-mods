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
    class AdminTrader : ModSystem {
        public override void Start(ICoreAPI api) {
            base.Start(api);
            api.RegisterEntity("admintrader", typeof(EntityTrader));
        }
    }
}
