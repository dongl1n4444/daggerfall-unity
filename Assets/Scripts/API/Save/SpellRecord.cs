// Project:         Daggerfall Unity
// Copyright:       Copyright (C) 2009-2022 Daggerfall Workshop
// Web Site:        http://www.dfworkshop.net
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Source Code:     https://github.com/Interkarma/daggerfall-unity
// Original Author: Gavin Clayton (interkarma@dfworkshop.net)
// Contributors:    Lypyl (lypyldf@gmail.com)
// 
// Notes:
//

using System;
using System.IO;
using DaggerfallWorkshop.Utility;
using System.Text;

namespace DaggerfallConnect.Save
{
    /// <summary>
    /// Spell record.
    /// SaveTreeRecordTypes = 0x09
    /// </summary>
    public class SpellRecord : SaveTreeBaseRecord
    {
        SpellRecordData parsedData;

        public SpellRecordData ParsedData
        {
            get { return parsedData; }
            set { parsedData = value; }
        }

        public SpellRecord()
        {
        }

        public SpellRecord(BinaryReader reader, int length)
            : base(reader, length)
        {
            ReadNativeSpellData();
        }

        public void CopyTo(SpellRecord other)
        {
            base.CopyTo(other);
            other.parsedData = this.parsedData;
        }

        public void ReadNativeSpellData()
        {
            if (recordType != RecordTypes.Spell)
                return;
            if (RecordData == null)
                return;

            DaggerfallSpellReader.ReadSpellData(RecordData, out parsedData);
        }

        [Serializable]
        public class SpellRecordData
        {
            public string spellName = "";       //name of spell - if starts w/ !, shouldn't be visibile to player
            public int element      = -1;       //element spell uses
            public int rangeType    = -1;       //touch, caster, area around caster etc.
            public int cost         = -1;       //spell cost
            public int index        = -1;       //index of spell.  Some from SPELLS.STD file, others are player spells
            public int icon         = -1;       //icon index
            public EffectRecordData[] effects;  //each spell has 1-3 effects

            public SpellRecordData()
            {
                effects = new EffectRecordData[3];
            }

            public string ToCSV()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"{spellName},");
                sb.Append($"{element},");
                sb.Append($"{rangeType},");
                sb.Append($"{cost},");
                sb.Append($"{index},");
                sb.Append($"{icon},");
                for (int i = 0; i < effects.Length; ++i)
                {
                    sb.Append($"{effects[i].ToCSV(";")},");
                }
                return sb.ToString();
            }
        }

        //just putting this here for now, should probably be moved in the future
        [Serializable]
        public struct EffectRecordData
        {
            public int type;                    //indicates the main type of the effect, if -1 this effect should be ignore
            public int subType;                 //indicates subtype (for example, health, stamina magicka for a dmg effect).  If -1 there is no subtype
            public int descriptionTextIndex;    //+1200 = index into TEXT.RSC for the effect's description in spellbook & merchant
            public int spellMakerTextIndex;     //+1500 = index into TEXT.RSC for the effect's description in spell maker
            public int durationBase;
            public int durationMod;
            public int durationPerLevel;
            public int chanceBase;
            public int chanceMod;
            public int chancePerLevel;
            public int magnitudeBaseLow;
            public int magnitudeBaseHigh;
            public int magnitudeLevelBase;
            public int magnitudeLevelHigh;
            public int magnitudePerLevel;

            public string ToCSV(string c)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"{type}{c}");
                sb.Append($"{subType}{c}");
                sb.Append($"{descriptionTextIndex}{c}");
                sb.Append($"{spellMakerTextIndex}{c}");
                sb.Append($"{durationBase}{c}");
                sb.Append($"{durationMod}{c}");
                sb.Append($"{durationPerLevel}{c}");
                sb.Append($"{chanceBase}{c}");
                sb.Append($"{chanceMod}{c}");
                sb.Append($"{chancePerLevel}{c}");
                sb.Append($"{magnitudeBaseLow}{c}");
                sb.Append($"{magnitudeBaseHigh}{c}");
                sb.Append($"{magnitudeLevelBase}{c}");
                sb.Append($"{magnitudeLevelHigh}{c}");
                sb.Append($"{magnitudePerLevel}");
                return sb.ToString();
            }
        }
    }
}
