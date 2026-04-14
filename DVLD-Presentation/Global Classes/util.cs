using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Classes
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();
            
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
         
            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;
            
        }
     
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }
       
        public static  bool CopyImageToProjectImagesFolder(ref string  sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show (iox.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile= destinationFile;
            return true;
        }

        public static void ApplyCustomStyle(ref DataGridView dgview)
        {
            DataGridView dgv = dgview;
            // Primary color (0, 120, 215)
            Color primaryColor = Color.FromArgb(0, 120, 215);
            Color lightPrimary = Color.FromArgb(50, 150, 235); // Lighter shade for hover
            Color backgroundColor = Color.FromArgb(245, 245, 245); // Light gray background
            Color alternateRowColor = Color.FromArgb(230, 240, 250); // Subtle blue tint for alternate rows
            Color textColor = Color.FromArgb(30, 30, 30); // Dark text for readability
            Color gridLineColor = Color.FromArgb(200, 200, 200); // Subtle grid lines

            // General DataGridView settings
            dgv.EnableHeadersVisualStyles = false; // Disable default header styling
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = backgroundColor;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = textColor; 
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.SelectionBackColor = lightPrimary;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.Padding = new Padding(5); // Cell padding
            dgv.GridColor = gridLineColor;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Enable text wrapping

            // Alternating row style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = alternateRowColor;

            // Column headers style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Row headers style
            dgv.RowHeadersDefaultCellStyle.BackColor = primaryColor;
            dgv.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 30;

            // Enable double buffering to reduce flicker
            //dgv.DoubleBuffered = true;

            // Row settings
            dgv.RowTemplate.Height = 30; // Taller rows for better readability
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;

            // Auto-size columns based on content
            using (Graphics g = dgv.CreateGraphics())
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    // Measure header width
                    int headerWidth = (int)g.MeasureString(column.HeaderText,
                        dgv.ColumnHeadersDefaultCellStyle.Font).Width + 20; // Add padding

                    // Measure content width
                    int maxContentWidth = dgv.Rows.Cast<DataGridViewRow>()
                        .Where(row => !row.IsNewRow)
                        .Select(row => row.Cells[column.Index].Value?.ToString() ?? "")
                        .Select(text => (int)g.MeasureString(text,
                            dgv.DefaultCellStyle.Font).Width + 20) // Add padding
                        .DefaultIfEmpty(0)
                        .Max();

                    // Set column width to the maximum of header or content width
                    column.Width = Math.Max(headerWidth, maxContentWidth);
                }
            }

            // Hover effect
            dgv.CellMouseEnter += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = lightPrimary;
                }
            };

            dgv.CellMouseLeave += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0 ? Color.White : alternateRowColor;
                }
            };

            // Selection style
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }

    }
}
