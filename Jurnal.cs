using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ED_Informator
{
    internal class Jurnal
    {
        DateTime lastTimeStamp;
        long offset = 0;
        
        //EDF1 EDI1 = new EDF1(); 
        //funkcja odczytująca ostatni plik jurnala ED, podczas uruchomiamianai aplikacji EDI
        public void Open_get(String JurnalLastFile) 
        {
            string linia_jurnal;
            FileStream file = File.Open(JurnalLastFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(file);

            
            while (!reader.EndOfStream)
            {
                linia_jurnal = reader.ReadLine();

                linia_jurnal = linia_jurnal.Replace("Combat\":{", "Combat_s\":{");
                linia_jurnal = linia_jurnal.Replace("\"FuelCapacity\":{", "\"FuelCapacitys\":{");
                linia_jurnal = linia_jurnal.Replace("\"Multicrew\":{", "\"Multicrew_s\":{");

                var ReadJurnal = JsonConvert.DeserializeObject<ReadJurnal>(linia_jurnal);
                if (ReadJurnal.@event == "LoadGame")
                {
                    var f = new NumberFormatInfo { NumberGroupSeparator = " " };
                    //var s = d.ToString("n", f); // 2 000 000.00
                    EDF1.instance.cmdrName_z.Text = ReadJurnal.Commander; ;
                    EDF1.instance.shipName_z.Text = ReadJurnal.Ship_Localised; ;
                    EDF1.instance.saldoValue_z.Text = ReadJurnal.Credits.ToString("n", f);
                }
                else if (ReadJurnal.@event == "Location")
                {
                    EDF1.instance.systemValue_z.Text = ReadJurnal.StarSystem;
                    EDF1.instance.stationName_z.Text = ReadJurnal.StationName;
                }
                else if (ReadJurnal.@event == "SuitLoadout")
                {
                    EDF1.instance.outfitValue_z.Text = ReadJurnal.SuitName_Localised + " (" + ReadJurnal.LoadoutName + ")";
                }
                lastTimeStamp = ReadJurnal.timestamp;
                
            }
            file.Close();

        }

        //funkcja odczytująca świeżo utwqorzony plik ED
        public void pre_read_file(string newFile)
        {
            string linia_jurnal ;
            FileStream file = File.Open(newFile,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
            StreamReader reader = new StreamReader(file);
                        
            
                while (!reader.EndOfStream)
                {
                    linia_jurnal = reader.ReadLine();

                    linia_jurnal = linia_jurnal.Replace("Combat\":{", "Combat_s\":{");
                    linia_jurnal = linia_jurnal.Replace("\"FuelCapacity\":{", "\"FuelCapacitys\":{");
                    linia_jurnal = linia_jurnal.Replace("\"Multicrew\":{", "\"Multicrew_s\":{");

                    var ReadJurnal = JsonConvert.DeserializeObject<ReadJurnal>(linia_jurnal);
                    if (ReadJurnal.@event == "LoadGame")
                    {
                        var f = new NumberFormatInfo { NumberGroupSeparator = " " };
                        //var s = d.ToString("n", f); // 2 000 000.00
                        EDF1.instance.cmdrName_z.Text = ReadJurnal.Commander; ;
                        EDF1.instance.shipName_z.Text = ReadJurnal.Ship_Localised; ;
                        EDF1.instance.saldoValue_z.Text = ReadJurnal.Credits.ToString("n", f);
                    }
                    else if (ReadJurnal.@event == "Location")
                    {
                        EDF1.instance.systemValue_z.Text = ReadJurnal.StarSystem;
                        EDF1.instance.stationName_z.Text = ReadJurnal.StationName;
                    }
                    else if (ReadJurnal.@event == "SuitLoadout")
                    {
                        EDF1.instance.outfitValue_z.Text = ReadJurnal.SuitName_Localised + " (" + ReadJurnal.LoadoutName + ")";
                    }
                    lastTimeStamp = ReadJurnal.timestamp;
                offset = file.Position;
                //    EDF1.instance.outfitValue_z.Text = lastTimeStamp.ToString();
            }
            offset = file.Position;
            file.Close();
        }

        public void read_file(string changeFile)
        {
            string linia_jurnal;
            
                        
            FileStream file = File.Open(changeFile,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
            StreamReader reader = new StreamReader(file);
            
            file.Seek(offset, SeekOrigin.Begin);
            while (!reader.EndOfStream)
            {
                linia_jurnal = reader.ReadLine();

                linia_jurnal = linia_jurnal.Replace("Combat\":{", "Combat_s\":{");
                linia_jurnal = linia_jurnal.Replace("\"FuelCapacity\":{", "\"FuelCapacitys\":{");
                linia_jurnal = linia_jurnal.Replace("\"Multicrew\":{", "\"Multicrew_s\":{");
                if (linia_jurnal != "")
                {
                    var ReadJurnal = JsonConvert.DeserializeObject<ReadJurnal>(linia_jurnal);
                

                    if (ReadJurnal.@event == "LoadGame")
                    {
                        var f = new NumberFormatInfo { NumberGroupSeparator = " " };
                        //var s = d.ToString("n", f); // 2 000 000.00
                        EDF1.instance.cmdrName_z.Text = ReadJurnal.Commander; ;
                        EDF1.instance.shipName_z.Text = ReadJurnal.Ship_Localised; ;
                        EDF1.instance.saldoValue_z.Text = ReadJurnal.Credits.ToString("n", f);
                    }
                    else if (ReadJurnal.@event == "Location")
                    {
                        EDF1.instance.systemValue_z.Text = ReadJurnal.StarSystem;
                        EDF1.instance.stationName_z.Text = ReadJurnal.StationName;
                    }
                    else if (ReadJurnal.@event == "SuitLoadout")
                    {
                        EDF1.instance.outfitValue_z.Text = ReadJurnal.SuitName_Localised + " (" + ReadJurnal.LoadoutName + ")";
                    }
                }
                
                

//                EDF1.instance.outfitValue_z.Text = lastTimeStamp.ToString();

            }
            offset = file.Position;
            /*if (!reader.EndOfStream)
                {
                    do
                    {
                        linia_jurnal = reader.ReadLine();

                        linia_jurnal = linia_jurnal.Replace("Combat\":{", "Combat_s\":{");
                        linia_jurnal = linia_jurnal.Replace("\"FuelCapacity\":{", "\"FuelCapacitys\":{");
                        linia_jurnal = linia_jurnal.Replace("\"Multicrew\":{", "\"Multicrew_s\":{");

                        var ReadJurnal = JsonConvert.DeserializeObject<ReadJurnal>(linia_jurnal);
                        if (ReadJurnal.@event == "LoadGame")
                        {
                            var f = new NumberFormatInfo { NumberGroupSeparator = " " };
                            //var s = d.ToString("n", f); // 2 000 000.00
                            EDF1.instance.cmdrName_z.Text = ReadJurnal.Commander; ;
                            EDF1.instance.shipName_z.Text = ReadJurnal.Ship_Localised; ;
                            EDF1.instance.saldoValue_z.Text = ReadJurnal.Credits.ToString("n", f);
                        }
                        else if (ReadJurnal.@event == "Location")
                        {
                            EDF1.instance.systemValue_z.Text = ReadJurnal.StarSystem;
                            EDF1.instance.stationName_z.Text = ReadJurnal.StationName;
                        }
                        else if (ReadJurnal.@event == "SuitLoadout")
                        {
                            EDF1.instance.outfitValue_z.Text = ReadJurnal.SuitName_Localised + " (" + ReadJurnal.LoadoutName + ")";
                        }
                        lastTimeStamp = ReadJurnal.timestamp;
                    } while (!reader.EndOfStream);

                    offset = file.Position;
                }*/

            file.Close();

        }

        //odczytujemy ED JUrnal - dane główne
        public class ReadJurnal
        {
            public DateTime timestamp { get; set; }
            public string @event { get; set; }
            public int part { get; set; }
            public string language { get; set; }
            public bool Odyssey { get; set; }
            public string gameversion { get; set; }
            public string build { get; set; }
            public string FID { get; set; }
            public string Name { get; set; }
            public List<Raw> Raw { get; set; }
            public List<Manufactured> Manufactured { get; set; }
            public List<object> Encoded { get; set; }
            public int Combat { get; set; }
            public int Trade { get; set; }
            public int Explore { get; set; }
            public int Soldier { get; set; }
            public int Exobiologist { get; set; }
            public double Empire { get; set; }
            public double Federation { get; set; }
            public int CQC { get; set; }
            public double Alliance { get; set; }
            public List<Engineers> Engineers { get; set; }
            public string SquadronName { get; set; }
            public int CurrentRank { get; set; }
            public string Commander { get; set; }
            public bool Horizons { get; set; }
            public string Ship { get; set; }
            public string Ship_Localised { get; set; }
            public double ShipID { get; set; }
            public string ShipName { get; set; }
            public string ShipIdent { get; set; }
            public double FuelLevel { get; set; }
            public double FuelCapacity { get; set; }
            public string GameMode { get; set; }
            public int Credits { get; set; }
            public int Loan { get; set; }
            public BankAccount Bank_Account { get; set; }
            public Combat_s Combat_s { get; set; }
            public Crime Crime { get; set; }
            public Smuggling Smuggling { get; set; }
            public Trading Trading { get; set; }
            public Mining Mining { get; set; }
            public Exploration Exploration { get; set; }
            public Passengers Passengers { get; set; }
            public SearchAndRescue Search_And_Rescue { get; set; }
            public Crafting Crafting { get; set; }
            public Crew Crew { get; set; }
            public Multicrew_s Multicrew_s { get; set; }
            public MaterialTraderStats Material_Trader_Stats { get; set; }
            public Exobiology Exobiology { get; set; }
            public string From { get; set; }
            public string Message { get; set; }
            public string Message_Localised { get; set; }
            public string Channel { get; set; }
            public long SystemAddress { get; set; }
            public string SignalName { get; set; }
            public bool IsStation { get; set; }
            public string SignalName_Localised { get; set; }
            public double DistFromStarLS { get; set; }
            public bool Docked { get; set; }
            public string StationName { get; set; }
            public string StationType { get; set; }
            public long MarketID { get; set; }
            public StationFaction StationFaction { get; set; }
            public string StationGovernment { get; set; }
            public string StationGovernment_Localised { get; set; }
            public string StationAllegiance { get; set; }
            public List<string> StationServices { get; set; }
            public string StationEconomy { get; set; }
            public string StationEconomy_Localised { get; set; }
            public List<StationEconomy> StationEconomies { get; set; }
            public bool Taxi { get; set; }
            public bool Multicrew { get; set; }
            public string StarSystem { get; set; }
            public List<double> StarPos { get; set; }
            public string SystemAllegiance { get; set; }
            public string SystemEconomy { get; set; }
            public string SystemEconomy_Localised { get; set; }
            public string SystemSecondEconomy { get; set; }
            public string SystemSecondEconomy_Localised { get; set; }
            public string SystemGovernment { get; set; }
            public string SystemGovernment_Localised { get; set; }
            public string SystemSecurity { get; set; }
            public string SystemSecurity_Localised { get; set; }
            public int Population { get; set; }
            public string Body { get; set; }
            public int BodyID { get; set; }
            public string BodyType { get; set; }
            public List<Faction> Factions { get; set; }
            public SystemFaction SystemFaction { get; set; }
            public List<Item> Items { get; set; }
            public List<Component> Components { get; set; }
            public List<object> Consumables { get; set; }
            public List<Datum> Data { get; set; }
            public List<object> Active { get; set; }
            public List<object> Failed { get; set; }
            public List<object> Complete { get; set; }
            public int HullValue { get; set; }
            public int ModulesValue { get; set; }
            public double HullHealth { get; set; }
            public double UnladenMass { get; set; }
            public int CargoCapacity { get; set; }
            public double MaxJumpRange { get; set; }
            public FuelCapacitys FuelCapacitys { get; set; }
            public int Rebuy { get; set; }
            public List<Module> Modules { get; set; }
            public string Vessel { get; set; }
            public int Count { get; set; }
            public List<Inventory> Inventory { get; set; }
            public long SuitID { get; set; }
            public string SuitName { get; set; }
            public string SuitName_Localised { get; set; }
            public List<object> SuitMods { get; set; }
            public long LoadoutID { get; set; }
            public string LoadoutName { get; set; }
            public List<BioData> BioData { get; set; }
     
        }

        //odczytujemy ED Jurnal - dane zagnieżdzone
        public class BioData
        {
            public string Genus { get; set; }
            public string Genus_Localised { get; set; }
            public string Species { get; set; }
            public string Species_Localised { get; set; }
            public int Value { get; set; }
            public int Bonus { get; set; }
        }
        public class Inventory
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
            public int Stolen { get; set; }
        }
        public class FuelCapacitys
        {
            public double Main { get; set; }
            public double Reserve { get; set; }
        }

        public class Modifier
        {
            public string Label { get; set; }
            public double Value { get; set; }
            public double OriginalValue { get; set; }
            public int LessIsGood { get; set; }
        }

        public class Engineering
        {
            public string Engineer { get; set; }
            public int EngineerID { get; set; }
            public int BlueprintID { get; set; }
            public string BlueprintName { get; set; }
            public int Level { get; set; }
            public double Quality { get; set; }
            public List<Modifier> Modifiers { get; set; }
        }

        public class Module
        {
            public string Slot { get; set; }
            public string Item { get; set; }
            public bool On { get; set; }
            public int Priority { get; set; }
            public double Health { get; set; }
            public int Value { get; set; }
            public int? AmmoInClip { get; set; }
            public int? AmmoInHopper { get; set; }
            public Engineering Engineering { get; set; }
            public string SlotName { get; set; }
            public long SuitModuleID { get; set; }
            public string ModuleName { get; set; }
            public string ModuleName_Localised { get; set; }
            public int Class { get; set; }
            public List<object> WeaponMods { get; set; }
        }
        public class Item
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int OwnerID { get; set; }
            public int Count { get; set; }
        }

        public class Component
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int OwnerID { get; set; }
            public int Count { get; set; }
        }

        public class Datum
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int OwnerID { get; set; }
            public int Count { get; set; }
        }
        public class StationFaction
        {
            public string Name { get; set; }
        }

        public class StationEconomy
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public double Proportion { get; set; }
        }

        public class RecoveringState
        {
            public string State { get; set; }
            public int Trend { get; set; }
        }

        public class ActiveState
        {
            public string State { get; set; }
        }

        public class Faction
        {
            public string Name { get; set; }
            public string FactionState { get; set; }
            public string Government { get; set; }
            public double Influence { get; set; }
            public string Allegiance { get; set; }
            public string Happiness { get; set; }
            public string Happiness_Localised { get; set; }
            public double MyReputation { get; set; }
            public List<RecoveringState> RecoveringStates { get; set; }
            public List<ActiveState> ActiveStates { get; set; }
        }

        public class SystemFaction
        {
            public string Name { get; set; }
        }
        public class BankAccount
        {
            public int Current_Wealth { get; set; }
            public int Spent_On_Ships { get; set; }
            public int Spent_On_Outfitting { get; set; }
            public int Spent_On_Repairs { get; set; }
            public int Spent_On_Fuel { get; set; }
            public int Spent_On_Ammo_Consumables { get; set; }
            public int Insurance_Claims { get; set; }
            public int Spent_On_Insurance { get; set; }
            public int Owned_Ship_Count { get; set; }
            public int Spent_On_Suits { get; set; }
            public int Spent_On_Weapons { get; set; }
            public int Spent_On_Suit_Consumables { get; set; }
            public int Suits_Owned { get; set; }
            public int Weapons_Owned { get; set; }
            public int Spent_On_Premium_Stock { get; set; }
            public int Premium_Stock_Bought { get; set; }
        }

        public class Combat_s
        {
            public int Bounties_Claimed { get; set; }
            public int Bounty_Hunting_Profit { get; set; }
            public int Combat_Bonds { get; set; }
            public int Combat_Bond_Profits { get; set; }
            public int Assassinations { get; set; }
            public int Assassination_Profits { get; set; }
            public int Highest_Single_Reward { get; set; }
            public int Skimmers_Killed { get; set; }
            public int OnFoot_Combat_Bonds { get; set; }
            public int OnFoot_Combat_Bonds_Profits { get; set; }
            public int OnFoot_Vehicles_Destroyed { get; set; }
            public int OnFoot_Ships_Destroyed { get; set; }
            public int Dropships_Taken { get; set; }
            public int Dropships_Booked { get; set; }
            public int Dropships_Cancelled { get; set; }
            public int ConflictZone_High { get; set; }
            public int ConflictZone_Medium { get; set; }
            public int ConflictZone_Low { get; set; }
            public int ConflictZone_Total { get; set; }
            public int ConflictZone_High_Wins { get; set; }
            public int ConflictZone_Medium_Wins { get; set; }
            public int ConflictZone_Low_Wins { get; set; }
            public int ConflictZone_Total_Wins { get; set; }
            public int Settlement_Defended { get; set; }
            public int Settlement_Conquered { get; set; }
            public int OnFoot_Skimmers_Killed { get; set; }
            public int OnFoot_Scavs_Killed { get; set; }

        }

        public class Crime
        {
            public int Notoriety { get; set; }
            public int Fines { get; set; }
            public int Total_Fines { get; set; }
            public int Bounties_Received { get; set; }
            public int Total_Bounties { get; set; }
            public int Highest_Bounty { get; set; }
            public int Malware_Uploaded { get; set; }
            public int Settlements_State_Shutdown { get; set; }
            public int Production_Sabotage { get; set; }
            public int Production_Theft { get; set; }
            public int Total_Murders { get; set; }
            public int Citizens_Murdered { get; set; }
            public int Omnipol_Murdered { get; set; }
            public int Guards_Murdered { get; set; }
            public int Data_Stolen { get; set; }
            public int Goods_Stolen { get; set; }
            public int Sample_Stolen { get; set; }
            public int Total_Stolen { get; set; }
            public int Turrets_Destroyed { get; set; }
            public int Turrets_Overloaded { get; set; }
            public int Turrets_Total { get; set; }
            public int Value_Stolen_StateChange { get; set; }
            public int Profiles_Cloned { get; set; }
        }

        public class Smuggling
        {
            public int Black_Markets_Traded_With { get; set; }
            public int Black_Markets_Profits { get; set; }
            public int Resources_Smuggled { get; set; }
            public int Average_Profit { get; set; }
            public int Highest_Single_Transaction { get; set; }
        }

        public class Trading
        {
            public int Markets_Traded_With { get; set; }
            public int Market_Profits { get; set; }
            public int Resources_Traded { get; set; }
            public double Average_Profit { get; set; }
            public int Highest_Single_Transaction { get; set; }
            public int Data_Sold { get; set; }
            public int Goods_Sold { get; set; }
            public int Assets_Sold { get; set; }
        }

        public class Mining
        {
            public int Mining_Profits { get; set; }
            public int Quantity_Mined { get; set; }
            public int Materials_Collected { get; set; }
        }

        public class Exploration
        {
            public int Systems_Visited { get; set; }
            public int Exploration_Profits { get; set; }
            public int Planets_Scanned_To_Level_2 { get; set; }
            public int Planets_Scanned_To_Level_3 { get; set; }
            public int Efficient_Scans { get; set; }
            public int Highest_Payout { get; set; }
            public int Total_Hyperspace_Distance { get; set; }
            public int Total_Hyperspace_Jumps { get; set; }
            public double Greatest_Distance_From_Start { get; set; }
            public int Time_Played { get; set; }
            public int OnFoot_Distance_Travelled { get; set; }
            public int Shuttle_Journeys { get; set; }
            public int Shuttle_Distance_Travelled { get; set; }
            public int Spent_On_Shuttles { get; set; }
            public int First_Footfalls { get; set; }
            public int Planet_Footfalls { get; set; }
            public int Settlements_Visited { get; set; }
        }

        public class Passengers
        {
            public int Passengers_Missions_Bulk { get; set; }
            public int Passengers_Missions_VIP { get; set; }
            public int Passengers_Missions_Delivered { get; set; }
            public int Passengers_Missions_Ejected { get; set; }
        }

        public class SearchAndRescue
        {
            public int SearchRescue_Traded { get; set; }
            public int SearchRescue_Profit { get; set; }
            public int SearchRescue_Count { get; set; }
            public int Salvage_Legal_POI { get; set; }
            public int Salvage_Legal_Settlements { get; set; }
            public int Salvage_Illegal_POI { get; set; }
            public int Salvage_Illegal_Settlements { get; set; }
            public int Maglocks_Opened { get; set; }
            public int Panels_Opened { get; set; }
            public int Settlements_State_FireOut { get; set; }
            public int Settlements_State_Reboot { get; set; }
        }

        public class Crafting
        {
            public int Count_Of_Used_Engineers { get; set; }
            public int Recipes_Generated { get; set; }
            public int Recipes_Generated_Rank_1 { get; set; }
            public int Recipes_Generated_Rank_2 { get; set; }
            public int Recipes_Generated_Rank_3 { get; set; }
            public int Recipes_Generated_Rank_4 { get; set; }
            public int Recipes_Generated_Rank_5 { get; set; }
            public int Suit_Mods_Applied { get; set; }
            public int Weapon_Mods_Applied { get; set; }
            public int Suits_Upgraded { get; set; }
            public int Weapons_Upgraded { get; set; }
            public int Suits_Upgraded_Full { get; set; }
            public int Weapons_Upgraded_Full { get; set; }
            public int Suit_Mods_Applied_Full { get; set; }
            public int Weapon_Mods_Applied_Full { get; set; }
        }

        public class Crew
        {
            public int NpcCrew_TotalWages { get; set; }
            public int NpcCrew_Hired { get; set; }
            public int NpcCrew_Fired { get; set; }
            public int NpcCrew_Died { get; set; }
        }

        public class Multicrew_s
        {
            public int Multicrew_Time_Total { get; set; }
            public int Multicrew_Gunner_Time_Total { get; set; }
            public int Multicrew_Fighter_Time_Total { get; set; }
            public int Multicrew_Credits_Total { get; set; }
            public int Multicrew_Fines_Total { get; set; }
        }

        public class MaterialTraderStats
        {
            public int Trades_Completed { get; set; }
            public int Materials_Traded { get; set; }
            public int Assets_Traded_In { get; set; }
            public int Assets_Traded_Out { get; set; }
        }

        public class Exobiology
        {
            public int Organic_Genus_Encountered { get; set; }
            public int Organic_Species_Encountered { get; set; }
            public int Organic_Variant_Encountered { get; set; }
            public int Organic_Data_Profits { get; set; }
            public int Organic_Data { get; set; }
            public int First_Logged_Profits { get; set; }
            public int First_Logged { get; set; }
            public int Organic_Systems { get; set; }
            public int Organic_Planets { get; set; }
            public int Organic_Genus { get; set; }
            public int Organic_Species { get; set; }
        }
        public class Engineers
        {
            public string Engineer { get; set; }
            public int EngineerID { get; set; }
            public string Progress { get; set; }
            public int RankProgress { get; set; }
            public int Rank { get; set; }
        }
        public class Raw
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        public class Manufactured
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
        }


    }
}
