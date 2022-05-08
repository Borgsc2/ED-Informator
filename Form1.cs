using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
using System.Net;
using System.Web;
using System.Diagnostics;

namespace ED_Informator
{
    public partial class EDF1 : Form
    {
        public static EDF1 instance;
        public Label cmdrName_z;
        public Label shipName_z;
        public Label outfitValue_z;
        public Label systemValue_z;
        public Label stationName_z;
        public Label test_label_z;
        public ToolStripStatusLabel saldoValue_z;
        //private delegate void Update(string s);
        string EliteJurnalPath;
        public static string coriolis;
        Jurnal jurnal = new Jurnal();
        Boolean lockRead=false;
        public DataGridView listaZnalezisk_z;
        int kolej_num = 0;
        
        public EDF1()
        {
            InitializeComponent();
            instance = this;
            cmdrName_z = cmdrName;
            shipName_z = test_label;
            outfitValue_z = outfitValue;
            systemValue_z = systemValue;
            stationName_z = stationName;
            saldoValue_z = saldoValue;
            test_label_z= test_label;
            listaZnalezisk_z= listaZnalezisk;
            
            
            Label.CheckForIllegalCrossThreadCalls = false;
            StatusStrip.CheckForIllegalCrossThreadCalls = false;

        }
        private void EDF1_Load(object sender, EventArgs e)
        {
            Debug.Print("EDF Load krok 1");
            //odczytujemy zmienna zawierająca lokalizację jurnala
            EliteJurnalPath = Properties.Settings.Default.jurnalPatch;
            if (EliteJurnalPath=="")
            {
                Debug.Print("EDF Load krok 2");
                string userPatch = System.Environment.GetEnvironmentVariable("USERPROFILE");
                //string userpatch1 = userPatch;
                if (Directory.Exists(userPatch + "\\Saved games\\Frontier Developments\\Elite Dangerous"))
                {
                    Debug.Print("EDF Load krok 3");
                    EliteJurnalPath = userPatch + "\\Saved games\\Frontier Developments\\Elite Dangerous";
                    Properties.Settings.Default.jurnalPatch  = EliteJurnalPath;
                }
                else if (Directory.Exists(userPatch + "\\Zapisane gry\\Frontier Developments\\Elite Dangerous"))
                {
                    Debug.Print("EDF Load krok 4");
                    EliteJurnalPath = userPatch + "\\Zapisane gry\\Frontier Developments\\Elite Dangerous";
                    Properties.Settings.Default.jurnalPatch = EliteJurnalPath;
                }
                Debug.Print("EDF Load krok 5");
                Properties.Settings.Default.Save();
            }
            Debug.Print("EDF Load krok 6");
            szacowZarobValue.Text = "nie monitorowany";
            rzeczZarobValue.Text = "oczekiwanie na sprzedaż";

            Debug.Print("EDF Load krok 7");
            //tworzymy wątki odpowiedzialne za obsługę plików jurnala
            Thread nowy_plik = new Thread(new_file) { IsBackground = true };
            Thread zmien_plik = new Thread(change_file) { IsBackground = true };
            //new Thread(Created) { IsBackground = true }.Start();
            Debug.Print("EDF Load krok 8");
            FileSystemWatcher fwatcher = new FileSystemWatcher();
            fwatcher.Path = EliteJurnalPath;
            fwatcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;
            fwatcher.Filter = "*.log";
            fwatcher.IncludeSubdirectories = true;
            fwatcher.EnableRaisingEvents = true;

            Debug.Print("EDF Load krok 9");
            fwatcher.Changed += OnChanged;
            //nowy_plik.Start(); 
            zmien_plik.Start();

        /*this.Invoke(
        new Action(() =>
        {
            cmdrName.Text = openget[0];
            shipName.Text = openget[1];
            outfitValue.Text = openget[2];
            systemValue.Text = openget[3];
            stationName.Text = openget[4];
            saldoValue.Text=openget[5];

        }));*/

        


        }
        public void new_file()
        {
            
            //EliteJurnalPath+"\\Frontier Developments\\Elite Dangerous";
           
        }

