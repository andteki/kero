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
	FlowLayoutPanel lehetosegPanel = new FlowLayoutPanel();
	
	
	Button kovGomb = new Button();
	Button kilepGomb = new Button();
	
	Label kerdesFelirat = new Label();
	GroupBox valaszPanel = new GroupBox();
	
	RadioButton[] radio = new RadioButton[7];	
	
	string[] kerdesek = {
		"Jobban emlékszem a dolgokra, ha leírom őket",
		"Olvasás közben \"hallom\" a szavakat a fejemben, vagy önkéntelenül mormolok",
		"Meg kell, hogy beszéljek dolgokat valakivel ahhoz, hogy jobban megértsem őket",
		"Nem szeretem sem az írott sem a szóbeli utasításokat. Inkább egyszerűen csak hozzáfogok a feladathoz",
		"Képes vagyok arra, hogy \"fejben lássak\" dolgokat, azaz hogy magam elé képzeljem."
	};
	
	int status = 0;

	public Program01() {
		kovGomb.Click += new EventHandler(KovGombClick);
		
		lehetosegPanel.FlowDirection = FlowDirection.TopDown;
		lehetosegPanel.WrapContents = false;
		lehetosegPanel.Dock = DockStyle.Fill;
		
		valaszPanel.Controls.Add(lehetosegPanel);
		valaszPanel.Height = 230;
		
		string[] felirat = {
			"Egyáltalán nem jellemző", 
			"Kicsit jellemző",			
			"Kicsinél jobban jellemző",
			"Közepesen jellemző",
			"Nagyon jellemző",
			"Nagyon, negyon jellemző",
			"Teljesen jellemző"
			};
		
		for(int i=0; i<7; i++) {
			radio[i] = new RadioButton();
			lehetosegPanel.Controls.Add(radio[i]);
			radio[i].Text = felirat[i];
			radio[i].Width = 200;
		}		
		
		kerdesFelirat.Text = kerdesek[0];
		kerdesFelirat.Location = new Point(40, 20);
		kerdesFelirat.Width = 700;
		
		kerdoPanel.Controls.Add(kerdesFelirat);
		kerdoPanel.Controls.Add(valaszPanel);
		
		valaszPanel.Location = new Point(100, 50);		
		
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
	private void KovGombClick(Object sender, EventArgs e) {
		if(status<4) {
			status++;
		}else {
			status = 0;
		}
		kerdesFelirat.Text = kerdesek[status];
	}

	public static void Main() {
		Application.Run(new Program01());
	}
}
