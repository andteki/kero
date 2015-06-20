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

class EredmenyPanel : Panel {
	Label eredmenyLabel = new Label();
	public EredmenyPanel() {
		eredmenyLabel.Location = new Point(50, 100);
		eredmenyLabel.Width = 300;
		this.Width = 786;
		this.Height = 300;
		this.BackColor = Color.White;
		this.Dock = DockStyle.Fill;
		this.Controls.Add(eredmenyLabel);			
	}
	public void beallitEredmeny(int eredmeny) {
		string felirat = "Az elért eredményed: ";
		string szam = eredmeny.ToString();
		eredmenyLabel.Text = felirat + szam;
	}
}

class KerdoPanel : Panel {
	string[] kerdesek = {
		"Jobban emlékszem a dolgokra, ha leírom őket",
		"Olvasás közben \"hallom\" a szavakat a fejemben, vagy önkéntelenül mormolok",
		"Meg kell, hogy beszéljek dolgokat valakivel ahhoz, hogy jobban megértsem őket",
		"Nem szeretem sem az írott sem a szóbeli utasításokat. Inkább egyszerűen csak hozzáfogok a feladathoz",
		"Képes vagyok arra, hogy \"fejben lássak\" dolgokat, azaz hogy magam elé képzeljem."
	};

	static string[] felirat = {
		"Egyáltalán nem jellemző", 
		"Kicsit jellemző",			
		"Kicsinél jobban jellemző",
		"Közepesen jellemző",
		"Nagyon jellemző",
		"Nagyon, negyon jellemző",
		"Teljesen jellemző"
	};

	Label kerdesFelirat = new Label();
	GroupBox valaszPanel = new GroupBox();	
	RadioButton[] radio = new RadioButton[felirat.Length];
	FlowLayoutPanel lehetosegPanel = new FlowLayoutPanel();
	
	int status = 0;
	int pontszam = 0;
	
	public KerdoPanel() {
		lehetosegPanel.FlowDirection = FlowDirection.TopDown;
		lehetosegPanel.WrapContents = false;
		lehetosegPanel.Dock = DockStyle.Fill;
		valaszPanel.Controls.Add(lehetosegPanel);
		valaszPanel.Height = 230;
		kerdesFelirat.Text = lekerSzoveg();
		kerdesFelirat.Location = new Point(40, 20);
		kerdesFelirat.Width = 700;
		for(int i=0; i<felirat.Length; i++) {
			radio[i] = new RadioButton();
			lehetosegPanel.Controls.Add(radio[i]);
			radio[i].Text = felirat[i];
			radio[i].Width = 200;
		}		
		Controls.Add(kerdesFelirat);
		Controls.Add(valaszPanel);		
		valaszPanel.Location = new Point(100, 50);
		Width = 786;
		Height = 300;
		BackColor = Color.White;		
	}
	public int lekerPontszam() {
		return this.pontszam;
	}
	private string lekerSzoveg() {
		int szam = status + 1;
		return szam.ToString() + ".) " + kerdesek[status];
	}
	public void tovabb() {
		this.status++;
		if (this.status < kerdesekSzama()) {
			szamit();
			kerdesFelirat.Text = lekerSzoveg();			
		}
	}
	public void szamit() {
		for(int i=0;i<felirat.Length; i++) {
			if (radio[i].Checked) {
				pontszam += i;
			}
		}
	}
	public int kerdesekSzama() {
		return kerdesek.Length;
	}
	public int lekerStatus() {
		return status;
	}
}

class Program01 : Form {
	Label feladatFelirat = new Label();		
	FlowLayoutPanel kulsoPanel = new FlowLayoutPanel();
	Panel feliratPanel = new Panel();	
	FlowLayoutPanel gombPanel = new FlowLayoutPanel();	
	Button kovGomb = new Button();
	Button kilepGomb = new Button();
	Button nevjegyGomb = new Button();
	KerdoPanel kerdoPanel = new KerdoPanel();
	EredmenyPanel eredmenyPanel = new EredmenyPanel();

	public Program01() {
		kovGomb.Click += new EventHandler(KovGombClick);
		kilepGomb.Click += new EventHandler(KilepGombClick);
		nevjegyGomb.Click += new EventHandler(NevjegyGombClick);
		
		
		kovGomb.Text = "Következő";		
		kovGomb.BackColor = Color.LightGray;
		kilepGomb.Text = "Kilépés";
		kilepGomb.BackColor = Color.LightGray;
		nevjegyGomb.Text = "Névjegy";
		nevjegyGomb.BackColor = Color.LightGray;
		
		
		gombPanel.Controls.Add(kovGomb);
		gombPanel.Controls.Add(kilepGomb);
		gombPanel.Controls.Add(nevjegyGomb);
		
		kulsoPanel.FlowDirection = FlowDirection.TopDown;
		kulsoPanel.WrapContents = false;
		kulsoPanel.Controls.Add(feliratPanel);
		kulsoPanel.Controls.Add(kerdoPanel);
		kulsoPanel.Controls.Add(eredmenyPanel);		
		kulsoPanel.Controls.Add(gombPanel);
		kulsoPanel.Dock = DockStyle.Fill;
		eredmenyPanel.Hide();
		
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
			
		gombPanel.Width = 786;
		gombPanel.Height = 30;
		gombPanel.BackColor = Color.White;
		
		this.StartPosition = FormStartPosition.CenterScreen;
		this.Controls.Add(kulsoPanel);
		this.Width = 800;
		this.Height = 420;
		this.Show();
	}
	private void KovGombClick(Object sender, EventArgs e) {
		kerdoPanel.tovabb();
		int status = kerdoPanel.lekerStatus();
		if(status >= kerdoPanel.kerdesekSzama()) {
			kerdoPanel.Hide();
			eredmenyPanel.Show();
			feladatFelirat.Text = "Készen vagy";
			int pontszam = kerdoPanel.lekerPontszam();
			eredmenyPanel.beallitEredmeny(pontszam);
		}
	}
	private void KilepGombClick(Object sender, EventArgs e) {
		Close();
	}
	private void NevjegyGombClick(Object sender, EventArgs e) {
		MessageBox.Show(this, "Kero 0.9\n\nCopyright (c) Sallai András, 2015\n\nLicenc: GNU GPL");
	}
	public static void Main() {
		Application.Run(new Program01());
	}
}
