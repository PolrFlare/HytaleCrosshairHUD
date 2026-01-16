using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HytaleCrosshairHUD
{
    public partial class Window : Form
    {

        private string selectedDefaultReticle = null;
        private string selectedMeleeReticle = null;
        public Window()
        {
            string logoPath = Path.Combine(Application.StartupPath, "Assets", "hytale_logo.png");
            InitializeComponent();
            _ = extractAssets();
        }

        // the assets folder is naturally .zipped as of 1/15/2026
        // in order to edit anything in assets.zip we atually have to extract the folder because the zip file seems to have signature validation (protection)
        private async Task extractAssets()
        {
            extractStatus.Visible = true;
            string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string latestPath = Path.Combine(
                roaming,
                "Hytale",
                "install",
                "release",
                "package",
                "game",
                "latest"
            );

            string assetsFolder = Path.Combine(latestPath, "Assets");
            string assetsZip = Path.Combine(latestPath, "Assets.zip");
            string assetsBackupZip = Path.Combine(latestPath, "Assets_backup.zip");
            if (Directory.Exists(assetsFolder))
            {
                extractStatus.Text = "";
                extractStatus.Visible = false;
                default_btn.Visible = true;
                default_label.Visible = true;
                melee_label.Visible = true;
                melee_btn.Visible = true;
                apply_btn.Visible = true;
                return;
            }
            if (!File.Exists(assetsZip))
            {
                extractStatus.Text = "Assets extracted";
                extractStatus.Visible = false;
                default_btn.Visible = true;
                default_label.Visible = true;
                melee_label.Visible = true;
                melee_btn.Visible = true;
                apply_btn.Visible = true;
                return;
            }
            extractStatus.Text = "Extracting assets... 0%";
            await Task.Run(() =>
            {
                using (ZipArchive archive = ZipFile.OpenRead(assetsZip))
                {
                    int totalEntries = archive.Entries.Count;
                    int extracted = 0;

                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string destinationPath = Path.Combine(assetsFolder, entry.FullName);
                        if (string.IsNullOrEmpty(entry.Name))
                        {
                            Directory.CreateDirectory(destinationPath);
                        }
                        else
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                            entry.ExtractToFile(destinationPath, overwrite: false);
                        }
                        extracted++;
                        int percent = (int)((extracted / (double)totalEntries) * 100);
                        Invoke(new Action(() =>
                        {
                            extractStatus.Text = $"Extracting assets... {percent}%";
                        }));
                    }
                }
            });
            if (!File.Exists(assetsBackupZip))
            {
                File.Move(assetsZip, assetsBackupZip);
            }
            extractStatus.Text = "Assets extracted";
            extractStatus.Visible = false;
            default_btn.Visible = true;
            default_label.Visible = true;
            melee_label.Visible = true;
            melee_btn.Visible = true;
            apply_btn.Visible = true;
        }

        private void Window_Load(object sender, EventArgs e)
        {
        }

        private string PickPngFile(string title)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "PNG Images (*.png)|*.png";
                dialog.Title = title;

                return dialog.ShowDialog() == DialogResult.OK
                    ? dialog.FileName
                    : null;
            }
        }

        private string GetReticlePath(string fileName)
        {
            string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            return Path.Combine(
                roaming,
                "Hytale",
                "install",
                "release",
                "package",
                "game",
                "latest",
                "Assets",
                "Common",
                "UI",
                "Crosshairs",
                fileName
            );
        }

        private void default_btn_Click(object sender, EventArgs e)
        {
            string file = PickPngFile("Select Default Reticle");

            if (file != null)
            {
                selectedDefaultReticle = file;
                default_btn.Text = Path.GetFileName(file);
            }
        }

        private void melee_btn_Click(object sender, EventArgs e)
        {
            string file = PickPngFile("Select Melee Reticle");

            if (file != null)
            {
                selectedMeleeReticle = file;
                melee_btn.Text = Path.GetFileName(file);
            }
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            if (selectedDefaultReticle == null && selectedMeleeReticle == null)
            {
                Console.WriteLine(
                    "No reticles selected."
                );
                return;
            }

            try
            {
                if (selectedDefaultReticle != null)
                {
                    ReplaceReticleFile(
                        selectedDefaultReticle,
                        "Reticle_Default.png"
                    );
                }

                if (selectedMeleeReticle != null)
                {
                    ReplaceMeleeReticles(selectedMeleeReticle);
                }

                Console.WriteLine(
                    "Reticles applied successfully!"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Failed to apply reticles:\n{ex.Message}"
                );
            }
        }

        private void ReplaceReticleFile(string sourceFile, string targetFile)
        {
            string targetPath = GetReticlePath(targetFile);
            string backupPath = targetPath + ".backup";
            Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
            if (File.Exists(targetPath) && !File.Exists(backupPath))
            {
                File.Copy(targetPath, backupPath);
            }

            File.Copy(sourceFile, targetPath, overwrite: true);
        }

        private void ReplaceMeleeReticles(string sourceFile)
        {
            string meleePath = GetReticlePath("Reticle_Melee.png");
            string meleeFadedPath = GetReticlePath("Reticle_Melee_Faded.png");
            string meleeKillPath = GetReticlePath("Reticle_MeleeKill.png");
            foreach (string path in new[] { meleePath, meleeFadedPath, meleeKillPath })
            {
                string backupPath = path + ".backup";
                if (File.Exists(path) && !File.Exists(backupPath))
                {
                    File.Copy(path, backupPath);
                }
            }
            File.Copy(sourceFile, meleePath, overwrite: true);

            // faded melee reticle is 50% opacity, idk if this reticle is used, just doing it for sake of consistency
            using (Bitmap bmp = new Bitmap(sourceFile))
            using (Bitmap faded = new Bitmap(bmp.Width, bmp.Height))
            using (Graphics g = Graphics.FromImage(faded))
            {
                ColorMatrix cm = new ColorMatrix
                {
                    Matrix33 = 0.5f
                };
                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia);
                faded.Save(meleeFadedPath, ImageFormat.Png);
            }

            // kill melee reticle is just color overlayed with #B42F28
            Color overlayColor = Color.FromArgb(180, 47, 40);
            using (Bitmap bmp = new Bitmap(sourceFile))
            using (Bitmap kill = new Bitmap(bmp.Width, bmp.Height))
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color px = bmp.GetPixel(x, y);
                        if (px.A == 255)
                        {
                            kill.SetPixel(x, y, Color.FromArgb(px.A, overlayColor.R, overlayColor.G, overlayColor.B));
                        }
                        else
                        {
                            kill.SetPixel(x, y, px);
                        }
                    }
                }
                kill.Save(meleeKillPath, ImageFormat.Png);
            }
        }
    }
}
