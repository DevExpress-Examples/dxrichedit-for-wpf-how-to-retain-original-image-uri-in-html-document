using System;
using System.Windows;
#region #usings
using DevExpress.Office.Services;
using DevExpress.XtraRichEdit.API.Native;
#endregion #usings

namespace HTML_Export_ImageSourceExample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void richEditControl1_Loaded(object sender, RoutedEventArgs e) {
            richEditControl1.CreateNewDocument();
            richEditControl1.Document.Images.Append(DocumentImageSource.FromUri("http://www.devexpress.com/Support/Center/Attachment/GetAttachmentFile/e71fc07d-1c4e-4e08-a9be-65eb6f409c8b", null));
            embedImagesCheck.EditValue = true;
            richEditControl1.ContentChanged += new EventHandler(richEditControl1_ContentChanged);
        }
        private void richEditControl1_ContentChanged(object sender, EventArgs e) {
            ReloadHtml();
        }

        private void ReloadHtml() {
            #region #GetHtmlText
            DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions exportOptions = new DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions();
            exportOptions.EmbedImages = (bool)embedImagesCheck.IsChecked;
            string sText = richEditControl1.Document.GetHtmlText(richEditControl1.Document.Range, new CustomUriProvider(), exportOptions);
            #endregion #GetHtmlText
            memoEdit1.Text = sText;
        }
        #region #documentloaded
        private void richEditControl1_DocumentLoaded(object sender, EventArgs e)
        {
            IUriProviderService service = richEditControl1.GetService<IUriProviderService>();
            if (service != null) {
                service.RegisterProvider(new CustomUriProvider());
            }
        }
        #endregion #documentloaded

        private void embedImagesCheck_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e) {
            if ((bool)e.NewValue == false)
                textBlock.Text = "The CustomUriProvider.CreateImageUri method is called to write the original image uri.";
            else
                textBlock.Text = "CustomUriProvider is idle.";
            ReloadHtml();
        }
    }
}
