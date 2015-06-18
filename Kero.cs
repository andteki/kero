/*
 * Copyright (c) Sallai András, 2015
 * Licenc: GNU GPL
 * Kérdőív készítő program lesz, egyszer
 * A fejlesztés kezdete: 2015-06-15
 * 
 */


using System;
using System.Drawing;
using System.Windows.Forms;

class Program01 : Form {
	Label feladatFelirat = new Label();	
	
	FlowLayoutPanel kulsoPanel = new FlowLayoutPanel();
	Panel feliratPanel = new Panel();
	Panel kerdoPanel = new Panel();
	FlowLayoutPanel gombPanel = new FlowLayoutPanel();
	
	Button kovGomb = new Button();
	Button kilepGomb = new Button();
	
	Label kerdesFelirat = new Label();
	GroupBox valaszPanel = new GroupBox();
	RadioButton radio0 = new RadioButton();
	RadioButton radio1 = new RadioButton();
	RadioButton radio2 = new RadioButton();
	RadioButton radio3 = new RadioButton();
	RadioButton radio4 = new RadioButton();
	RadioButton radio5 = new RadioButton();
	RadioButton radio6 = new RadioButton();
	
	
	public Program01() {
		kerdesFelirat.Text = "Jobban emlékszem a dolgokra, ha leírom őket";
		kerdesFelirat.Location = new Point(40, 40);
		kerdesFelirat.Width = 700;
		
		kerdoPanel.Controls.Add(kerdesFelirat);
		
		
		kovGomb.Text = "Következő";
		kilepGomb.Text = "Kilépés";
		kovGomb.BackColor = Color.LightGray;
		kilepGomb.BackColor = Color.LightGray;
		
		gombPanel.Controls.Add(kovGomb);
		gombPanel.Controls.Add(kilepGomb);
		
		
		kulsoPanel.FlowDirection = FlowDirection.TopDown;
		kulsoPanel.WrapContents = false;
		kulsoPanel.Controls.Add(feliratPanel);
		kulsoPanel.Controls.Add(kerdoPanel);
		kulsoPanel.Controls.Add(gombPanel);
		kulsoPanel.Dock = DockStyle.Fill;
		
		feliratPanel.BorderStyle = BorderStyle.FixedSingle;
		kerdoPanel.BorderStyle = BorderStyle.FixedSingle;
		gombPanel.BorderStyle = BorderStyle.FixedSingle;
		
		
		feladatFelirat.Text = "Mennyire jellemző önre az alábbi felvetés?";
		feladatFelirat.Location = new Point(5, 5);
		feladatFelirat.Width = 786;
		
		feliratPanel.Controls.Add(feladatFelirat);
		feliratPanel.Width = 786;
		feliratPanel.Height = 30;
		feliratPanel.BackColor = Color.White;
		
		kerdoPanel.Width = 786;
		kerdoPanel.Height = 300;
		kerdoPanel.BackColor = Color.White;
			
		gombPanel.Width = 786;
		gombPanel.Height = 30;
		gombPanel.BackColor = Color.White;
		
		
		this.Controls.Add(kulsoPanel);
		this.Width = 800;
		this.Height = 420;
		this.Show();
	}	
	public static void Main() {
		Application.Run(new Program01());
	}
}