        public void change_file()
        {
            Debug.Print("EDF Load krok 10");
            FileSystemWatcher fwatcher = new FileSystemWatcher();
            //EliteJurnalPath+"\\Frontier Developments\\Elite Dangerous";
            fwatcher.Path = EliteJurnalPath;



            fwatcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;
            fwatcher.Filter = "*.log";
            fwatcher.IncludeSubdirectories = true;
            fwatcher.EnableRaisingEvents = true;

            fwatcher.Created += OnCreated;
        }
        private void EDF1_Shown(Object sender, EventArgs e)
        {
            Debug.Print("EDF Load krok 11");
            //aktywujemy monitorowanie zmian w foldezrze zawierajacym jurnal Elite

            //Szukamy ostatniego utworzonego pliku Jurnala
            string pattern = "Journal*.log";
            var directory = new DirectoryInfo(EliteJurnalPath);
            var myFile = (from f in directory.GetFiles(pattern)
                          orderby f.LastWriteTime descending
                          select f).First();
            string JurnalLastFile = myFile.FullName.ToString();

            /*myFile = directory.GetFiles(pattern)
                         .OrderByDescending(f => f.LastWriteTime)
                         .First();
            podkkd = myFile.ToString();*/

            //Odczytujemy podstawowe informacje o ostatniej sesji gry

            Debug.Print("EDF Load krok 12");
            string[] openget = new string[10];
            lockRead = true;
            jurnal.Open_get(JurnalLastFile);
            lockRead = false;

            
            
        }



        private void  OnChanged(object sender, FileSystemEventArgs e)
        {
            Debug.Print("EDF Load krok 13");
            if (lockRead == false)
            {
                lockRead= true;
                Debug.Print("EDF Load krok 13a");
                jurnal.read_file(e.FullPath);
                lockRead= false;
            }
        }

