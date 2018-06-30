using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
[assembly: CLSCompliant(false)]
namespace ShutdownShell
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		
		private const byte CfgTrue_Val = 60;
		private const byte CfgFalse_Val = 30;

		enum Choice
		{
			LogOff = 1,
			Hibernate = 2,
			Shutdown = 3,


		}


		// make the cfg file path in the user's app data directory
		private static string BuildCfgLocation()
		{
			StringBuilder loc = new StringBuilder();
			loc.Append(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
			if (loc[loc.Length - 1] != '\\')
			{
				loc.Append('\\');
			}

			loc.Append("ShutdownShellApp.cfg");
			return loc.ToString();

		}

		/// <summary>
		/// assemble the path to the shutdown app in the windows sytem folder
		/// </summary>
		/// <returns></returns>
		private static string BuildShutdownAppLocation()
		{
			StringBuilder name = new StringBuilder();

			name.Append("\"");
			name.Append(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86));

			if (name[name.Length-1]  != '\\')
			{
				name.Append('\\');
			}

			name.Append("shutdown.exe");
			name.Append("\"");
			return name.ToString();
		}
		private static void HandleShutdown(Choice c)
		{
			Process shutdown = new Process();
			ProcessStartInfo info = new ProcessStartInfo
			{
				FileName = BuildShutdownAppLocation(),
				WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)
			};


			switch (c)
			{
				case Choice.LogOff:
					info.Arguments = "/l";
					break;
				case Choice.Shutdown:
					info.Arguments = "/s";
					break;
				case Choice.Hibernate:
					info.Arguments = "/h";
					break;
			}

			info.CreateNoWindow = false;
			shutdown.StartInfo = info;
			shutdown.StartInfo.UseShellExecute = true;
			if (info.Arguments != null)
			{
				shutdown.Start();		
			}
		}


		private void LogOff_ButtonClick(object sender, EventArgs e)
		{
			HandleShutdown(Choice.LogOff);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			String cfgLoc;
			var ts = Size;
			TopMost = true;
			MaximizeBox = false;
			ShowInTaskbar = true;
			MinimizeBox = true;

			cfgLoc = BuildCfgLocation();
			
			
				
				
				try
				{
					using (FileStream fn = new FileStream(cfgLoc.ToString(), FileMode.Open))
					{
						if (fn.ReadByte() == CfgTrue_Val)
						{
							CheckBoxTopMost.Checked = true;
							TopMost = true;
						}
						else
						{
							CheckBoxTopMost.Checked = false;
							TopMost = false;
						}
					}
				}
				catch (IOException)
				{
					MessageBox.Show(String.Format("Caution: Unable to open {0}. Some settings not preserved", cfgLoc.ToString()));
				}
			


		}

		private void Form1_LocationChanged(object sender, EventArgs e)
		{

		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private void LogOffUser_Click(object sender, EventArgs e)
		{
			HandleShutdown(Choice.LogOff);
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private void ShutdownTheComputer_Click(object sender, EventArgs e)
		{
			var answer = MessageBox.Show("Are you sure you wish to shutdown?", "Shutdown?", MessageBoxButtons.YesNo);
			if (answer == DialogResult.Yes)
				HandleShutdown(Choice.Shutdown);

		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private void HibernatePc_Click(object sender, EventArgs e)
		{
			HandleShutdown(Choice.Hibernate);
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private void AkwaysOnTopToggle_Click(object sender, EventArgs e)
		{
			CheckBox self = (CheckBox)sender;
			self.Checked = (self.Checked != true);

			TopMost = self.Checked;
		}



		private void HibernateButton_Click(object sender, EventArgs e)
		{
			HandleShutdown(Choice.Hibernate);
		}

		private void ShutdownButton_Click(object sender, EventArgs e)
		{
			HandleShutdown(Choice.Shutdown);
		}

		private void CheckBoxTopMost_Clicked(object sender, EventArgs e)
		{
			TopMost = ((CheckBox)sender).Checked;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			String cfgLoc = BuildCfgLocation();
			try
			{
				using (FileStream fn = new FileStream(cfgLoc, FileMode.OpenOrCreate))
				{
					if (CheckBoxTopMost.Checked == true)
					{
						fn.WriteByte(CfgTrue_Val);
					}
					else
					{
						fn.WriteByte(CfgFalse_Val);
					}
				}
			}
			catch (IOException)
			{
				MessageBox.Show(String.Format("Caution: Unable to open {0}. Some settings not preserved", cfgLoc.ToString()));
			}
		}
	}
}
