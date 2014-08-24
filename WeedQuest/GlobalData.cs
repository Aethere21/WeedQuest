using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeedQuest
{
    public class GlobalData
    {
        static CurrentLevelInfo mCurrentLevelInfo = new CurrentLevelInfo();
        public static CurrentLevelInfo CurrentLevelInfo
        {
            get { return mCurrentLevelInfo; }
        }


        static PlayerData mPlayerData = new PlayerData();
        public static PlayerData PlayerData
        {
            get { return mPlayerData; }
        }
    }
}
