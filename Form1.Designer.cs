namespace Tramvai;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
    {
            components.Dispose();
    }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip = new MenuStrip();
        fileMenuItem = new ToolStripMenuItem();
        clearToolStripMenuItem = new ToolStripMenuItem();
        settingsMenuItem = new ToolStripMenuItem();
        timeoutToolStripMenuItem = new ToolStripMenuItem();
        timeInputBox = new ToolStripTextBox();
        statisticsBySacrificesToolStripMenuItem = new ToolStripMenuItem();
        sacrificesComboBox = new ToolStripComboBox();
        calculateSurvivalRateToolStripMenuItem = new ToolStripMenuItem();
        deactivateLLMToolStripMenuItem = new ToolStripMenuItem();
        statusStrip = new StatusStrip();
        statusLabel = new ToolStripStatusLabel();
        mainPanel = new TableLayoutPanel();
        controlPanel = new Panel();
        generateManyButton = new Button();
        scenarioCountBox = new NumericUpDown();
        generateButton = new Button();
        timerLabel = new Label();
        progressBar = new ProgressBar();
        optionAButton = new Button();
        optionBButton = new Button();
        algorithmComboBox = new ComboBox();
        hybridWeightsPanel = new Panel();
        resultPanel = new Panel();
        decisionGroupBox = new GroupBox();
        decisionTextBox = new TextBox();
        webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        tabPage2 = new TabPage();
        trackStatisticsPanel = new FlowLayoutPanel();
        tabPage3 = new TabPage();
        sacrificeStatisticsPanel = new FlowLayoutPanel();
        tabPage4 = new TabPage();
        categoricSacrificeStatisticsPanel = new FlowLayoutPanel();
        decisionTimer = new System.Windows.Forms.Timer(components);
        menuStrip.SuspendLayout();
        statusStrip.SuspendLayout();
        mainPanel.SuspendLayout();
        controlPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)scenarioCountBox).BeginInit();
        resultPanel.SuspendLayout();
        decisionGroupBox.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage2.SuspendLayout();
        tabPage3.SuspendLayout();
        tabPage4.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip
        // 
        menuStrip.Items.AddRange(new ToolStripItem[] { fileMenuItem, settingsMenuItem });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(946, 24);
        menuStrip.TabIndex = 2;
        // 
        // fileMenuItem
        // 
        fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearToolStripMenuItem });
        fileMenuItem.Name = "fileMenuItem";
        fileMenuItem.Size = new Size(46, 20);
        fileMenuItem.Text = "Fișier";
        // 
        // clearToolStripMenuItem
        // 
        clearToolStripMenuItem.Name = "clearToolStripMenuItem";
        clearToolStripMenuItem.Size = new Size(109, 22);
        clearToolStripMenuItem.Text = "Curăță";
        clearToolStripMenuItem.Click += CurataToolStripMenuItem_Click;
        // 
        // settingsMenuItem
        // 
        settingsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { timeoutToolStripMenuItem, statisticsBySacrificesToolStripMenuItem, calculateSurvivalRateToolStripMenuItem, deactivateLLMToolStripMenuItem });
        settingsMenuItem.Name = "settingsMenuItem";
        settingsMenuItem.Size = new Size(48, 20);
        settingsMenuItem.Text = "Setări";
        // 
        // timeoutToolStripMenuItem
        // 
        timeoutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { timeInputBox });
        timeoutToolStripMenuItem.Name = "timeoutToolStripMenuItem";
        timeoutToolStripMenuItem.Size = new Size(240, 22);
        timeoutToolStripMenuItem.Text = "Timeout";
        // 
        // timeInputBox
        // 
        timeInputBox.Name = "timeInputBox";
        timeInputBox.Size = new Size(100, 23);
        timeInputBox.Text = "10";
        // 
        // statisticsBySacrificesToolStripMenuItem
        // 
        statisticsBySacrificesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sacrificesComboBox });
        statisticsBySacrificesToolStripMenuItem.Name = "statisticsBySacrificesToolStripMenuItem";
        statisticsBySacrificesToolStripMenuItem.Size = new Size(240, 22);
        statisticsBySacrificesToolStripMenuItem.Text = "Statistici după sacrificări";
        // 
        // sacrificesComboBox
        // 
        sacrificesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        sacrificesComboBox.Name = "sacrificesComboBox";
        sacrificesComboBox.Size = new Size(121, 23);
        // 
        // calculateSurvivalRateToolStripMenuItem
        // 
        calculateSurvivalRateToolStripMenuItem.Name = "calculateSurvivalRateToolStripMenuItem";
        calculateSurvivalRateToolStripMenuItem.Size = new Size(240, 22);
        calculateSurvivalRateToolStripMenuItem.Text = "Calculează rate de supraviețuire";
        calculateSurvivalRateToolStripMenuItem.Click += CalculeazaRateDeSupraviețuireToolStripMenuItem_Click;
        // 
        // deactivateLLMToolStripMenuItem
        // 
        deactivateLLMToolStripMenuItem.CheckOnClick = true;
        deactivateLLMToolStripMenuItem.Name = "deactivateLLMToolStripMenuItem";
        deactivateLLMToolStripMenuItem.Size = new Size(240, 22);
        deactivateLLMToolStripMenuItem.Text = "Deactivează LLM";
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
        statusStrip.Location = new Point(0, 666);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(946, 22);
        statusStrip.SizingGrip = false;
        statusStrip.TabIndex = 1;
        // 
        // statusLabel
        // 
        statusLabel.Name = "statusLabel";
        statusLabel.Size = new Size(109, 17);
        statusLabel.Text = "Scenarii generate: 0";
        // 
        // mainPanel
        // 
        mainPanel.ColumnCount = 2;
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainPanel.Controls.Add(controlPanel, 0, 0);
        mainPanel.Controls.Add(resultPanel, 1, 0);
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(3, 3);
        mainPanel.Name = "mainPanel";
        mainPanel.RowCount = 1;
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        mainPanel.Size = new Size(932, 608);
        mainPanel.TabIndex = 0;
        // 
        // controlPanel
        // 
        controlPanel.Controls.Add(generateManyButton);
        controlPanel.Controls.Add(scenarioCountBox);
        controlPanel.Controls.Add(generateButton);
        controlPanel.Controls.Add(timerLabel);
        controlPanel.Controls.Add(progressBar);
        controlPanel.Controls.Add(optionAButton);
        controlPanel.Controls.Add(optionBButton);
        controlPanel.Controls.Add(algorithmComboBox);
        controlPanel.Controls.Add(hybridWeightsPanel);
        controlPanel.Dock = DockStyle.Fill;
        controlPanel.Location = new Point(3, 3);
        controlPanel.Name = "controlPanel";
        controlPanel.Size = new Size(244, 602);
        controlPanel.TabIndex = 0;
        // 
        // generateManyButton
        // 
        generateManyButton.Location = new Point(150, 39);
        generateManyButton.Name = "generateManyButton";
        generateManyButton.Size = new Size(75, 23);
        generateManyButton.TabIndex = 8;
        generateManyButton.Text = "Gen. multe";
        generateManyButton.UseVisualStyleBackColor = true;
        generateManyButton.Click += BtnGenereazaMulte_Click;
        // 
        // scenarioCountBox
        // 
        scenarioCountBox.Location = new Point(150, 10);
        scenarioCountBox.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        scenarioCountBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        scenarioCountBox.Name = "scenarioCountBox";
        scenarioCountBox.Size = new Size(72, 23);
        scenarioCountBox.TabIndex = 7;
        scenarioCountBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // generateButton
        // 
        generateButton.Location = new Point(22, 10);
        generateButton.Name = "generateButton";
        generateButton.Size = new Size(122, 52);
        generateButton.TabIndex = 0;
        generateButton.Text = "Generează scenariu";
        generateButton.Click += BtnGenereaza_Click;
        // 
        // timerLabel
        // 
        timerLabel.Location = new Point(22, 75);
        timerLabel.Name = "timerLabel";
        timerLabel.Size = new Size(100, 23);
        timerLabel.TabIndex = 1;
        timerLabel.Text = "Timp rămas: 10";
        // 
        // progressBar
        // 
        progressBar.Location = new Point(22, 101);
        progressBar.Maximum = 10;
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(200, 20);
        progressBar.TabIndex = 2;
        progressBar.Value = 10;
        // 
        // optionAButton
        // 
        optionAButton.Enabled = false;
        optionAButton.Location = new Point(22, 140);
        optionAButton.Name = "optionAButton";
        optionAButton.Size = new Size(200, 30);
        optionAButton.TabIndex = 3;
        optionAButton.Text = "Schimbă traiectoria (spre A)";
        optionAButton.Click += BtnOptiuneaA_Click;
        // 
        // optionBButton
        // 
        optionBButton.Enabled = false;
        optionBButton.Location = new Point(22, 180);
        optionBButton.Name = "optionBButton";
        optionBButton.Size = new Size(200, 30);
        optionBButton.TabIndex = 4;
        optionBButton.Text = "Nu face nimic (rămâne la B)";
        optionBButton.Click += BtnOptiuneaB_Click;
        // 
        // algorithmComboBox
        // 
        algorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        algorithmComboBox.Location = new Point(22, 220);
        algorithmComboBox.Name = "algorithmComboBox";
        algorithmComboBox.Size = new Size(200, 23);
        algorithmComboBox.TabIndex = 5;
        algorithmComboBox.SelectedIndexChanged += ComboAlgoritmSelectat_SelectedIndexChanged;
        // 
        // hybridWeightsPanel
        // 
        hybridWeightsPanel.Location = new Point(0, 260);
        hybridWeightsPanel.Name = "hybridWeightsPanel";
        hybridWeightsPanel.Size = new Size(244, 345);
        hybridWeightsPanel.TabIndex = 6;
        hybridWeightsPanel.Visible = false;
        // 
        // resultPanel
        // 
        resultPanel.Controls.Add(decisionGroupBox);
        resultPanel.Controls.Add(webView21);
        resultPanel.Dock = DockStyle.Fill;
        resultPanel.Location = new Point(253, 3);
        resultPanel.Name = "resultPanel";
        resultPanel.Size = new Size(676, 602);
        resultPanel.TabIndex = 1;
        // 
        // decisionGroupBox
        // 
        decisionGroupBox.Controls.Add(decisionTextBox);
        decisionGroupBox.Dock = DockStyle.Fill;
        decisionGroupBox.Location = new Point(0, 183);
        decisionGroupBox.Name = "decisionGroupBox";
        decisionGroupBox.Size = new Size(676, 419);
        decisionGroupBox.TabIndex = 0;
        decisionGroupBox.TabStop = false;
        decisionGroupBox.Text = "Decizii";
        // 
        // decisionTextBox
        // 
        decisionTextBox.Dock = DockStyle.Fill;
        decisionTextBox.Location = new Point(3, 19);
        decisionTextBox.Multiline = true;
        decisionTextBox.Name = "decisionTextBox";
        decisionTextBox.ReadOnly = true;
        decisionTextBox.Size = new Size(670, 397);
        decisionTextBox.TabIndex = 0;
        // 
        // webView21
        // 
        webView21.AllowExternalDrop = true;
        webView21.CreationProperties = null;
        webView21.DefaultBackgroundColor = Color.White;
        webView21.Dock = DockStyle.Top;
        webView21.Enabled = false;
        webView21.Location = new Point(0, 0);
        webView21.Name = "webView21";
        webView21.Size = new Size(676, 183);
        webView21.TabIndex = 1;
        webView21.ZoomFactor = 1D;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Controls.Add(tabPage3);
        tabControl1.Controls.Add(tabPage4);
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(0, 24);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(946, 642);
        tabControl1.TabIndex = 3;
        tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(mainPanel);
        tabPage1.Location = new Point(4, 24);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(938, 614);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Principal";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(trackStatisticsPanel);
        tabPage2.Location = new Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(938, 614);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Statistici după cale";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // trackStatisticsPanel
        // 
        trackStatisticsPanel.AutoScroll = true;
        trackStatisticsPanel.Dock = DockStyle.Fill;
        trackStatisticsPanel.Location = new Point(3, 3);
        trackStatisticsPanel.Name = "trackStatisticsPanel";
        trackStatisticsPanel.Size = new Size(932, 608);
        trackStatisticsPanel.TabIndex = 1;
        // 
        // tabPage3
        // 
        tabPage3.Controls.Add(sacrificeStatisticsPanel);
        tabPage3.Location = new Point(4, 24);
        tabPage3.Name = "tabPage3";
        tabPage3.Padding = new Padding(3);
        tabPage3.Size = new Size(938, 614);
        tabPage3.TabIndex = 2;
        tabPage3.Text = "Statistici după sacrificări";
        tabPage3.UseVisualStyleBackColor = true;
        // 
        // sacrificeStatisticsPanel
        // 
        sacrificeStatisticsPanel.AutoScroll = true;
        sacrificeStatisticsPanel.Dock = DockStyle.Fill;
        sacrificeStatisticsPanel.Location = new Point(3, 3);
        sacrificeStatisticsPanel.Name = "sacrificeStatisticsPanel";
        sacrificeStatisticsPanel.Size = new Size(932, 608);
        sacrificeStatisticsPanel.TabIndex = 0;
        // 
        // tabPage4
        // 
        tabPage4.Controls.Add(categoricSacrificeStatisticsPanel);
        tabPage4.Location = new Point(4, 24);
        tabPage4.Name = "tabPage4";
        tabPage4.Padding = new Padding(3);
        tabPage4.Size = new Size(938, 614);
        tabPage4.TabIndex = 3;
        tabPage4.Text = "Statistici după sacrificări (categorii)";
        tabPage4.UseVisualStyleBackColor = true;
        // 
        // categoricSacrificeStatisticsPanel
        // 
        categoricSacrificeStatisticsPanel.AutoScroll = true;
        categoricSacrificeStatisticsPanel.Dock = DockStyle.Fill;
        categoricSacrificeStatisticsPanel.Location = new Point(3, 3);
        categoricSacrificeStatisticsPanel.Name = "categoricSacrificeStatisticsPanel";
        categoricSacrificeStatisticsPanel.Size = new Size(932, 608);
        categoricSacrificeStatisticsPanel.TabIndex = 0;
        // 
        // decisionTimer
        // 
        decisionTimer.Interval = 1000;
        decisionTimer.Tick += DecisionTimer_Tick;
        // 
        // Form1
        // 
        ClientSize = new Size(946, 688);
        Controls.Add(tabControl1);
        Controls.Add(statusStrip);
        Controls.Add(menuStrip);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MainMenuStrip = menuStrip;
        Name = "Form1";
        Text = "Problema tramvaiului";
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        mainPanel.ResumeLayout(false);
        controlPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)scenarioCountBox).EndInit();
        resultPanel.ResumeLayout(false);
        decisionGroupBox.ResumeLayout(false);
        decisionGroupBox.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage2.ResumeLayout(false);
        tabPage3.ResumeLayout(false);
        tabPage4.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileMenuItem;
    private ToolStripMenuItem settingsMenuItem;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel statusLabel;

    private TableLayoutPanel mainPanel;
    private Panel controlPanel;
    private Button generateButton;
    private Label timerLabel;
    private ProgressBar progressBar;
    private Button optionAButton;
    private Button optionBButton;
    private ComboBox algorithmComboBox;
    private Panel hybridWeightsPanel;

    private Panel resultPanel;
    private GroupBox decisionGroupBox;

    #endregion

    private TextBox decisionTextBox;
    private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private FlowLayoutPanel trackStatisticsPanel;
    private System.Windows.Forms.Timer decisionTimer;
    private TabPage tabPage3;
    private FlowLayoutPanel sacrificeStatisticsPanel;
    private ToolStripMenuItem timeoutToolStripMenuItem;
    private ToolStripTextBox timeInputBox;
    private ToolStripMenuItem statisticsBySacrificesToolStripMenuItem;
    private ToolStripComboBox sacrificesComboBox;
    private Button generateManyButton;
    private NumericUpDown scenarioCountBox;
    private ToolStripMenuItem calculateSurvivalRateToolStripMenuItem;
    private ToolStripMenuItem clearToolStripMenuItem;
    private ToolStripMenuItem deactivateLLMToolStripMenuItem;
    private TabPage tabPage4;
    private FlowLayoutPanel categoricSacrificeStatisticsPanel;
}