       /* private void Invoke(Action<object, FileSystemEventArgs> onChanged, object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }*/

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            Debug.Print("EDF Load krok 14");
            lockRead = true;
            cmdrName_z.Text = "";
            Invoke(new Action(() => shipName_z.Text = ""));
            Invoke(new Action(() => saldoValue_z.Text = ""));
            Invoke(new Action(() => systemValue_z.Text = ""));
            Invoke(new Action(() => stationName_z.Text = ""));
            Invoke(new Action(() => outfitValue_z.Text = ""));
            //odczytujemy świerzo utworzony plik
            //if (lockRead == false)
            //{
            Debug.Print("EDF Load krok 15");
            jurnal.pre_read_file(e.FullPath);
                lockRead=false;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string loadout = "{\"Modules\":[{\"Item\":\"hpt_beamlaser_gimbal_small\",\"On\":true,\"Priority\":0,\"Slot\":\"MediumHardpoint1\"},{\"Item\":\"hpt_shieldbooster_size0_class2\",\"On\":true,\"Priority\":0,\"Slot\":\"TinyHardpoint1\"},{\"AmmoInClip\":1,\"AmmoInHopper\":2,\"Item\":\"hpt_heatsinklauncher_turret_tiny\",\"On\":true,\"Priority\":0,\"Slot\":\"TinyHardpoint2\"},{\"AmmoInClip\":1,\"AmmoInHopper\":2,\"Item\":\"hpt_heatsinklauncher_turret_tiny\",\"On\":true,\"Priority\":0,\"Slot\":\"TinyHardpoint4\"},{\"Item\":\"asp_cockpit\",\"On\":true,\"Priority\":1,\"Slot\":\"ShipCockpit\"},{\"Item\":\"modularcargobaydoor\",\"On\":true,\"Priority\":2,\"Slot\":\"CargoHatch\"},{\"Item\":\"asp_armour_grade1\",\"On\":true,\"Priority\":1,\"Slot\":\"Armour\"},{\"Engineering\":{\"BlueprintID\":128673770,\"BlueprintName\":\"PowerPlant_Stealth\",\"Engineer\":\"Marco Qwent\",\"EngineerID\":300200,\"Level\":1,\"Modifiers\":[{\"Label\":\"Mass\",\"LessIsGood\":1,\"OriginalValue\":10.0,\"Value\":10.4},{\"Label\":\"PowerCapacity\",\"LessIsGood\":0,\"OriginalValue\":20.4,\"Value\":19.788},{\"Label\":\"HeatEfficiency\",\"LessIsGood\":1,\"OriginalValue\":0.4,\"Value\":0.30064}],\"Quality\":0.984},\"Item\":\"int_powerplant_size5_class5\",\"On\":true,\"Priority\":1,\"Slot\":\"PowerPlant\"},{\"Engineering\":{\"BlueprintID\":128673660,\"BlueprintName\":\"Engine_Reinforced\",\"Engineer\":\"Elvira Martuuk\",\"EngineerID\":300160,\"Level\":1,\"Modifiers\":[{\"Label\":\"Mass\",\"LessIsGood\":1,\"OriginalValue\":8.0,\"Value\":8.4},{\"Label\":\"Integrity\",\"LessIsGood\":0,\"OriginalValue\":77.0,\"Value\":100.099998},{\"Label\":\"EngineHeatRate\",\"LessIsGood\":1,\"OriginalValue\":1.3,\"Value\":1.17}],\"Quality\":1.0},\"Item\":\"int_engine_size5_class2\",\"On\":true,\"Priority\":0,\"Slot\":\"MainEngines\"},{\"Engineering\":{\"BlueprintID\":128673700,\"BlueprintName\":\"FSD_Shielded\",\"Engineer\":\"Professor Palin\",\"EngineerID\":300220,\"Level\":1,\"Modifiers\":[{\"Label\":\"Mass\",\"LessIsGood\":1,\"OriginalValue\":20.0,\"Value\":20.799999},{\"Label\":\"Integrity\",\"LessIsGood\":0,\"OriginalValue\":120.0,\"Value\":150.0},{\"Label\":\"FSDOptimalMass\",\"LessIsGood\":0,\"OriginalValue\":1050.0,\"Value\":1081.5},{\"Label\":\"FSDHeatRate\",\"LessIsGood\":1,\"OriginalValue\":27.0,\"Value\":24.299999}],\"Quality\":1.0},\"Item\":\"int_hyperdrive_size5_class5\",\"On\":true,\"Priority\":0,\"Slot\":\"FrameShiftDrive\"},{\"Item\":\"int_lifesupport_size4_class1\",\"On\":true,\"Priority\":2,\"Slot\":\"LifeSupport\"},{\"Engineering\":{\"BlueprintID\":128673750,\"BlueprintName\":\"PowerDistributor_PriorityWeapons\",\"Engineer\":\"Marco Qwent\",\"EngineerID\":300200,\"Level\":1,\"Modifiers\":[{\"Label\":\"WeaponsCapacity\",\"LessIsGood\":0,\"OriginalValue\":24.0,\"Value\":28.800001},{\"Label\":\"WeaponsRecharge\",\"LessIsGood\":0,\"OriginalValue\":2.6,\"Value\":3.016},{\"Label\":\"EnginesCapacity\",\"LessIsGood\":0,\"OriginalValue\":17.0,\"Value\":16.49},{\"Label\":\"EnginesRecharge\",\"LessIsGood\":0,\"OriginalValue\":1.4,\"Value\":1.358},{\"Label\":\"SystemsCapacity\",\"LessIsGood\":0,\"OriginalValue\":17.0,\"Value\":16.49},{\"Label\":\"SystemsRecharge\",\"LessIsGood\":0,\"OriginalValue\":1.4,\"Value\":1.386}],\"Quality\":1.0},\"Item\":\"int_powerdistributor_size4_class2\",\"On\":true,\"Priority\":0,\"Slot\":\"PowerDistributor\"},{\"Item\":\"int_sensors_size5_class1\",\"On\":true,\"Priority\":2,\"Slot\":\"Radar\"},{\"Item\":\"int_fueltank_size5_class3\",\"On\":true,\"Priority\":1,\"Slot\":\"FuelTank\"},{\"Item\":\"int_cargorack_size6_class1\",\"On\":true,\"Priority\":1,\"Slot\":\"Slot01_Size6\"},{\"Item\":\"int_fuelscoop_size5_class5\",\"On\":true,\"Priority\":0,\"Slot\":\"Slot02_Size5\"},{\"Engineering\":{\"BlueprintID\":128673835,\"BlueprintName\":\"ShieldGenerator_Reinforced\",\"Engineer\":\"Elvira Martuuk\",\"EngineerID\":300160,\"Level\":1,\"Modifiers\":[{\"Label\":\"ShieldGenStrength\",\"LessIsGood\":0,\"OriginalValue\":110.0,\"Value\":125.400009},{\"Label\":\"BrokenRegenRate\",\"LessIsGood\":0,\"OriginalValue\":1.87,\"Value\":1.683},{\"Label\":\"EnergyPerRegen\",\"LessIsGood\":1,\"OriginalValue\":0.6,\"Value\":0.624},{\"Label\":\"KineticResistance\",\"LessIsGood\":0,\"OriginalValue\":39.999996,\"Value\":42.699997},{\"Label\":\"ThermicResistance\",\"LessIsGood\":0,\"OriginalValue\":-20.000004,\"Value\":-14.600002},{\"Label\":\"ExplosiveResistance\",\"LessIsGood\":0,\"OriginalValue\":50.0,\"Value\":52.250004}],\"Quality\":1.0},\"Item\":\"int_shieldgenerator_size3_class4\",\"On\":true,\"Priority\":0,\"Slot\":\"Slot03_Size3\"},{\"Item\":\"int_buggybay_size2_class2\",\"On\":true,\"Priority\":0,\"Slot\":\"Slot04_Size3\"},{\"Item\":\"int_detailedsurfacescanner_tiny\",\"On\":true,\"Priority\":0,\"Slot\":\"Slot05_Size3\"},{\"Item\":\"int_cargorack_size2_class1\",\"On\":true,\"Priority\":1,\"Slot\":\"Slot06_Size2\"},{\"Item\":\"int_dockingcomputer_standard\",\"On\":true,\"Priority\":0,\"Slot\":\"Slot07_Size2\"},{\"Item\":\"int_supercruiseassist\",\"On\":true,\"Priority\":2,\"Slot\":\"Slot08_Size1\"},{\"Item\":\"bobble_trophy_political\",\"On\":true,\"Priority\":1,\"Slot\":\"Bobble01\"},{\"Item\":\"bobble_textb\",\"On\":true,\"Priority\":1,\"Slot\":\"Bobble03\"},{\"Item\":\"bobble_texto\",\"On\":true,\"Priority\":1,\"Slot\":\"Bobble04\"},{\"Item\":\"bobble_textr\",\"On\":true,\"Priority\":1,\"Slot\":\"Bobble05\"},{\"Item\":\"bobble_textg\",\"On\":true,\"Priority\":1,\"Slot\":\"Bobble06\"},{\"Item\":\"bobble_trophy_trade\",\"On\":true,\"Priority\":1,\"Slot\":\"Bobble09\"},{\"Item\":\"bobble_trophy_combat\",\"On\":true,\"Priority\":1,\"Slot\":\"Bobble10\"},{\"Item\":\"paintjob_asp_iridescenthighcolour_01\",\"On\":true,\"Priority\":1,\"Slot\":\"PaintJob\"},{\"Item\":\"int_planetapproachsuite_advanced\",\"On\":true,\"Priority\":1,\"Slot\":\"PlanetaryApproachSuite\"},{\"Item\":\"voicepack_victor\",\"On\":true,\"Priority\":1,\"Slot\":\"VesselVoice\"}],\"Ship\":\"asp\",\"ShipID\":1,\"ShipIdent\":\"BO-19A\",\"event\":\"Loadout\",\"timestamp\":\"2022-04-01T14:10:42Z\"}";

