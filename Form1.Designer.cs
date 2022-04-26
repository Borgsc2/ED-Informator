
namespace ED_Informator
{
    partial class EDF1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdrLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.saldoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saldoValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.szacowZarobLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.szacowZarobValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.rzeczZarobLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.rzeczZarobValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sprawdźAktualizacjęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikacjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.politykaPrywatnościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdrName = new System.Windows.Forms.Label();
            this.shipLabel = new System.Windows.Forms.Label();
            this.outfitLabel = new System.Windows.Forms.Label();
            this.test_label = new System.Windows.Forms.Label();
            this.outfitValue = new System.Windows.Forms.Label();
            this.systemLabel = new System.Windows.Forms.Label();
            this.systemValue = new System.Windows.Forms.Label();
            this.stationLabel = new System.Windows.Forms.Label();
            this.stationName = new System.Windows.Forms.Label();
            this.listaZnalezisk = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.shipName = new System.Windows.Forms.LinkLabel();
            this.col_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaZnalezisk)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdrLabel
            // 
            this.cmdrLabel.AutoSize = true;
            this.cmdrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdrLabel.Location = new System.Drawing.Point(12, 24);
            this.cmdrLabel.Name = "cmdrLabel";
            this.cmdrLabel.Size = new System.Drawing.Size(39, 13);
            this.cmdrLabel.TabIndex = 0;
            this.cmdrLabel.Text = "Cmdr:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(297, 233);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(19, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "78";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saldoLabel,
            this.saldoValue,
            this.szacowZarobLabel,
            this.szacowZarobValue,
            this.rzeczZarobLabel,
            this.rzeczZarobValue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(954, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // saldoLabel
            // 
            this.saldoLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.saldoLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.saldoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saldoLabel.Name = "saldoLabel";
            this.saldoLabel.Size = new System.Drawing.Size(44, 19);
            this.saldoLabel.Text = "Saldo:";
            // 
            // saldoValue
            // 
            this.saldoValue.AutoSize = false;
            this.saldoValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.saldoValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.saldoValue.Name = "saldoValue";
            this.saldoValue.Size = new System.Drawing.Size(130, 19);
            this.saldoValue.Text = "999 999 999 999";
            // 
            // szacowZarobLabel
            // 
            this.szacowZarobLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.szacowZarobLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.szacowZarobLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.szacowZarobLabel.Name = "szacowZarobLabel";
            this.szacowZarobLabel.Size = new System.Drawing.Size(123, 19);
            this.szacowZarobLabel.Text = "Szacowany zarobek:";
            this.szacowZarobLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // szacowZarobValue
            // 
            this.szacowZarobValue.AutoSize = false;
            this.szacowZarobValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.szacowZarobValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.szacowZarobValue.Name = "szacowZarobValue";
            this.szacowZarobValue.Size = new System.Drawing.Size(130, 19);
            this.szacowZarobValue.Text = "999 999 999";
            // 
            // rzeczZarobLabel
            // 
            this.rzeczZarobLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.rzeczZarobLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.rzeczZarobLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.rzeczZarobLabel.Name = "rzeczZarobLabel";
            this.rzeczZarobLabel.Size = new System.Drawing.Size(130, 19);
            this.rzeczZarobLabel.Text = "Rzeczywisty zarobek:";
            this.rzeczZarobLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rzeczZarobValue
            // 
            this.rzeczZarobValue.AutoSize = false;
            this.rzeczZarobValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.rzeczZarobValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.rzeczZarobValue.Name = "rzeczZarobValue";
            this.rzeczZarobValue.Size = new System.Drawing.Size(130, 19);
            this.rzeczZarobValue.Text = "999 999 999";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(954, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sprawdźAktualizacjęToolStripMenuItem,
            this.oAplikacjiToolStripMenuItem,
            this.politykaPrywatnościToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.helpToolStripMenuItem.Text = "Pomoc";
            // 
            // sprawdźAktualizacjęToolStripMenuItem
            // 
            this.sprawdźAktualizacjęToolStripMenuItem.Name = "sprawdźAktualizacjęToolStripMenuItem";
            this.sprawdźAktualizacjęToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.sprawdźAktualizacjęToolStripMenuItem.Text = "Sprawdź Aktualizację";
            // 
            // oAplikacjiToolStripMenuItem
            // 
            this.oAplikacjiToolStripMenuItem.Name = "oAplikacjiToolStripMenuItem";
            this.oAplikacjiToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.oAplikacjiToolStripMenuItem.Text = "O Aplikacji";
            // 
            // politykaPrywatnościToolStripMenuItem
            // 
            this.politykaPrywatnościToolStripMenuItem.Name = "politykaPrywatnościToolStripMenuItem";
            this.politykaPrywatnościToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.politykaPrywatnościToolStripMenuItem.Text = "Polityka Prywatności";
            this.politykaPrywatnościToolStripMenuItem.Click += new System.EventHandler(this.politykaPrywatnościToolStripMenuItem_Click);
            // 
            // cmdrName
            // 
            this.cmdrName.Location = new System.Drawing.Point(57, 24);
            this.cmdrName.Name = "cmdrName";
            this.cmdrName.Size = new System.Drawing.Size(159, 12);
            this.cmdrName.TabIndex = 5;
            this.cmdrName.Text = "Unnamed Commandor";
            // 
            // shipLabel
            // 
            this.shipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.shipLabel.Location = new System.Drawing.Point(222, 25);
            this.shipLabel.Name = "shipLabel";
            this.shipLabel.Size = new System.Drawing.Size(85, 12);
            this.shipLabel.TabIndex = 6;
            this.shipLabel.Text = "Statek:";
            this.shipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outfitLabel
            // 
            this.outfitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.outfitLabel.Location = new System.Drawing.Point(478, 25);
            this.outfitLabel.Name = "outfitLabel";
            this.outfitLabel.Size = new System.Drawing.Size(85, 13);
            this.outfitLabel.TabIndex = 7;
            this.outfitLabel.Text = "Strój:";
            this.outfitLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // test_label
            // 
            this.test_label.Location = new System.Drawing.Point(509, 187);
            this.test_label.Name = "test_label";
            this.test_label.Size = new System.Drawing.Size(159, 13);
            this.test_label.TabIndex = 8;
            this.test_label.Text = "dddd";
            // 
            // outfitValue
            // 
            this.outfitValue.AutoSize = true;
            this.outfitValue.Location = new System.Drawing.Point(569, 25);
            this.outfitValue.Name = "outfitValue";
            this.outfitValue.Size = new System.Drawing.Size(93, 13);
            this.outfitValue.TabIndex = 9;
            this.outfitValue.Text = "The outfit was lost";
            // 
            // systemLabel
            // 
            this.systemLabel.AutoSize = true;
            this.systemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.systemLabel.Location = new System.Drawing.Point(12, 45);
            this.systemLabel.Name = "systemLabel";
            this.systemLabel.Size = new System.Drawing.Size(51, 13);
            this.systemLabel.TabIndex = 10;
            this.systemLabel.Text = "System:";
            // 
            // systemValue
            // 
            this.systemValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemValue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.systemValue.Location = new System.Drawing.Point(69, 45);
            this.systemValue.Name = "systemValue";
            this.systemValue.Size = new System.Drawing.Size(147, 13);
            this.systemValue.TabIndex = 11;
            this.systemValue.Text = "Wsysneła Cię czara dziurka";
            this.systemValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stationLabel
            // 
            this.stationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.stationLabel.Location = new System.Drawing.Point(222, 45);
            this.stationLabel.Name = "stationLabel";
            this.stationLabel.Size = new System.Drawing.Size(60, 13);
            this.stationLabel.TabIndex = 12;
            this.stationLabel.Text = "Station:";
            // 
            // stationName
            // 
            this.stationName.AutoSize = true;
            this.stationName.Location = new System.Drawing.Point(313, 45);
            this.stationName.Name = "stationName";
            this.stationName.Size = new System.Drawing.Size(35, 13);
            this.stationName.TabIndex = 13;
            this.stationName.Text = "label5";
            // 
            // listaZnalezisk
            // 
            this.listaZnalezisk.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaZnalezisk.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listaZnalezisk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaZnalezisk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_time,
            this.col_event,
            this.col_desc,
            this.col_info});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaZnalezisk.DefaultCellStyle = dataGridViewCellStyle2;
            this.listaZnalezisk.EnableHeadersVisualStyles = false;
            this.listaZnalezisk.Location = new System.Drawing.Point(3, 0);
            this.listaZnalezisk.Name = "listaZnalezisk";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaZnalezisk.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listaZnalezisk.RowHeadersVisible = false;
            this.listaZnalezisk.Size = new System.Drawing.Size(932, 379);
            this.listaZnalezisk.TabIndex = 14;
            this.listaZnalezisk.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaZnalezisk_CellContentClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(955, 417);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listaZnalezisk);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(947, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.test_label);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(947, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(448, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // shipName
            // 
            this.shipName.ActiveLinkColor = System.Drawing.Color.Blue;
            this.shipName.DisabledLinkColor = System.Drawing.Color.Black;
            this.shipName.Location = new System.Drawing.Point(313, 25);
            this.shipName.Name = "shipName";
            this.shipName.Size = new System.Drawing.Size(159, 13);
            this.shipName.TabIndex = 16;
            this.shipName.TabStop = true;
            this.shipName.Text = "Unidentified Ship";
            this.shipName.VisitedLinkColor = System.Drawing.Color.Blue;
            this.shipName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.shipName_LinkClicked);
            // 
            // col_time
            // 
            this.col_time.HeaderText = "Czas";
            this.col_time.Name = "col_time";
            // 
            // col_event
            // 
            this.col_event.HeaderText = "Zdarzenie";
            this.col_event.Name = "col_event";
            // 
            // col_desc
            // 
            this.col_desc.HeaderText = "Opis";
            this.col_desc.Name = "col_desc";
            // 
            // col_info
            // 
            this.col_info.HeaderText = "Informacje";
            this.col_info.Name = "col_info";
            // 
            // EDF1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = global::ED_Informator.Properties.Settings.Default.Size;
            this.Controls.Add(this.shipName);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.stationName);
            this.Controls.Add(this.stationLabel);
            this.Controls.Add(this.systemValue);
            this.Controls.Add(this.systemLabel);
            this.Controls.Add(this.outfitValue);
            this.Controls.Add(this.outfitLabel);
            this.Controls.Add(this.shipLabel);
            this.Controls.Add(this.cmdrName);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cmdrLabel);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ED_Informator.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::ED_Informator.Properties.Settings.Default, "Size", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Location = global::ED_Informator.Properties.Settings.Default.Location;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(970, 544);
            this.Name = "EDF1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ED Informator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EDF1_FormClosed);
            this.Load += new System.EventHandler(this.EDF1_Load);
            this.Shown += new System.EventHandler(this.EDF1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaZnalezisk)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cmdrLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel saldoLabel;
        private System.Windows.Forms.ToolStripStatusLabel saldoValue;
        private System.Windows.Forms.ToolStripStatusLabel szacowZarobLabel;
        private System.Windows.Forms.ToolStripStatusLabel szacowZarobValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label cmdrName;
        private System.Windows.Forms.Label shipLabel;
        private System.Windows.Forms.Label outfitLabel;
        private System.Windows.Forms.Label test_label;
        private System.Windows.Forms.Label outfitValue;
        private System.Windows.Forms.Label systemLabel;
        private System.Windows.Forms.Label systemValue;
        private System.Windows.Forms.Label stationLabel;
        private System.Windows.Forms.Label stationName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel rzeczZarobLabel;
        private System.Windows.Forms.ToolStripStatusLabel rzeczZarobValue;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem sprawdźAktualizacjęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oAplikacjiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem politykaPrywatnościToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.LinkLabel shipName;
        private System.Windows.Forms.DataGridView listaZnalezisk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_event;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_info;
    }
}

