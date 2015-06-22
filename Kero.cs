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
using System.IO;

class EredmenyPanel : Panel {
	Label eredmenyFelirat = new Label();
	public EredmenyPanel() {
		eredmenyFelirat.Width = 600;
		eredmenyFelirat.Location = new Point(100, 100);
		this.Width = 786;
		this.Height = 300;
		this.BackColor = Color.White;
		this.Controls.Add(eredmenyFelirat);
	}
	public void BeallitEredmeny(int pontszam) {
		string felirat = "Az eredményed: ";
		string pontszamStr = pontszam.ToString();
		eredmenyFelirat.Text = felirat + pontszamStr;
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
	
	FlowLayoutPanel lehetosegPanel = new FlowLayoutPanel();
	Label kerdesFelirat = new Label();
	GroupBox valaszPanel = new GroupBox();
	RadioButton[] radio = new RadioButton[7];

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
				
		this.Controls.Add(kerdesFelirat);
		this.Controls.Add(valaszPanel);		
		valaszPanel.Location = new Point(100, 50);
		this.Width = 786;
		this.Height = 300;
		this.BackColor = Color.White;			
	}
	private string lekerSzoveg() {
		int szam = status + 1;
		return szam.ToString() + ".) " + kerdesek[status];
	}	
	public void Tovabb() {
		this.status++;
		if(this.status < kerdesek.Length) {
					
			kerdesFelirat.Text = lekerSzoveg();
		}
		if(this.status <= kerdesek.Length) {
			Szamit();
		}
	}
	
	public int lekerStatus() {
		return this.status;
	}
	public int lekerKerdesSzam() {
		return this.kerdesek.Length;
	}
	public void Szamit() {
		for(int i=0; i<felirat.Length; i++) {
			if(radio[i].Checked) {
				pontszam += i;
			}
		}
	}
	public int lekerPontszam() {
		return this.pontszam;
	}
}


class Program01 : Form {
	Label feladatFelirat = new Label();	
	FlowLayoutPanel kulsoPanel = new FlowLayoutPanel();
	Panel feliratPanel = new Panel();
	KerdoPanel kerdoPanel = new KerdoPanel();
	EredmenyPanel eredmenyPanel = new EredmenyPanel();	
	FlowLayoutPanel gombPanel = new FlowLayoutPanel();
	Button kovGomb = new Button();
	Button kilepGomb = new Button();
	Button nevjegyGomb = new Button();

	public Program01() {
		eredmenyPanel.Hide();
		kovGomb.Click += new EventHandler(KovGombClick);
		kilepGomb.Click += new EventHandler(KilepGombClick);
		nevjegyGomb.Click += new EventHandler(NevjegyGombClick);
		
		kovGomb.Text = "Következő";
		kilepGomb.Text = "Kilépés";
		nevjegyGomb.Text = "Névjegy";
		kovGomb.BackColor = Color.LightGray;
		kilepGomb.BackColor = Color.LightGray;
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
		kerdoPanel.Tovabb();
		int status = kerdoPanel.lekerStatus();
		if(status >= kerdoPanel.lekerKerdesSzam()) {
			kerdoPanel.Hide();
			eredmenyPanel.Show();
			feladatFelirat.Text = "Készen vagy";
			int pontszam = kerdoPanel.lekerPontszam();
			eredmenyPanel.BeallitEredmeny(pontszam);
			Mentes(pontszam.ToString());
			kovGomb.Enabled = false;
		}
	}
	private void KilepGombClick(Object sender, EventArgs e) {
		Close();
	}
	private void NevjegyGombClick(Object sender, EventArgs e) {
		MessageBox.Show(this, "Kero\n\nverzió: 1.0\n\n" + 
		"Copyright (c) Sallai András, 2015\n\n" +
		"Licenc: GNU GPL", "Névjegy");
	}
	public static void Main() {
		Application.Run(new Program01());
	}
	public void Mentes(string sor) {
		string datum = DateTime.Now.ToString();
		FileStream folyam = new FileStream("adat.txt", FileMode.Append);
		StreamWriter iro = new StreamWriter(folyam);
		iro.WriteLine(datum + " " +sor);
		iro.Close();
		folyam.Close();
		
	}
}