            byte[] inputBytes = Encoding.UTF8.GetBytes(loadout);

            using (var outputStream = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                    gZipStream.Write(inputBytes, 0, inputBytes.Length);

                var outputBytes = outputStream.ToArray();

                var outputbase64 = Convert.ToBase64String(outputBytes);

                outputbase64 = outputbase64.Replace("=", "%3D");
                coriolis = "https://coriolis.io/import?data=" + outputbase64;
                

               /* this.Invoke(
                            new Action(() =>
                            {
                                
                                
                                label1.Text = "plik " + e.FullPath + " został zmieniony";

                            }));



            }*/
            shipName.Text = "test";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             this.Invoke(
                            new Action(() =>
                            {
                                this.linkLabel1.LinkVisited = true;
                            }));
            // Specify that the link was visited.

            

            // Navigate to a URL.
            System.Diagnostics.Process.Start(coriolis);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listaZnalezisk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void politykaPrywatnościToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public String Translate(String word)
        {
            var toLanguage = "pl";//English
            var fromLanguage = "en";//Deutsch
            var url = "https://translate.googleapis.com/translate_a/single?client=gtx&sl="+fromLanguage+"&tl="+toLanguage+"&dt=t&q="+WebUtility.UrlEncode(word);
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {



            string texcik = "We have no valuable cargo onboard, please halt your scan.";

            var synthesizer = new SpeechSynthesizer();
           // synthesizer.SetOutputToDefaultAudioDevice();
            //synthesizer.SelectVoice("Microsoft Paulina Desktop");
            //synthesizer.Speak("Cześć chcę cię zjeść");
            //Microsoft Zira Desktop
            //synthesizer.SelectVoice("Microsoft Zira Desktop");
            //synthesizer.Speak("Cześć chcę cię zjeść");
            //Microsoft David Desktop
            synthesizer.SelectVoice("Microsoft Adam");
            synthesizer.Speak(Translate(texcik));
            //synthesizer.SelectVoice("Microsoft David Desktop");
            //synthesizer.Speak("Cześć chcę cię zjeść");
            //Console.WriteLine(" Additional Info - " + AdditionalInfo);

        }

        

        private void shipName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // this.Invoke(
             //               new Action(() =>
               //             {
                                this.linkLabel1.LinkVisited = true;
                 //           }));
            // Specify that the link was visited.



            // Navigate to a URL.
            System.Diagnostics.Process.Start(coriolis);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowID = EDF1.instance.listaZnalezisk_z.Rows.Add();
            DataGridViewRow row = EDF1.instance.listaZnalezisk_z.Rows[rowID];
            if (rowID >= 1)
                EDF1.instance.listaZnalezisk_z.Rows[rowID - 1].Selected = false;
            kolej_num = kolej_num + 1;
            row.Cells["col_time"].Value = kolej_num;
            row.Cells["col_event"].Value = "222222222222222";
            row.Cells["col_desc"].Value = "3333333333333333333";
            row.Cells["col_info"].Value = "444444444444444444";
            int nColumnIndex = 0;
            

            EDF1.instance.listaZnalezisk_z.Rows[rowID].Cells[nColumnIndex].Selected = true;

            //In case if you want to scroll down as well.
            EDF1.instance.listaZnalezisk_z.FirstDisplayedScrollingRowIndex = rowID;

            EDF1.instance.listaZnalezisk_z.FirstDisplayedScrollingRowIndex = EDF1.instance.listaZnalezisk_z.RowCount - 2;
            EDF1.instance.listaZnalezisk_z.Rows[rowID].Selected = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rowID = EDF1.instance.listaZnalezisk_z.Rows.Add();
            DataGridViewRow row = EDF1.instance.listaZnalezisk_z.Rows[rowID];
            EDF1.instance.listaZnalezisk_z.Rows[rowID].Selected = false;
        }
        
        
        private void EDF1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //nowy_plik.Stop();
            //zmien_plik.Stop();
            Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(col_time.Width.ToString() + "\n" + col_event.Width.ToString() + "\n" + col_desc.Width.ToString() + "\n" + col_info.Width.ToString() + "\n");
        }
    }
}
