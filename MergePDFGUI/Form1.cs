//using System.Reflection.Metadata;
//using System.Reflection.PortableExecutable;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Org.BouncyCastle.Asn1.Cms;
using System.Windows.Forms;

namespace MergePDFGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbFileList.AllowDrop = true;
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            openFileDialog.Multiselect = true;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                //lbFileList.Items.AddRange(openFileDialog.FileNames);
                foreach (var item in openFileDialog.FileNames)
                {
                    if (!lbFileList.Items.Contains(item))
                        lbFileList.Items.Add(item);
                }
            }
        }

        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            if (lbFileList.SelectedIndex != -1)
            {
                var selectedItems = lbFileList.SelectedItems;
                //lbFileList.Items.Remove(lbFileList.SelectedItem);
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    lbFileList.Items.Remove(selectedItems[i]);
                }
            }
        }

        private void btnClearFiles_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to clear files?", "Clear Files", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lbFileList.Items.Clear();
            }
        }

        private void btnMergeFiles_Click(object sender, EventArgs e)
        {
            if (lbFileList.Items.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF File|*.pdf";
                saveFileDialog.Title = "Save Merged PDF";
                saveFileDialog.FileName = "merged.pdf";
                var dialogResult = saveFileDialog.ShowDialog();

                if (dialogResult == DialogResult.Cancel)
                    return;

                if (saveFileDialog.FileName != "")
                {
                    string[] lstFiles = lbFileList.Items.OfType<string>().ToArray();
                    var mergeResult = MergePages(saveFileDialog.FileName, lstFiles);

                    if (mergeResult)
                    {
                        MessageBox.Show("File merge successful", "Merge Successful", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("No target file specified", "Merge Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No file added to list", "Merge Error", MessageBoxButtons.OK);
            }
        }

        private Boolean MergePages(string outputPdfPath, string[] lstFiles)
        {
            Boolean result = false;
            PdfReader reader;
            PdfImportedPage importedPage;
            Document sourceDocument = new Document();
            var destinationFileStream = new FileStream(outputPdfPath, FileMode.Create);
            PdfCopy pdfCopyProvider = new PdfCopy(sourceDocument, destinationFileStream);
            sourceDocument.Open();
            try
            {
                for (int f = 0; f < lstFiles.Length; f++)
                {
                    int pages = 1;
                    reader = new PdfReader(lstFiles[f]);
                    pages = reader.NumberOfPages;
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }
                    reader.Close();
                }
                sourceDocument.Close();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                if (sourceDocument != null && sourceDocument.IsOpen())
                    sourceDocument.Close();
                if (pdfCopyProvider != null)
                    pdfCopyProvider.Close();
                if (destinationFileStream != null)
                    destinationFileStream.Close();
            }
            return result;
        }

        private void lbFileList_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbFileList.SelectedItem == null)
                return;
            lbFileList.DoDragDrop(lbFileList.SelectedItem, DragDropEffects.Move);
        }

        private void lbFileList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lbFileList_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lbFileList.PointToClient(new Point(e.X, e.Y));
            int index = this.lbFileList.IndexFromPoint(point);
            if (index < 0) index = this.lbFileList.Items.Count - 1;
            object data = e.Data.GetData(typeof(String));
            this.lbFileList.Items.Remove(data);
            this.lbFileList.Items.Insert(index, data);
        }
    }
}
