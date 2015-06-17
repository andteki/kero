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
	Panel panel1 = new Panel();
	Label label1 = new Label();
	RadioButton radio1 = new RadioButton();
	public Program01() {
		label1.Text = "1.) Jobban emlékszem a dolgokra" + 
			"akkor, ha leírom őket.";
		label1.Location = new Point(100, 50);
		label1.Width = 600;
		
		radio1.Text = "Kicsit jellemző";		
		radio1.Location = new Point(100, 100);
		
		panel1.Controls.Add(radio1);
		panel1.Controls.Add(label1);
		
		//panel1.BackColor = Color.Blue;
		panel1.Width = 600;
		panel1.Height = 500;		
		
		
		this.Controls.Add(panel1);
		
		this.Width = 800;
		this.Height = 600;
		this.Show();
	}	
	public static void Main() {
		Application.Run(new Program01());
	}
}
