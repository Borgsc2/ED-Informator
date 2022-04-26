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
using System.IO.Compression;
using System.Windows.Forms;

namespace ED_Informator
{
    internal class Jurnal
    {
        DateTime lastTimeStamp;
        long offset = 0;
        String coriolis_s = EDF1.coriolis;
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
                    EDF1.instance.cmdrName_z.Text = ReadJurnal.Commander;
                    LinkLabel.Link links = new LinkLabel.Link();
                    if (ReadJurnal.Ship_Localised == "SRV Scarab")
                    {
                        EDF1.instance.shipName.Text = ReadJurnal.Ship_Localised;
                        EDF1.instance.shipName.Links.Remove(links);
                        links.Enabled = false;
                        EDF1.instance.shipName.Links.Add(links);
                    }
                    else
                    {
                        EDF1.instance.shipName.Text = ReadJurnal.Ship_Localised;
                        EDF1.instance.shipName.Links.Remove(links);
                        links.Enabled = true;
                        EDF1.instance.shipName.Links.Add(links);
                    }



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
                else if (ReadJurnal.@event == "Loadout")
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(linia_jurnal);

                    using (var outputStream = new MemoryStream())
                    {
                        using (var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                            gZipStream.Write(inputBytes, 0, inputBytes.Length);

                        var outputBytes = outputStream.ToArray();

                        var outputbase64 = Convert.ToBase64String(outputBytes);

                        outputbase64 = outputbase64.Replace("=", "%3D");
                        coriolis_s = "https://coriolis.io/import?data=" + outputbase64;
                        
                        EDF1.coriolis = "https://coriolis.io/import?data=" + outputbase64; 
                    }                       

                    
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
                        EDF1.instance.cmdrName_z.Text = ReadJurnal.Commander;
                        LinkLabel.Link links = new LinkLabel.Link();
                        if (ReadJurnal.Ship_Localised == "SRV Scarab")
                        {
                            EDF1.instance.shipName.Text = ReadJurnal.Ship_Localised;
                            EDF1.instance.shipName.Links.Remove(links);
                            links.Enabled = false;
                            EDF1.instance.shipName.Links.Add(links);
                        }
                        else
                        {
                            EDF1.instance.shipName.Text = ReadJurnal.Ship_Localised;
                            EDF1.instance.shipName.Links.Remove(links);
                            links.Enabled = true;
                            EDF1.instance.shipName.Links.Add(links);
                        }

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
                    else if (ReadJurnal.@event == "Loadout")
                    {
                        byte[] inputBytes = Encoding.UTF8.GetBytes(linia_jurnal);

                        using (var outputStream = new MemoryStream())
                        {
                            using (var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                                gZipStream.Write(inputBytes, 0, inputBytes.Length);

                            var outputBytes = outputStream.ToArray();

                            var outputbase64 = Convert.ToBase64String(outputBytes);

                            outputbase64 = outputbase64.Replace("=", "%3D");
                            coriolis_s = "https://coriolis.io/import?data=" + outputbase64;

                            EDF1.coriolis = "https://coriolis.io/import?data=" + outputbase64;
                        }


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
            //if (offset == 0)
           //     return;

            string linia_jurnal;
            
                        
            FileStream file = File.Open(changeFile,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
            StreamReader reader = new StreamReader(file);
            
            file.Seek(offset, SeekOrigin.Begin);
            
            while (!reader.EndOfStream)
            {
                linia_jurnal = reader.ReadLine();

                linia_jurnal = linia_jurnal.Replace("part\":{", "part_s\":{");
                linia_jurnal = linia_jurnal.Replace("Combat\":{", "Combat_s\":{");
                linia_jurnal = linia_jurnal.Replace("\"FuelCapacity\":{", "\"FuelCapacitys\":{");
                linia_jurnal = linia_jurnal.Replace("\"Multicrew\":{", "\"Multicrew_s\":{");
                if (linia_jurnal != "")
                {
                    var ReadJurnal = JsonConvert.DeserializeObject<ReadJurnal>(linia_jurnal);


                    if (ReadJurnal.@event == "LoadGame") //Odczytujemy podstawowe informacje o lokalizacji gracza (Statek, SRV, saldo kasy, itp)
                    {
                        var f = new NumberFormatInfo { NumberGroupSeparator = " " };
                        //var s = d.ToString("n", f); // 2 000 000.00
                        EDF1.instance.cmdrName_z.Text = ReadJurnal.Commander;
                        LinkLabel.Link links = new LinkLabel.Link();
                        if (ReadJurnal.Ship_Localised == "SRV Scarab")
                        {
                            EDF1.instance.shipName.Text = ReadJurnal.Ship_Localised;
                            EDF1.instance.shipName.Links.Remove(links);
                            links.Enabled = false;
                            EDF1.instance.shipName.Links.Add(links);
                        }
                        else
                        {
                            EDF1.instance.shipName.Text = ReadJurnal.Ship_Localised;
                            EDF1.instance.shipName.Links.Remove(links);
                            links.Enabled = true;
                            EDF1.instance.shipName.Links.Add(links);
                        }



                        EDF1.instance.saldoValue_z.Text = ReadJurnal.Credits.ToString("n", f);
                    }
                    else if (ReadJurnal.@event == "Location") //odczytujemy informacje o systemie w którym gracz się znajduje i stacji jesłi statek został zadokowany
                    {
                        EDF1.instance.systemValue_z.Text = ReadJurnal.StarSystem;
                        EDF1.instance.stationName_z.Text = ReadJurnal.StationName;
                    }
                    else if (ReadJurnal.@event == "SuitLoadout") //odczytujemy informacje o stroju jaki ma założony gracz. Opcja dostępna dopiero po wyjściu ze statku na planetę lub stację
                    {
                        EDF1.instance.outfitValue_z.Text = ReadJurnal.SuitName_Localised + " (" + ReadJurnal.LoadoutName + ")";
                    }
                    else if (ReadJurnal.@event == "Loadout") //odczytujemy wszystkie informacje o statku i tworzymy link do Coriolis. Informacja dostępna tylko jeśli gracz jest w statku
                    {
                        byte[] inputBytes = Encoding.UTF8.GetBytes(linia_jurnal);

                        using (var outputStream = new MemoryStream())
                        {
                            using (var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                                gZipStream.Write(inputBytes, 0, inputBytes.Length);

                            var outputBytes = outputStream.ToArray();

                            var outputbase64 = Convert.ToBase64String(outputBytes);

                            outputbase64 = outputbase64.Replace("=", "%3D");
                            coriolis_s = "https://coriolis.io/import?data=" + outputbase64;

                            EDF1.coriolis = "https://coriolis.io/import?data=" + outputbase64;
                        }


                    }
                    else if (ReadJurnal.@event == "MaterialCollected")
                    {
                        int rowID = EDF1.instance.listaZnalezisk_z.Rows.Add();
                        DataGridViewRow row = EDF1.instance.listaZnalezisk_z.Rows[rowID];
                        row.Cells["col_time"].Value = ReadJurnal.timestamp;
                        row.Cells["col_event"].Value = "Zebrano materiał";
                        row.Cells["col_desc"].Value = ReadJurnal.Name_Localised + " w ilości: " + ReadJurnal.Count.ToString();
                        row.Cells["col_info"].Value = ReadJurnal.Category + ": ??????, Łączna ilość: xxx";


                    }



                    //                EDF1.instance.outfitValue_z.Text = lastTimeStamp.ToString();

                }
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
            public int part_s { get; set; }
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
            public string Status { get; set; }
            public string MusicTrack { get; set; }
            public string JumpType { get; set; }
            public string StarClass { get; set; }
            public int RemainingJumpsInRoute { get; set; }
            public double Scooped { get; set; }
            public double Total { get; set; }
            public double Progress { get; set; }
            public int BodyCount { get; set; }
            public int NonBodyCount { get; set; }
            public string SystemName { get; set; }
            public string ScanType { get; set; }
            public string BodyName { get; set; }
            public List<Parent> Parents { get; set; }
            public double DistanceFromArrivalLS { get; set; }
            public string StarType { get; set; }
            public int Subclass { get; set; }
            public double StellarMass { get; set; }
            public double Radius { get; set; }
            public double AbsoluteMagnitude { get; set; }
            public int Age_MY { get; set; }
            public double SurfaceTemperature { get; set; }
            public string Luminosity { get; set; }
            public double SemiMajorAxis { get; set; }
            public double Eccentricity { get; set; }
            public double OrbitalInclination { get; set; }
            public double Periapsis { get; set; }
            public double OrbitalPeriod { get; set; }
            public double AscendingNode { get; set; }
            public double MeanAnomaly { get; set; }
            public double RotationPeriod { get; set; }
            public double AxialTilt { get; set; }
            public bool WasDiscovered { get; set; }
            public bool WasMapped { get; set; }
            public bool TidalLock { get; set; }
            public string TerraformState { get; set; }
            public string PlanetClass { get; set; }
            public string Atmosphere { get; set; }
            public string AtmosphereType { get; set; }
            public List<AtmosphereComposition> AtmosphereComposition { get; set; }
            public string Volcanism { get; set; }
            public double MassEM { get; set; }
            public double SurfaceGravity { get; set; }
            public double SurfacePressure { get; set; }
            public bool Landable { get; set; }
            public Composition Composition { get; set; }
            public double JumpDist { get; set; }
            public double FuelUsed { get; set; }
            public string USSType { get; set; }
            public string USSType_Localised { get; set; }
            public string SpawningState { get; set; }
            public string SpawningFaction { get; set; }
            public int ThreatLevel { get; set; }
            public double TimeRemaining { get; set; }
            public string SpawningFaction_Localised { get; set; }
            public string SpawningState_Localised { get; set; }
            public List<Signal> Signals { get; set; }
            public List<Conflict> Conflicts { get; set; }
            public int USSThreat { get; set; }
            public double FuelMain { get; set; }
            public double FuelReservoir { get; set; }
            public string Category { get; set; }
            public string Name_Localised { get; set; }
            public int DiscoveryNumber { get; set; }
            public int ProbesUsed { get; set; }
            public int EfficiencyTarget { get; set; }
            public bool OnStation { get; set; }
            public bool OnPlanet { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string NearestDestination { get; set; }
            public bool PlayerControlled { get; set; }
            public string SRVType { get; set; }
            public string SRVType_Localised { get; set; }
            public string Loadout { get; set; }
            public int ID { get; set; }
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public bool SRV { get; set; }
            public int Reward { get; set; }
            public string VictimFaction { get; set; }
            public string PayeeFaction { get; set; }
            public bool TargetLocked { get; set; }
            public int ScanStage { get; set; }
            public string PilotName { get; set; }
            public string PilotName_Localised { get; set; }
            public string PilotRank { get; set; }
            public string SquadronID { get; set; }
            public double ShieldHealth { get; set; }
            public string LegalStatus { get; set; }
            //////////////////////////////////
            







            ////////////////////
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
            public string FactionState { get; set; }
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

        public class Parent
        {
            public int Ring { get; set; }
            public int Star { get; set; }
            public int Null { get; set; }

        }

        public class AtmosphereComposition
        {
            public string Name { get; set; }
            public double Percent { get; set; }
        }

        public class Composition
        {
            public double Ice { get; set; }
            public double Rock { get; set; }
            public double Metal { get; set; }
        }
        public class Signal
        {
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public int Count { get; set; }
        }

        public class Faction1
        {
            public string Name { get; set; }
            public string Stake { get; set; }
            public int WonDays { get; set; }
        }

        public class Faction2
        {
            public string Name { get; set; }
            public string Stake { get; set; }
            public int WonDays { get; set; }
        }

        public class Conflict
        {
            public string WarType { get; set; }
            public string Status { get; set; }
            public Faction1 Faction1 { get; set; }
            public Faction2 Faction2 { get; set; }
        }
    }
}
