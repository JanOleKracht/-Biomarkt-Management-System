using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class LoadingScreen : Form
    {
        private int laodingBarValue;
        private int timerIntervall = 50;

        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            loadingbarTimer.Start();
            loadingbarTimer.Interval = timerIntervall;
        }

        private void loadingbarTimer_Tick(object sender, EventArgs e)
        {
            laodingBarValue += 1;
            // Ladebalken Update
            UpdateProgressBar(laodingBarValue);

            // Timer stoppen wenn Ladebalken voll ist
            if (laodingBarValue >= loadingProgresBar.Maximum)
            {
                loadingbarTimer.Stop();

                // Finish laoding screen show main menu screen

                MainMenuScreen mainMenuScreen = new MainMenuScreen();
                mainMenuScreen.Show();
                // Closes/Hides the LoadingScreen
                this.Hide();
            }
        }

        // Methode die Aktualisiert den Ladebalken und das Fortschritts-Label mit dem aktuellen Wert
        private void UpdateProgressBar(int value)
        {
            // verhindert Threading-Probleme beim UI-Zugriff. Falls nötig, wird Invoke genutzt, um die Aktualisierung im UI-Thread auszuführen.
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateProgressBar), value);
            }
            else
            {
                loadingProgresBar.Value = value;
                labelLoadingProgress.Text = $"{value}%";
            }
        }
    }
}